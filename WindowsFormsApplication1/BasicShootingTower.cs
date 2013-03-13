using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class BasicShootingTower : Tower
    {
        public BasicShootingTower(Location location) : base(location)
        {
            attackPower = 10;
            attackRadius = 10;
            attackSpeed = 10;
            squareArea = new SquareArea(location, 10, 10);
        }

        public void upgrade1()
        {
            attackPower = 15;
            attackRadius = 15;
            attackSpeed = 15;
        }
    }
}
