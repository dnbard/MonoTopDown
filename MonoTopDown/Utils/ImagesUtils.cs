using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoTopDown.Utils
{
    class ImagesUtils
    {
        public static string ExtractKeyFromFilepath(string path)
        {
            foreach (var imageExtension in Resources.ImageExtensions)
            {
                if (path.Contains(imageExtension))
                {
                    path.Replace(imageExtension, "");
                    return path;
                }
            }

            return path;
        }
    }
}
