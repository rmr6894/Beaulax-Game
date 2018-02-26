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
    class GameObjects: ICollidableObjects
    {
        // attributes
        protected Rectangle location; // gives an x,y location and a seze (width, height)

        // constructor
        public GameObjects(Rectangle iLocation)
        {
            location = iLocation;
        }
    }
}
