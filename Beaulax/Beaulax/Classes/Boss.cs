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
        private Rectangle attackBox;
        private float jumpHeight; // may not need, not sure if enemies will jump...
        private Vector2 velocity;
        private int counterWhileDamaging = 0;
        private int atkSpeed;
        private bool takingDamage = false;
        private bool isAlive = true;
        
        // constructor
        public Boss (Player iPlayer, Texture2D sprite, int iHealth, int iDamage, Vector2 iLocation, int iWidth, int iHeight, int atkSpd)
        {
            player = iPlayer;
            enemySprite = sprite;
            health = iHealth;
            damage = iDamage;
            location = iLocation;
            width = iWidth;
            height = iHeight;
            atkSpeed = atkSpd;
        }

        // methods

        // attack
    }
}
