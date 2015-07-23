using System;
using System.Threading.Tasks;

namespace SharpClap.Commands
{
    public class PressKey : Command
    {
        public Extern.VirtualKeyShort keyShort;

        public Extern.ScanCodeShort scanShort;

        private static Random random = new Random();

        private static int pressReleaseIntervalMin = 30;

        private static int pressReleaseIntervalMax = 75;

        // blank constructor necessary for serialization
        public PressKey()
        {
            
        }

        public PressKey(Extern.VirtualKeyShort key)
        {
            keyShort = key;
            this.GuessScanCode(key);
        }

        public PressKey(Extern.VirtualKeyShort key, Extern.ScanCodeShort scan)
        {
            keyShort = key;
            scanShort = scan;
        }

        public void GuessScanCode(Extern.VirtualKeyShort key)
        {
            Extern.ScanCodeShort guessScanCodeShort;
            Extern.ScanCodeShort.TryParse(key.ToString(), true, out guessScanCodeShort);

            if (guessScanCodeShort != 0)
            {
                scanShort = guessScanCodeShort;
            }
        }

        public async override Task<string> Execute()
        {
            // tabs get kinda wacky here
            await Task.Run(
                () =>
                    {
                        Extern.INPUT[] sendInputs = new Extern.INPUT[]
                                                        {
                                                            new SharpClap.Extern.INPUT()
                                                                {
                                                                    type = Extern.INPUT_KEYBOARD,
                                                                    U =
                                                                        new Extern.InputUnion()
                                                                            {
                                                                                ki
                                                                                    =
                                                                                    new Extern
                                                                                    .
                                                                                    KEYBDINPUT
                                                                                    (
                                                                                    )
                                                                                        {
                                                                                            wScan
                                                                                                =
                                                                                                scanShort,
                                                                                            wVk
                                                                                                =
                                                                                                keyShort
                                                                                        }
                                                                            }
                                                                }
                                                        };

                        Extern.SendInput(sendInputs);

                        System.Threading.Thread.Sleep(random.Next(pressReleaseIntervalMin, pressReleaseIntervalMax));

                        sendInputs[0].U.ki.dwFlags = Extern.KEYEVENTF.KEYUP;
                        Extern.SendInput(sendInputs);
                    });
            
            return "Finished sending key";
        }

        public override string ToString()
        {
            return keyShort.ToString();
        }
    }
}
