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
    class Boss : Enemy
    {
        // attributes
        private Player player;
        private Texture2D enemySprite;
        private Texture2D projText;
        private int atkSpeed; // how much time is between each boss's shots (in frames)
        private int counter; // keeps track of the time

        // attack attributes
        private bool isShoot;
        private List<Projectile> proj;

        //animation attributes
        private double timePerFrame = 100; //ms
        private int totalFrames = 7;
        protected const int BOSS_HEIGHT = 604;
        protected const int BOSS_WIDTH = 624;
        private int currentFrame;
        private int framesElapsed;

        // constructor
        public Boss (Player iPlayer, Texture2D sprite, Texture2D projSprite, int iHealth, int iDamage, Vector2 iLocation, int iWidth, int iHeight, int atkSpd)
        {
            player = iPlayer;
            enemySprite = sprite;
            projText = projSprite;
            health = iHealth;
            damage = iDamage;
            location = iLocation;
            width = iWidth;
            height = iHeight;
            this.hitBox = new Rectangle((int)location.X, (int)location.Y, iWidth, iHeight);
            atkSpeed = atkSpd;
            counter = atkSpd;
            proj = new List<Projectile>();
        }

        // methods

        /// <summary>
        /// The ProjectileAttack method launches a projectile attack in the player's direction based on a linear equation. The 
        /// projectile is fired from the center of the enemy, and has a cool down time of atkSpeed.
        /// </summary>
        public void ProjectileAttack()
        {
            if (isAlive)
            {
                if (counter == 0)
                {
                    float playerPos = player.Location.X + (player.HitBox.Height / 2);
                    float prjctlOrigin = this.location.X + (this.height / 2);

                    Vector2 projectDirection = new Vector2(playerPos - prjctlOrigin, player.Location.Y - this.location.Y);
                    double pDNorm = Math.Sqrt((projectDirection.X * projectDirection.X) + (projectDirection.Y * projectDirection.Y));

                    projectDirection = new Vector2(10 * (projectDirection.X / (float)pDNorm),  10 * (projectDirection.Y / (float)pDNorm));

                    proj.Add(new Projectile(128, 128, new Vector2(prjctlOrigin, this.Location.Y), player, 10, projectDirection, projText));

                    counter = atkSpeed;
                }
                else
                {
                    counter--;
                }
            }
        }

        /*public void BossTakeDamage(int damage)
        {
            if (health > 0)
            {
                if (this.hitBox.Intersects(player.AttackBox))
                {
                    health -= damage;
                    takingDamage = true;
                }
            }
            else if (health < 0)
            {
                health = 0;
            }
            else if (health == 0)
            {
                isAlive = false;
            }
        }*/

        public override void Update(GameTime gameTime)
        {
            if (this.hitBox.Intersects(player.HitBox))
            {
                
                    player.TakeDamage(1);
                
            }

            //this.BossTakeDamage(player.Damage);
            this.ProjectileAttack();

            if (proj.Count > 0)
            {
                for (int i = 0; i < proj.Count; i++)
                {
                    proj[i].Update(gameTime);

                    if (proj[i].Location.X < 0)
                    {
                        proj.Remove(proj[i]);
                    }
                }
            }

            //Animation
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            currentFrame = framesElapsed % totalFrames + 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                // draw the boss
                if (takingDamage && isAlive)
                {
                    spriteBatch.Draw(enemySprite, new Vector2((int)location.X, (int)location.Y), new Rectangle(BOSS_WIDTH * currentFrame, 0, BOSS_WIDTH, BOSS_HEIGHT), Color.Red, 0, Vector2.Zero, (float)1, SpriteEffects.None, 0);
                    takingDamage = false;
                }
                else
                {
                    spriteBatch.Draw(enemySprite, new Vector2((int)location.X, (int)location.Y), new Rectangle(BOSS_WIDTH * currentFrame, 0, BOSS_WIDTH, BOSS_HEIGHT), Color.White, 0, Vector2.Zero, (float)1, SpriteEffects.None, 0);
                }

                //spriteBatch.Draw(enemySprite, hitBox, Color.Red);

                // draw the projectiles
                if (proj.Count > 0)
                {
                    for (int i = 0; i < proj.Count; i++)
                    {
                        proj[i].Draw(spriteBatch);
                    }
                }
            }

        }
    }
}
