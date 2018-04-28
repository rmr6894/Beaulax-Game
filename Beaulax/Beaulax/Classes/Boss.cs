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
        private bool takingDamage = false;
        private bool isAlive = true;

        // attack attributes
        private bool isShoot;
        private List<Projectile> proj;
        
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

                    projectDirection = new Vector2(8 * (projectDirection.X / (float)pDNorm),  8 * (projectDirection.Y / (float)pDNorm));

                    proj.Add(new Projectile(128, 128, new Vector2(prjctlOrigin, this.Location.Y), player, 5, projectDirection, projText));

                    counter = atkSpeed;
                }
                else
                {
                    counter--;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.hitBox.Intersects(player.HitBox))
            {
                if (atkSpeed % 2 == 1)
                {
                    player.TakeDamage(1);
                }
            }

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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                // draw the boss
                spriteBatch.Draw(enemySprite, new Vector2((int)location.X, (int)location.Y), new Rectangle(0, 0, ENEMY_WIDTH, ENEMY_HEIGHT), Color.White, 0, Vector2.Zero, (float)0.5, SpriteEffects.None, 0);

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
