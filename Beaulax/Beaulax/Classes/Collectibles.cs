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
    class Collectibles: StaticObjects
    {
        string id;
        private Texture2D text;

        public Collectibles(string identifier, Vector2 loc, int wide, int high, Texture2D txt)
        {
            id = identifier;
            location = loc;
            width = wide;
            height = high;
            hitBox = new Rectangle(Convert.ToInt32(loc.X), Convert.ToInt32(loc.Y), wide, height);
            text = txt;
        }

        public void Update(GameTime gameTime, Player play, Game1 game)
        {
            if (this.hitBox.Intersects(play.HitBox))
            {
                if (id == "flashlight")
                {
                    game.hasFlash = true;
                }
                else if (id == "jumppack")
                {
                    game.hasJump = true;
                }
                else if (id == "tank")
                {
                    game.hasTank = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, location, Color.White);
        }
    }
}
