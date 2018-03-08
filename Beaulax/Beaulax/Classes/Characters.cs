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
        protected int health;
        protected int damage;
        protected float speed;

        //Gets and Sets for attributes
        public int CharacterHealth { get { return health; } set { health = value; } }
        public int CharacterDamage { get { return damage; } set { damage = value; } }
        public Vector2 CharacterLocation { get { return location; } set { location = value; } }

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

        public virtual string ToString()
        {
            return "Health: " + health + "; Damage: " + damage + "; Location: (" + location.X + ", " + location.Y + ")";
        }


    }
}
