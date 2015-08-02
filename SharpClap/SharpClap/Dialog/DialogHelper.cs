using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpClap.Commands;

namespace SharpClap.Dialog
{
    public static class DialogHelper
    {
        public static Command Edit(this GenericInputDialog gid, Command c)
        {
            Type commandType = c.GetType();

            /*if (commandType == typeof(Delay))
            {
                Delay d = (Delay)c;
                gid.Initialize(d);

                if (gid.ShowDialog() == DialogResult.OK)
                {
                    d.Value = (double)gid.Results["base"];
                    d.ValueModifier = (double)gid.Results["dev"];
                }
            }
            else if (commandType == typeof(PressKey))
            {
                PressKey pk = (PressKey)c;
                gid.Initialize(pk);

                if (gid.ShowDialog() == DialogResult.OK)
                {
                    string[] splitString = ((string)gid.Results["key"]).Split(',');
                    List<Extern.VirtualKeyShort> keyShorts = new List<Extern.VirtualKeyShort>();
                    List<Extern.ScanCodeShort> scanShorts = new List<Extern.ScanCodeShort>();

                    foreach (string key in splitString)
                    {
                        Extern.VirtualKeyShort vks;
                        Enum.TryParse((string)gid.Results["key"], true, out vks);

                        if (vks != Extern.VirtualKeyShort.NONE)
                        {
                            keyShorts.Add(vks);
                            scanShorts.Add(pk.GuessScanCode(vks));
                        }
                    }

                    pk.keyShort = keyShorts.ToArray();
                    pk.scanShort = scanShorts.ToArray();
                }
            }*/

            // TODO:
            // extension methods cannot be dynamically dispatched
            // not working as I had hoped
            // (have command of type Delay, uses extension with Delay parameter instead of command)
            // Reflection?
            if(commandType == typeof(Delay))
            {
                c = gid.Edit((Delay)c);
            }
            else if(commandType == typeof(PressKey))
            {
                c = gid.Edit((PressKey)c);
            }
            else
            {
                MessageBox.Show("Unable to edit type " + commandType.ToString());
            }
            
            return c;
        }
    }

    public static class DelayHelper
    {
        public static void Initialize(this GenericInputDialog gid, Delay d)
        {
            List<DialogQuestion> questions = new List<DialogQuestion>();

            questions.Add(new DialogQuestion("base", "Base value", typeof(double), d.Value));
            questions.Add(new DialogQuestion("dev", "Deviation", typeof(double), d.ValueModifier));

            gid.Initialize("Delay", questions);
        }

        public static Command Edit(this GenericInputDialog gid, Delay d)
        {
            gid.Initialize(d);

            if (gid.ShowDialog() == DialogResult.OK)
            {
                d.Value = (double)gid.Results["base"];
                d.ValueModifier = (double)gid.Results["dev"];
            }

            return d;
        }
    }

    public static class PressKeyHelper
    {
        public static void Initialize(this GenericInputDialog gid, PressKey pk)
        {
            List<DialogQuestion> questions = new List<DialogQuestion>();

            questions.Add(new DialogQuestion("key", "Keys (separated by comma)", typeof(string), String.Join(", ", pk.keyShort)));

            gid.Initialize("Key Press", questions);
        }

        public static Command Edit(this GenericInputDialog gid, PressKey pk)
        {
            gid.Initialize(pk);

            if (gid.ShowDialog() == DialogResult.OK)
            {
                string[] splitString = ((string)gid.Results["key"]).Split(',');
                List<Extern.VirtualKeyShort> keyShorts = new List<Extern.VirtualKeyShort>();
                List<Extern.ScanCodeShort> scanShorts = new List<Extern.ScanCodeShort>();

                foreach (string key in splitString)
                {
                    Extern.VirtualKeyShort vks;
                    Enum.TryParse(key.Trim(), true, out vks);

                    if (vks != Extern.VirtualKeyShort.NONE)
                    {
                        keyShorts.Add(vks);
                        scanShorts.Add(pk.GuessScanCode(vks));
                    }
                }

                pk.keyShort = keyShorts.ToArray();
                pk.scanShort = scanShorts.ToArray();
            }

            return pk;
        }
    }
}
