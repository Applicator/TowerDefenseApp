using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TowerDefense
{
    class Beetle : Enemy
    {
        public Beetle()
        {
            animation = new List<Image>();
            animationPictureNumber = 178;
            fillBeetleList(animation);
        }

        public void fillBeetleList(List<Image> emptyList)
        {
            int imageNumber = 0;
            while (imageNumber < animationPictureNumber)
            {
                string imageString = imageNumber.ToString();
                string originalString = imageNumber.ToString();
                for (int i = 4; i >= originalString.Length; i--)
                {
                    imageString = "0" + imageString;
                }
                emptyList.Add(Image.FromFile("C:\\Users\\Matt Johnson\\Documents\\Visual Studio 2010\\Projects\\TowerDefenseApplication\\WindowsFormsApplication1\\Beetle\\BeetleOpeningWings" + imageString + ".png"));
                imageNumber++;
            }
        }
    }
}
