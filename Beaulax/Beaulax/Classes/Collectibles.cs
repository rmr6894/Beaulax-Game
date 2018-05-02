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
        bool pickedUp;

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
                    pickedUp = true;
                }
                else if (id == "jumppack")
                {
                    pickedUp = true;
                    game.hasJump = true;
                }
                else if (id == "tank")
                {
                    pickedUp = true;
                    game.hasTank = true;
                }
                else if (id == "medpack")
                {
                    if (pickedUp == false)
                    {
                        pickedUp = true;
                        play.CharacterHealth = game.playerMaxHealth;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (pickedUp == false)
            {
                spriteBatch.Draw(text, hitBox, Color.White);
            }
        }
    }
}
