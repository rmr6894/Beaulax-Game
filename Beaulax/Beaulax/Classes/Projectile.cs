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
    class Projectile : StaticObjects
    {
        // attributes
        Player player;
        int damage;
        Vector2 direction;
        int dmgCoolDwn;
        Vector2 velocity;
        Texture2D text;

        // animation
        int animationFrameHoriz;
        int animationFrameVert;
        int timeBtwnFrames = 5;
        int counter;
        int PROJ_WIDTH = 65;
        int PROJ_HEIGHT = 64;

        // constructor
        public Projectile(int iWidth, int iHeight, Vector2 Location, Player play, int dmg, Vector2 vel, Texture2D texture)
        {
            this.width = iWidth;
            this.height = iHeight;
            this.location = Location;
            this.hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
            player = play;
            damage = dmg;
            dmgCoolDwn = 10;
            velocity = vel;
            animationFrameHoriz = 0;
            animationFrameVert = 0;
            text = texture;
        }

        /// <summary>
        /// This method allows the projectile to deal a given amount of damage to the player 6 times a second.
        /// </summary>
        public void DealDamage()
        {
            if (dmgCoolDwn >= 10)
            {
                if (this.hitBox.Intersects(player.HitBox))
                {
                    player.TakeDamage(damage);
                    dmgCoolDwn = 0;
                }
            }
            else
            {
                dmgCoolDwn++;
            }
        }

        /// <summary>
        /// update the projectile object
        /// </summary>
        /// <param name="gameTime"> give the current time of game</param>
        public void Update(GameTime gameTime)
        {
            this.DealDamage(); // deal damage
            location += velocity;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);

            if (counter == timeBtwnFrames)
            {
                if (animationFrameHoriz < 2)
                {
                    animationFrameHoriz++;
                }
                else
                {
                    if (animationFrameVert == 0)
                    {
                        animationFrameVert = 1;
                        animationFrameHoriz = 0;
                    }
                    else
                    {
                        animationFrameVert = 0;
                        animationFrameHoriz = 0;
                    }
                }

                counter = 0;
            }
            else
            {
                counter++;
            }
        }

        /// <summary>
        /// draw the projectile
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, location, new Rectangle(PROJ_WIDTH * animationFrameHoriz, PROJ_HEIGHT * animationFrameVert, PROJ_WIDTH, PROJ_HEIGHT), Color.White);
        }
    }
}
