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
    class Characters: MovingObjects
    {
        //Common attributes
        private int health;
        private int damage;
        private Vector2 location;

        //Gets and Sets for attributes
        public int characterHealth { get { return health; } set { health = value; } }
        public int characterDamage { get { return damage; } set { damage = value; } }
        public Vector2 characterLocation { get { return location; } set { location = value; } }

        public Characters()
        {
            health = 0;
            damage = 0;
            location = new Vector2(1, 1);
        }

        public Characters(int h, int d, Vector2 v)
        {
            health = h;
            damage = d;
            location = v;
        }

        public override string ToString()
        {
            return "Health: " + health + "; Damage: " + damage + "; Location: (" + location.X + ", " + location.Y + ")";
        }


    }
}
