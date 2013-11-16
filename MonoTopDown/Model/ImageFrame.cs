using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MonoTopDown.Utils;
using Newtonsoft.Json;

namespace MonoTopDown.Model
{
    [DebuggerDisplay("{Filename} -> {Left}, {Top}, {Width}, {Height}")]
    [JsonObject(MemberSerialization.OptIn)]
    class ImageFrame
    {
        private string _filename = "";

        [JsonProperty("filename", Required = Required.Always)]
        public string Filename {
            get { return _filename; }
            set
            {
                var s = value;
                /*if (!string.IsNullOrWhiteSpace(s))
                {
                    foreach (var ext in Resources.ImageExtensions)
                        s = s.Replace(ext, "");
                }*/
                _filename = s;
            }
        }

        [JsonProperty("frame", Required = Required.Always)]
        private InternalFrame Frame { get; set; }

        public int Top { get { return Frame.y; } }
        public int Left { get { return Frame.x; } }
        public int Width { get { return Frame.w; } }
        public int Height { get { return Frame.h; } }
    }

    class ImageFrameHolder:Dictionary<string, ImageFrame>
    {
        
    }

    internal class InternalFrame
    {
        public int x;
        public int y;
        public int w;
        public int h;
    }
}
