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
    class GameObjects
    {

        // attributes
        //protected Rectangle location; // gives an x,y location and a size (width, height)
        protected bool hasCollided; // stores the information of whether an object has collided with another

        // properties
        /*public Rectangle Location
        {
            get { return location; }
            set { location = value; }
        }*/

        public bool HasCollided
        {
            get { return hasCollided; }
            set { hasCollided = value; }
        }

        /*// constructor
        public GameObjects(Rectangle iLocation)
        {
            location = iLocation;
        }

        // methods
        public bool CheckCollision(GameObjects gameObject)
        {
            if (hasCollided == true)
            {
                if (gameObject.location.Intersects(this.Location))
                {
                    return true;
                }
            }

            return false;
        }*/


    }
}
