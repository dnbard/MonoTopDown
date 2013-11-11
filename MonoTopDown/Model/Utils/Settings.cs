using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTopDown.Utils;

namespace MonoTopDown.Model.Utils
{
    class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private Settings()
        {
            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            Width = 640;
            Height = 480;            
        }

        public static Settings Load(string file)
        {
            try
            {
                return JSON.Deserialize<Settings>(file);
            }
            catch (Exception ex)
            {
                return new Settings();
            }
        }

        public void Save()
        {
            JSON.Serialize(this, Resources.Get("pathConfig"));
        }
    }
}
