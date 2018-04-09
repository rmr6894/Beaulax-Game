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
    class Computer: MapObjects 
    {
        public string id;
        public Texture2D text;
        Color color;


        public Computer(string identifier, Vector2 loc, int wide, int high, Texture2D txt, Color col)
        {
            id = identifier;
            location = loc;
            width = wide;
            height = high;
            hitBox = new Rectangle(Convert.ToInt32(loc.X), Convert.ToInt32(loc.Y), wide, height);
            text = txt;
            color = col;
        }

        public void Update(GameTime gameTime, Player play, Game1 game)
        {
            if (this.hitBox.Intersects(play.HitBox))
            {
                if (id == "computer1")
                {
                    if (game.access < 1)
                    {
                        play.AccessLevel = 1;
                        game.access = 1;
                    }
                }
                else if (id == "computer2")
                {
                    if (game.access < 2)
                    {
                        play.AccessLevel = 2;
                        game.access = 2;
                    }
                }
                else if (id == "computer3")
                {
                    if (game.access < 3)
                    {
                        play.AccessLevel = 3;
                        game.access = 3;
                    }
                }
                else if (id == "computer4")
                {
                    if (game.access < 4)
                    {
                        play.AccessLevel = 4;
                        game.access = 4;
                    }
                }
                else if (id == "computer5")
                {
                    if (game.access < 5)
                    {
                        play.AccessLevel = 5;
                        game.access = 5;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, hitBox, color);
        }
    }
}
