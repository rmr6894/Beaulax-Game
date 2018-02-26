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
    class MovingObjects: GameObjects
    {
        // attributes
        protected int speed;

        // constructor
        public MovingObjects(Rectangle location, int iSpeed) : base(location)
        {
            speed = iSpeed;
        }
    }
}
