using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MonoTopDown.Model
{
    [DebuggerDisplay("{Left}, {Top}, {Width}, {Height}")]
    class ImageFrame
    {
        public int Top;
        public int Left;
        public int Width;
        public int Height;
    }

    class ImageFrameHolder:Dictionary<string, ImageFrame>
    {
        
    }
}
