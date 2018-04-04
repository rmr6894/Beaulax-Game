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
    class Door
    {
        // attributes
        protected int ID; // ID of the room it leads to
        protected int accessLevel; // checks the access key the player has
        protected Rectangle doorLocation; // where in the room will this door be drawn

        // constructor
        public Door(int id, int accessLevel, Rectangle location)
        {
            ID = id;
            this.accessLevel = accessLevel;
            doorLocation = location;
        }

        // methods
        /// <summary>
        /// returns the ID of the room the door leads to. Will return -1 if player does not have proper access.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int EnterDoor(Player player)
        {
            if (player.HitBox.Intersects(doorLocation))
            {
                if (player.AccessLevel == accessLevel)
                {
                    Console.WriteLine("Player in Door! To Room " + ID);
                    return ID;
                }

                return -1;
            }

            return -1;
        }

    }
}
