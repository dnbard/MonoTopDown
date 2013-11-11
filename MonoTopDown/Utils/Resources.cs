using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoTopDown.Utils
{
    class Resources
    {
        private static readonly Dictionary<string, string> Strings =
            JSON.DeserializeCollection("Content/strings.json");

        public static string Get(string key)
        {
            return Strings[key];
        }

        public static string[] ImageExtensions = { ".png", ".jpg" };
    }
}
