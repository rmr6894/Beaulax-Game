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
        private int jumpHeight; // may not need, not sure if enemies will jump...

        // constructor
        public Enemy()
        {
            health = 100;
            damage = 10;
            speed = 4;
            location = new Rectangle(0, 0, 100, 100);
        }

        public Enemy(int iHealth, int iDamage, int iSpeed, Rectangle iLocation)
        {
            health = iHealth;
            damage = iDamage;
            speed = iSpeed;
            location = iLocation;
        }
    }
}
