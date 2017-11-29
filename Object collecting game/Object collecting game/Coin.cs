using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Object_collecting_game
{
    class Coin
    {
        public Rectangle CoinRect;
        bool hasBeenPickedUp = false;

        public bool HasBeenPickedUp { get; set; }
        public Coin(int x,int y,int width,int height)
        {
            CoinRect = new Rectangle(x, y, width, height);
        }

        public void HasBeenCollected()
        {
            hasBeenPickedUp = true;
        }
    }
}
