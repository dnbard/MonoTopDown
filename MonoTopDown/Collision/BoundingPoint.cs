using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.GUI;

namespace MonoTopDown.Collision
{
    class BoundingPoint
    {

        private float x = 0;
        public float X
        {
            get { return x; }
            set
            {
                x = value;
                Point = new Point((int)value, Point.Y);
            }
        }

        private float y = 0;
        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                Point = new Point(Point.X, (int)value);
            }
        }

        public Point Point { get; set; }

        public ActorEventHandler Intersection;
        public ActorEventHandler NoIntersection;
    }
}
