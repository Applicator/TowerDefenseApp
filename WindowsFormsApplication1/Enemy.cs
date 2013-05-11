using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TowerDefense
{
    public abstract class Enemy : Animated
    {
        protected List<Image> animation;
        protected int animationPictureNumber;
        protected int currentAnimationPicture;
        public const int ANIMATION_WIDTH = 100;
        public const int ANIMATION_HEIGHT = 100;
        protected int health;
        protected Location location;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Location EnemyLocation
        {
            get { return location; }
            set { location = value; }
        }

        public int AnimationPictureNumber
        {
            get { return animationPictureNumber; }
        }

        public int CurrentAnimationPicture
        {
            get { return currentAnimationPicture; }
            set { currentAnimationPicture = value; }
        }

        public List<Image> Animation
        {
            get { return animation; }
        }

        public Enemy(Location location)
        {
            EnemyLocation = location;
            currentAnimationPicture = 0;
        }

        public void draw()
        {
        }
    }
}
