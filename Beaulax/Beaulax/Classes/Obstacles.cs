using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Beaulax.Classes
{
    class Obstacles: StaticObjects
    {
        // attributes
        private Rectangle hitBox;

        // parameters
        public Rectangle HitBox { get { return hitBox; } set { hitBox = value; } }

        // constructor
        public Obstacles(int iWidth, int iHeight, Vector2 iLocation)
        {
            this.width = iWidth;
            this.height = iHeight;
            this.location = iLocation;
            hitBox = new Rectangle((int)iLocation.X, (int)iLocation.Y, width, height);
        }
    }
}
