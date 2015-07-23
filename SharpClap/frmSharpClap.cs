using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpClap.Commands;
using NAudio.CoreAudioApi;
using Sean;

namespace SharpClap
{
    using SharpClap.Dialog;

    public partial class frmSharpClap : Form
    {
        private MMDevice currentDevice;

        private WasapiCapture currentCapture;

        private int amountPeakValues = 4;

        private List<int> peakValues;

        private int actionCooldown = 0;

        private Random random = new Random();

        private bool currentlyProcessing = false;

        public frmSharpClap()
        {
            InitializeComponent();
        }

        #region Buttons
        private void btnDelayEnable_Click(object sender, EventArgs e)
        {
            this.SetCooldown((int)nudCooldown.Value);
            chkEnabled.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstPossibleActions.SelectedItems.Count <= 0) return;

            List<PressKey> keyCommands = new List<PressKey>();

            foreach (object o in lstPossibleActions.SelectedItems)
            {
                Extern.VirtualKeyShort vks = (Extern.VirtualKeyShort)o;
                keyCommands.Add(new PressKey(vks));
            }

            lstActions.Items.AddRange(keyCommands.ToArray());
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            this.deleteSelectedActions();
        }

        private void btnRandomDelay_Click(object sender, EventArgs e)
        {
            GenericInputDialog gid = new GenericInputDialog();
            gid.Initialize(new Delay(1.00, 0.00));

            if (gid.ShowDialog() == DialogResult.OK)
            {
                double baseValue = (double)gid.Results["base"];
                double deviation = (double)gid.Results["dev"];

                lstActions.Items.Add(new Delay(baseValue, deviation));
            }
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            lstActions.Items.Add(new Delay(1));
        }

        private void btnDelay5_Click(object sender, EventArgs e)
        {
            lstActions.Items.Add(new Delay(5));
        }
        #endregion

        #region Menu Items
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Settings s = Settings.Load(openFileDialog.FileName);
                lstActions.Items.Clear();
                lstActions.Items.AddRange(s.ActiveObjects);
                nudCooldown.Value = s.Cooldown;
                nudMaxCutoff.Value = s.MaxCutoff;
                nudCutoff.Value = s.MinCutoff;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command[] rawCommands = new Command[lstActions.Items.Count];
            lstActions.Items.CopyTo(rawCommands, 0);

            Settings s = new Settings()
            {
                ActiveObjects = rawCommands,
                Cooldown = (int)nudCooldown.Value,
                MaxCutoff = (int)nudMaxCutoff.Value,
                MinCutoff = (int)nudCutoff.Value
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                s.Save(saveFileDialog.FileName);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0} v{1}\r\n{2}", this.ProductName, this.ProductVersion, "Created by Sean for generic button-pressing purposes."));
        }

        // context menu
        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (lstActions.SelectedItems.Count <= 0) return;

            object[] selectedObjects = new object[lstActions.SelectedItems.Count];
            lstActions.SelectedItems.CopyTo(selectedObjects, 0);

            GenericInputDialog gid = new GenericInputDialog();

            for (int i = 0; i < selectedObjects.Length; i++)
            {
                object o = selectedObjects[i];
                Type oType = o.GetType();
                if (!typeof(Command).IsAssignableFrom(oType)) continue;

                Command c = (Command)o;
                c = gid.Edit(c);

                int realCommandIndex = lstActions.Items.IndexOf(lstActions.SelectedItems[i]);
                lstActions.Items[realCommandIndex] = c;
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            this.deleteSelectedActions();
        }
        #endregion

        #region Other Listeners
        private void tmrVolume_Tick(object sender, EventArgs e)
        {
            int value = 0;

            if (currentDevice != null)
            {
                value = (int)(Math.Round(currentDevice.AudioMeterInformation.MasterPeakValue * 100));
            }

            peakValues.RemoveAt(0);
            peakValues.Add(value);

            int average = 0;

            for (int i = 0; i < peakValues.Count; i++)
            {
                average += peakValues[i];
            }

            average /= peakValues.Count;
            bool averageInCutoff = average >= nudCutoff.Value && average <= nudMaxCutoff.Value;

            if (averageInCutoff && !currentlyProcessing)
            {
                this.aboveCutoff();
            }

            this.SetAverage(average, averageInCutoff);

            if (!currentlyProcessing && actionCooldown > 0)
            {
                this.SetCooldown(actionCooldown - 1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active))
            {
                cbAudioOutput.Items.Add(device);
            }
            cbAudioOutput.SelectedIndex = cbAudioOutput.Items.Count - 1;

            Extern.VirtualKeyShort[] keyShorts = (Extern.VirtualKeyShort[])Enum.GetValues(typeof(Extern.VirtualKeyShort));
            foreach (Extern.VirtualKeyShort vks in keyShorts)
            {
                lstPossibleActions.Items.Add(vks);
            }

            this.SetCooldown(0);
            this.SetAverage(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopRecording();
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            gbActions.Enabled = !chkEnabled.Checked;
        }

        private void lstActions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.deleteSelectedActions();
            }
        }

        private void cbAudioOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            MMDevice mmd = (MMDevice)cbAudioOutput.SelectedItem;
            currentDevice = mmd;

            this.StopRecording();

            if (mmd.DataFlow == DataFlow.Capture)
            {
                // if the device is a mic, sound will only be recorded if something is listening
                currentCapture = new WasapiCapture(currentDevice);
                currentCapture.StartRecording();
            }

            peakValues = new List<int>();

            for (int i = 0; i < amountPeakValues; i++)
            {
                peakValues.Add(0);
            }

            tmrVolume.Enabled = true;
        }
        #endregion

        private void SetCooldown(int newcooldown)
        {
            actionCooldown = newcooldown;
            string formattedCooldown = newcooldown.ToString("0000");

            lblCooldown.Text = String.Format("Current Cooldown: {0}", formattedCooldown);
            this.Text = String.Format("{0}: {1}", this.ProductName, formattedCooldown);
        }

        private void SetAverage(int newaverage, bool averageInCutoff = false)
        {
            lblVolume.Text = newaverage.ToString();
            pbVolume.Value = newaverage;

            if (averageInCutoff)
            {
                lblVolume.ForeColor = Color.Red;
            }
            else
            {
                lblVolume.ForeColor = Color.Black;
            }
        }

        private void StopRecording(bool dispose = true)
        {
            if (currentCapture != null)
            {
                currentCapture.StopRecording();
                if(dispose) currentCapture.Dispose();
                currentCapture = null;
            }
        }

        private void deleteSelectedActions()
        {
            if (lstActions.SelectedItems.Count <= 0) return;

            object[] selectedObjects = new object[lstActions.SelectedItems.Count];
            lstActions.SelectedItems.CopyTo(selectedObjects, 0);

            foreach (object o in selectedObjects)
            {
                lstActions.Items.Remove(o);
            }
        }

        private async void aboveCutoff()
        {
            if (!chkEnabled.Checked || actionCooldown > 0 || currentlyProcessing) return;

            // uses async/await to not lock the UI thread
            currentlyProcessing = true;
            this.SetCooldown((int)nudCooldown.Value);
            await this.sendKey();
            currentlyProcessing = false;
        }

        private async Task<string> sendKey()
        {
            foreach (object o in lstActions.Items)
            {
                await ((Command)o).Execute();
            }

            return String.Format("Executed {0} commands", lstActions.Items.Count);
        }
    }
}
