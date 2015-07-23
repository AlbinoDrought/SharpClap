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

            if (commandType == typeof(Delay))
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
                    Extern.VirtualKeyShort vks;
                    Enum.TryParse((string)gid.Results["key"], true, out vks);

                    if (vks != Extern.VirtualKeyShort.NONE)
                    {
                        pk.keyShort = vks;
                        pk.GuessScanCode(vks);
                    }
                }
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
    }

    public static class PressKeyHelper
    {
        public static void Initialize(this GenericInputDialog gid, PressKey pk)
        {
            List<DialogQuestion> questions = new List<DialogQuestion>();

            questions.Add(new DialogQuestion("key", "Key", typeof(string), pk.keyShort.ToString()));

            gid.Initialize("Key Press", questions);
        }
    }
}
