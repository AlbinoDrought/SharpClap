using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpClap.Commands
{
    public class PressKey : Command
    {
        public Extern.VirtualKeyShort[] keyShort;

        public Extern.ScanCodeShort[] scanShort;

        private static Random random = new Random();

        private static int pressReleaseIntervalMin = 30;

        private static int pressReleaseIntervalMax = 75;

        // blank constructor necessary for serialization
        public PressKey()
        {
            
        }

        public PressKey(Extern.VirtualKeyShort[] keys)
        {
            keyShort = keys;
            scanShort = GuessScanCodes(keys);
        }

        public PressKey(Extern.VirtualKeyShort[] keys, Extern.ScanCodeShort[] scans)
        {
            keyShort = keys;
            scanShort = scans;
        }

        public Extern.ScanCodeShort[] GuessScanCodes(Extern.VirtualKeyShort[] keys)
        {
            List<Extern.ScanCodeShort> scanCodes = new List<Extern.ScanCodeShort>();

            foreach(Extern.VirtualKeyShort key in keys)
            {
                scanCodes.Add(GuessScanCode(key));
            }

            return scanCodes.ToArray();
        }

        public Extern.ScanCodeShort GuessScanCode(Extern.VirtualKeyShort key)
        {
            Extern.ScanCodeShort guessScanCodeShort;
            Extern.ScanCodeShort.TryParse(key.ToString(), true, out guessScanCodeShort);

            return guessScanCodeShort;
        }

        public async override Task<string> Execute()
        {
            await Task.Run((Action)SendKeys);
            
            return "Finished sending keys";
        }

        private void SendKeys()
        {
            Extern.INPUT[] sendInputs = new Extern.INPUT[keyShort.Length];
            for(int i = 0; i < sendInputs.Length; i++)
            {
                sendInputs[i] = GetKeyEvent(keyShort[i], scanShort[i]);
            }

            Extern.SendInput(sendInputs);

            System.Threading.Thread.Sleep(random.Next(pressReleaseIntervalMin, pressReleaseIntervalMax));

            // set key up event
            for(int i = 0; i < sendInputs.Length; i++)
            {
                sendInputs[i].U.ki.dwFlags = Extern.KEYEVENTF.KEYUP;
            }

            Extern.SendInput(sendInputs);
        }

        private Extern.INPUT GetKeyEvent(Extern.VirtualKeyShort key, Extern.ScanCodeShort scan)
        {
            return new SharpClap.Extern.INPUT()
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
                                                                        scan,
                                                                    wVk
                                                                        =
                                                                        key
                                                                }
                                                    }
                                        };
        }

        public override string ToString()
        {
            return String.Join(", ", keyShort);
        }
    }
}
