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
    class Door : GameObjects
    {
        // attributes
        protected string ID; // ID of the room it leads to
        protected int accessLevel; // checks the access key the player has
        protected Texture2D door;

        // constructor
        public Door(string id, int accessLevel, Rectangle location, Texture2D text)
        {
            ID = id;
            this.accessLevel = accessLevel;
            this.hitBox = location;
            door = text;
        }

        // methods
        /// <summary>
        /// returns the ID of the room the door leads to. Will return -1 if player does not have proper access.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public void EnterDoor(Player player, Game1 game)
        {
            if (player.HitBox.Intersects(this.hitBox))
            {
                if (player.AccessLevel == accessLevel)
                {
                    Console.WriteLine("Player in Door! To Room " + ID);
                    game.ReadMap(ID);
                }

            }

        }

        /// <summary>
        /// Draws in the door onto the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(door, this.hitBox, color);
        }

    }
}
