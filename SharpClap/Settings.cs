using System.IO;
using System.Xml.Serialization;

namespace Sean
{
    [XmlInclude(typeof(SharpClap.Commands.Command))]
    public class Settings
    {
        #region Serializing
        public static Settings Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = Load();
                }

                return _Instance;
            }
        }

        private static Settings _Instance;

        public static Settings Load(string filename = "settings.xml")
        {
            Settings s = null;

            if (!File.Exists(filename))
            {
                s = new Settings();
                s.Save(filename);
                return s;
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                s = (Settings)xs.Deserialize(sr);
            }

            return s == null ? new Settings() : s;
        }

        public void Save(string filename = "settings.xml")
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                xs.Serialize(sw, this);
            }
        }
        #endregion

		#region Settings

        public object[] ActiveObjects = new object[0];

        public int Cooldown = 500;

        public int MinCutoff = 16;

        public int MaxCutoff = 100;

        #endregion
    }
}
