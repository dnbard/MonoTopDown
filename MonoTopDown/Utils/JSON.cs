using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MonoTopDown.Utils
{
    static class JSON
    {
        public static T Deserialize<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public static Dictionary<string, string> DeserializeCollection(string path)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
        }

        public static void Serialize(object obj, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
    }
}
