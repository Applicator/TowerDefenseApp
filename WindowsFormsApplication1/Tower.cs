using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class Tower
    {

        protected const double ATTACK_POWER_MULTIPLIER = 0.5;
        protected const double ATTACK_RADUIS_MULTIPLIER = 2;
        protected const double ATTACK_SPEED_MULTIPLIER = 0.1;
        protected Location location;
        protected SquareArea squareArea;
        protected int attackPower;
        protected int attackRadius;
        protected int attackSpeed;

        public Location TowerLocation
        {
            get { return location; }
            set { location = value; }
        }

        public int TowerAttackPower
        {
            get { return attackPower; }
            set { attackPower = value; }
        }

        public int TowerAttackRadius
        {
            get { return attackRadius; }
            set { attackRadius = value; }
        }

        public int TowerAttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }

        public Tower(Location location)
        {
            TowerLocation = location;
        }
    }
}
