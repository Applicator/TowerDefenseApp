using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class Path
    {
        private List<Location> pointsOfInterest;

        public List<Location> PointsOfInterest
        {
            get { return pointsOfInterest; }
            set { pointsOfInterest = value; }
        }
    }
}
