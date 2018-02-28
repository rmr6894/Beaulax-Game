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
    class Enemy: Characters
    {
        // attributes
        private Player player;
        private Texture2D enemySprite;
        private int jumpHeight; // may not need, not sure if enemies will jump...

        // constructor
        public Enemy()
        {
            health = 100;
            damage = 10;
            speed = 4f;
            location = new Vector2(0, 0);
        }

        public Enemy(Player iPlayer, Texture2D sprite, int iHealth, int iDamage, float iSpeed, Vector2 iLocation)
        {
            player = iPlayer;
            enemySprite = sprite;
            health = iHealth;
            damage = iDamage;
            speed = iSpeed;
            location = iLocation;
        }

        public void Movement()
        {
            // if the player is within a certain range of the enemy then the enemy moves towards the player
            if (Math.Abs(player.Location.X - location.X) <= 300)
            {
                // add code for moving the enemy towards the player
            }
            // otherwise move the enemy randomly
            else
            {
                int direction = 0;
                int moveDistance = 0;
                Random rng = new Random();

                moveDistance = rng.Next(0, 5);

                // randomly pick a direction. -1 for left, 1 for right
                direction = rng.Next(0, 1);
                if (direction == 0)
                {
                    direction = -1;
                }

                // move by the speed a random number of times
                for (int i = 0; i < moveDistance; i++)
                {
                    location.X += (direction * speed);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemySprite, new Rectangle((int)location.X, (int)location.Y, 50, 74), Color.White);
        }
    }
}
