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
        private Rectangle attackBox;
        private float jumpHeight; // may not need, not sure if enemies will jump...
        private int width;
        private int height;
        private int direction = 1;
        private int counterWhileStill = 0;
        private int counterWhileMoving = 0;
        private int timesToMoveBySpeed = 30;
        private int cyclesToStandStill = 55;
        private int counterWhileDamaging = 0;
        private int atkRange;
        private int atkSpeed;

        // constructor
        public Enemy()
        {
            health = 100;
            damage = 10;
            speed = 4f;
            location = new Vector2(0, 0);
            width = 50;
            height = 74;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
            atkRange = 250;
            atkSpeed = 20;
        }

        public Enemy(Player iPlayer, Texture2D sprite, int iHealth, int iDamage, float iSpeed, Vector2 iLocation, int iWidth, int iHeight, int atkRng, int atkSpd)
        {
            player = iPlayer;
            enemySprite = sprite;
            health = iHealth;
            damage = iDamage;
            speed = iSpeed;
            location = iLocation;
            width = iWidth;
            height = iHeight;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
            atkRange = atkRng;
            atkSpeed = atkSpd;
        }

        // parameters
        public int Health { get { return health; } set { health = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public float JumpHeight { get { return jumpHeight; } set { jumpHeight = value; } }
        public int AtkRange { get { return atkRange; } set { atkRange = value; } }

        public void Movement()
        {
            // if the player is within a certain range of the enemy then the enemy moves towards the player at full speed
            if (Math.Abs(player.Location.X - location.X) <= atkRange)
            {
                // if the player is to the right of the enemy then move the enemy right
                if (player.Location.X - location.X > 30)
                {
                    location.X += speed;
                }
                // if the player is to the left of the enemy then move the enemy left
                else if (player.Location.X - location.X < -30)
                {
                    location.X -= speed;
                }
            }
            // otherwise move the enemy randomly
            else
            {
                Random rng = new Random();

                // while moving
                if (counterWhileStill >= cyclesToStandStill && counterWhileMoving <= timesToMoveBySpeed)
                {
                    if (counterWhileMoving == timesToMoveBySpeed)
                    {
                        cyclesToStandStill = rng.Next(40, 70);
                        counterWhileStill = 0;
                    }
                    location.X += (direction * (speed / 2));
                    counterWhileMoving++;
                }
                // while still
                else
                {
                    // randomly pick a direction. -1 for left, 1 for right
                    direction = rng.Next(0, 2);
                    if (direction == 0)
                    {
                        direction = -1;
                    }

                    // randomly pick a number of times that the enemy will move by the speed value
                    timesToMoveBySpeed = rng.Next(10, 50);

                    // update the counters
                    counterWhileMoving = 0;
                    counterWhileStill++;
                }                
            }
            // update the hitbox location
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Attack()
        {
                // if the player is to the right of the enemy then move the enemy right
                if (player.Location.X - location.X > 0)
                {
                    attackBox = new Rectangle((int)(location.X + width / 4), (int)location.Y, width, height);
                }
                // if the player is to the left of the enemy then move the enemy left
                else if (player.Location.X - location.X < 0)
                {
                    attackBox = new Rectangle((int)(location.X - width / 4), (int)location.Y, width, height);
                }

            // if the attack hits the player then the player takes damage
            if (attackBox.Intersects(player.HitBox))
            {
                if (counterWhileDamaging >= atkSpeed)
                {
                    counterWhileDamaging = 0;
                    player.TakeDamage(damage, this);
                }
                else
                {
                    counterWhileDamaging++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemySprite, hitBox, Color.White);
            spriteBatch.Draw(enemySprite, attackBox, Color.Red);
        }
    }
}
