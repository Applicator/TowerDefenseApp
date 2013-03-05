using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{

    public class GameBoard
    {

        private List<Tower> builtTowers;

        public List<Tower> BuiltTowers
        {
            get { return builtTowers; }
            set { builtTowers = value; }
        }

        public GameBoard()
        {
            builtTowers = new List<Tower>();
        }
    }
}
