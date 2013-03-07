using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TowerDefense
{
    public abstract class Enemy
    {
        protected List<Image> animation;
        protected int animationPictureNumber;
        protected int currentAnimationPicture;
        public const int ANIMATION_WIDTH = 100;
        public const int ANIMATION_HEIGHT = 100;
        protected int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
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

        public Enemy()
        {
            currentAnimationPicture = 0;
        }

    }
}
