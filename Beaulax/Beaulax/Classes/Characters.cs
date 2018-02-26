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

        //Gets and Sets for attributes
        public int CharacterHealth { get { return health; } set { health = value; } }
        public int CharacterDamage { get { return damage; } set { damage = value; } }
        public Rectangle CharacterLocation { get { return location; } set { location = value; } }

        public Characters() : base(new Rectangle(1, 1, 100, 100), 5)
        {
            health = 0;
            damage = 0;
        }

        public Characters(int h, int d, Rectangle r, int iSpeed) : base(r, iSpeed)
        {
            health = h;
            damage = d;
            location = r;
        }

        public override string ToString()
        {
            return "Health: " + health + "; Damage: " + damage + "; Location: (" + location.X + ", " + location.Y + ")";
        }


    }
}
