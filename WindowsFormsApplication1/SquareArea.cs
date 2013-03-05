using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class SquareArea
    {

        private int left;
        private int right;
        private int top;
        private int bottom;

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public SquareArea(Location centralLocation, int width, int height)
        {
            Left = centralLocation.X - (width / 2);
            Right = centralLocation.X + (width / 2);
            Top = centralLocation.Y + (height / 2);
            Bottom = centralLocation.Y - (height / 2);
        }
    }
}
