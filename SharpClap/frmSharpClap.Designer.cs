namespace SharpClap
{
    partial class frmSharpClap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSharpClap));
            this.tmrVolume = new System.Windows.Forms.Timer(this.components);
            this.lblVolume = new System.Windows.Forms.Label();
            this.pbVolume = new System.Windows.Forms.ProgressBar();
            this.nudCutoff = new System.Windows.Forms.NumericUpDown();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblCooldown = new System.Windows.Forms.Label();
            this.btnDelayEnable = new System.Windows.Forms.Button();
            this.nudMaxCutoff = new System.Windows.Forms.NumericUpDown();
            this.cbAudioOutput = new System.Windows.Forms.ComboBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnDelay5 = new System.Windows.Forms.Button();
            this.btnDelay = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstPossibleActions = new System.Windows.Forms.ListBox();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.nudCooldown = new System.Windows.Forms.NumericUpDown();
            this.gbVolume = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnRandomDelay = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudCutoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCutoff)).BeginInit();
            this.gbActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCooldown)).BeginInit();
            this.gbVolume.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrVolume
            // 
            this.tmrVolume.Interval = 10;
            this.tmrVolume.Tick += new System.EventHandler(this.tmrVolume_Tick);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(112, 19);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(13, 13);
            this.lblVolume.TabIndex = 1;
            this.lblVolume.Text = "0";
            // 
            // pbVolume
            // 
            this.pbVolume.Location = new System.Drawing.Point(6, 19);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(100, 13);
            this.pbVolume.TabIndex = 2;
            // 
            // nudCutoff
            // 
            this.nudCutoff.Location = new System.Drawing.Point(6, 51);
            this.nudCutoff.Name = "nudCutoff";
            this.nudCutoff.Size = new System.Drawing.Size(40, 20);
            this.nudCutoff.TabIndex = 3;
            this.nudCutoff.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(92, 35);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblCooldown
            // 
            this.lblCooldown.AutoSize = true;
            this.lblCooldown.Location = new System.Drawing.Point(6, 16);
            this.lblCooldown.Name = "lblCooldown";
            this.lblCooldown.Size = new System.Drawing.Size(121, 13);
            this.lblCooldown.TabIndex = 5;
            this.lblCooldown.Text = "Current Cooldown: 0000";
            // 
            // btnDelayEnable
            // 
            this.btnDelayEnable.Location = new System.Drawing.Point(92, 51);
            this.btnDelayEnable.Name = "btnDelayEnable";
            this.btnDelayEnable.Size = new System.Drawing.Size(79, 24);
            this.btnDelayEnable.TabIndex = 6;
            this.btnDelayEnable.Text = "Delayed Start";
            this.btnDelayEnable.UseVisualStyleBackColor = true;
            this.btnDelayEnable.Click += new System.EventHandler(this.btnDelayEnable_Click);
            // 
            // nudMaxCutoff
            // 
            this.nudMaxCutoff.Location = new System.Drawing.Point(66, 51);
            this.nudMaxCutoff.Name = "nudMaxCutoff";
            this.nudMaxCutoff.Size = new System.Drawing.Size(40, 20);
            this.nudMaxCutoff.TabIndex = 7;
            this.nudMaxCutoff.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cbAudioOutput
            // 
            this.cbAudioOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioOutput.FormattingEnabled = true;
            this.cbAudioOutput.Location = new System.Drawing.Point(12, 27);
            this.cbAudioOutput.Name = "cbAudioOutput";
            this.cbAudioOutput.Size = new System.Drawing.Size(321, 21);
            this.cbAudioOutput.TabIndex = 8;
            this.cbAudioOutput.SelectedIndexChanged += new System.EventHandler(this.cbAudioOutput_SelectedIndexChanged);
            // 
            // gbActions
            // 
            this.gbActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActions.Controls.Add(this.btnRandomDelay);
            this.gbActions.Controls.Add(this.btnDelay5);
            this.gbActions.Controls.Add(this.btnDelay);
            this.gbActions.Controls.Add(this.btnSubtract);
            this.gbActions.Controls.Add(this.btnAdd);
            this.gbActions.Controls.Add(this.lstPossibleActions);
            this.gbActions.Controls.Add(this.lstActions);
            this.gbActions.Location = new System.Drawing.Point(12, 54);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(321, 190);
            this.gbActions.TabIndex = 9;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // btnDelay5
            // 
            this.btnDelay5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelay5.Location = new System.Drawing.Point(144, 156);
            this.btnDelay5.Name = "btnDelay5";
            this.btnDelay5.Size = new System.Drawing.Size(31, 23);
            this.btnDelay5.TabIndex = 5;
            this.btnDelay5.Text = "5s";
            this.btnDelay5.UseVisualStyleBackColor = true;
            this.btnDelay5.Click += new System.EventHandler(this.btnDelay5_Click);
            // 
            // btnDelay
            // 
            this.btnDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelay.Location = new System.Drawing.Point(144, 127);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(31, 23);
            this.btnDelay.TabIndex = 4;
            this.btnDelay.Text = "1s";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(144, 48);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(31, 23);
            this.btnSubtract.TabIndex = 3;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(144, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstPossibleActions
            // 
            this.lstPossibleActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPossibleActions.FormattingEnabled = true;
            this.lstPossibleActions.Location = new System.Drawing.Point(6, 19);
            this.lstPossibleActions.Name = "lstPossibleActions";
            this.lstPossibleActions.ScrollAlwaysVisible = true;
            this.lstPossibleActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPossibleActions.Size = new System.Drawing.Size(132, 160);
            this.lstPossibleActions.TabIndex = 1;
            // 
            // lstActions
            // 
            this.lstActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstActions.ContextMenuStrip = this.contextMenuStrip;
            this.lstActions.FormattingEnabled = true;
            this.lstActions.Location = new System.Drawing.Point(181, 19);
            this.lstActions.MaximumSize = new System.Drawing.Size(200, 500);
            this.lstActions.Name = "lstActions";
            this.lstActions.ScrollAlwaysVisible = true;
            this.lstActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstActions.Size = new System.Drawing.Size(132, 160);
            this.lstActions.TabIndex = 0;
            this.lstActions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstActions_KeyUp);
            // 
            // nudCooldown
            // 
            this.nudCooldown.Location = new System.Drawing.Point(9, 55);
            this.nudCooldown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCooldown.Name = "nudCooldown";
            this.nudCooldown.Size = new System.Drawing.Size(71, 20);
            this.nudCooldown.TabIndex = 10;
            this.nudCooldown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // gbVolume
            // 
            this.gbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbVolume.Controls.Add(this.label1);
            this.gbVolume.Controls.Add(this.pbVolume);
            this.gbVolume.Controls.Add(this.lblVolume);
            this.gbVolume.Controls.Add(this.nudCutoff);
            this.gbVolume.Controls.Add(this.nudMaxCutoff);
            this.gbVolume.Location = new System.Drawing.Point(12, 250);
            this.gbVolume.Name = "gbVolume";
            this.gbVolume.Size = new System.Drawing.Size(138, 81);
            this.gbVolume.TabIndex = 11;
            this.gbVolume.TabStop = false;
            this.gbVolume.Text = "Volume";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Trigger Range:";
            // 
            // gbControl
            // 
            this.gbControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControl.Controls.Add(this.label2);
            this.gbControl.Controls.Add(this.chkEnabled);
            this.gbControl.Controls.Add(this.btnDelayEnable);
            this.gbControl.Controls.Add(this.nudCooldown);
            this.gbControl.Controls.Add(this.lblCooldown);
            this.gbControl.Location = new System.Drawing.Point(156, 250);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(177, 81);
            this.gbControl.TabIndex = 12;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cooldown:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(342, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // btnRandomDelay
            // 
            this.btnRandomDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRandomDelay.Location = new System.Drawing.Point(144, 98);
            this.btnRandomDelay.Name = "btnRandomDelay";
            this.btnRandomDelay.Size = new System.Drawing.Size(31, 23);
            this.btnRandomDelay.TabIndex = 6;
            this.btnRandomDelay.Text = "#s";
            this.btnRandomDelay.UseVisualStyleBackColor = true;
            this.btnRandomDelay.Click += new System.EventHandler(this.btnRandomDelay_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemEdit.Text = "Edit";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // frmSharpClap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 340);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbVolume);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.cbAudioOutput);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(358, 353);
            this.Name = "frmSharpClap";
            this.Text = "SharpClap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCutoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCutoff)).EndInit();
            this.gbActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCooldown)).EndInit();
            this.gbVolume.ResumeLayout(false);
            this.gbVolume.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.ProgressBar pbVolume;
        private System.Windows.Forms.NumericUpDown nudCutoff;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblCooldown;
        private System.Windows.Forms.Button btnDelayEnable;
        private System.Windows.Forms.NumericUpDown nudMaxCutoff;
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnDelay;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstPossibleActions;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnDelay5;
        private System.Windows.Forms.NumericUpDown nudCooldown;
        private System.Windows.Forms.GroupBox gbVolume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnRandomDelay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}

