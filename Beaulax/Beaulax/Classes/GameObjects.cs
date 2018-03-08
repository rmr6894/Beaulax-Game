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
        protected Vector2 location; // gives an x,y location and a size (width, height)
        protected Rectangle hitBox; // hit box
        protected int width; // width of hb
        protected int height; // length of hb

        //properties
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        public Rectangle HitBox
        {
            get { return hitBox; }
            set { hitBox = value; }
        }

        // methods
        public virtual bool CheckCollision(GameObjects gameObject)
        {
            if (gameObject.hitBox.Intersects(this.hitBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
