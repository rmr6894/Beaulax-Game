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
        SideOfObstacle state; // for collision with the door
        Color color;


        // constructor
        public Door(string id, int accessLevel, Rectangle location, Texture2D text, Color col)
        {
            ID = id;
            this.accessLevel = accessLevel;
            this.hitBox = location;
            door = text;
            color = col;
        }

        // methods
        /// <summary>
        /// returns the ID of the room the door leads to. Will return -1 if player does not have proper access.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public void EnterDoor(Player player, Game1 game)
        {
            bool isCollid = this.CheckCollision(player); // check if anything is colliding

            WhereCollide(player); // check if the door and character collides

            if (player.HitBox.Intersects(this.hitBox))
            {
                if (player.AccessLevel >= accessLevel)
                {
                    Console.WriteLine("Player in Door! To Room " + ID);
                    game.ReadMap(ID);
                    game.wasPlayerRoom = ID;
                }

                else
                {
                    if (isCollid)
                    {
                        if (state == SideOfObstacle.Right)
                        {
                            player.Location = new Vector2(player.Location.X + player.Speed, player.Location.Y);
                        }

                        else if (state == SideOfObstacle.Left)
                        {
                            player.Location = new Vector2(player.Location.X - player.Speed, player.Location.Y);
                        }
                    }
                }

            }

        }

        /// <summary>
        /// Draws in the door onto the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(door, this.hitBox, color);
        }

        public SideOfObstacle WhereCollide(GameObjects go)
        {
            if (this.CheckCollision(go))
            {
                //if (prev == SideOfObstacle.Top)
                //{
                    /*for (int i = go.HitBox.X; i < go.HitBox.X + go.HitBox.Width; i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y + go.HitBox.Height))
                        {
                            state = SideOfObstacle.Top;
                            Console.WriteLine("Hit Top");
                            return state;
                        }
                    }
                    for (int i = go.HitBox.X + 2; i < go.HitBox.X + (go.HitBox.Width - 2); i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y))
                        {
                            state = SideOfObstacle.Bottom;
                            return state;
                        }

                    }*/
                    for (int i = go.HitBox.Y; i < go.HitBox.Y + go.HitBox.Height; i++)
                    {
                        if (this.hitBox.Contains(go.HitBox.X, i))
                        {
                            state = SideOfObstacle.Right;
                            return state;
                        }

                    }
                    for (int i = go.HitBox.Y; i < go.HitBox.Y + go.HitBox.Height; i++)
                    {
                        if (this.hitBox.Contains(go.HitBox.X + go.HitBox.Width, i))
                        {
                            state = SideOfObstacle.Left;
                            return state;
                        }

                    }
                //}


                /*else
                {
                    for (int i = go.HitBox.X + 2; i < go.HitBox.X + (go.HitBox.Width - 2); i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y + go.HitBox.Height))
                        {
                            state = SideOfObstacle.Top;
                            Console.WriteLine("Hit Top");
                            return state;
                        }
                    }
                    for (int i = go.HitBox.X + 2; i < go.HitBox.X + (go.HitBox.Width - 2); i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y))
                        {
                            state = SideOfObstacle.Bottom;
                            return state;
                        }

                    }
                    for (int i = go.HitBox.Y; i < go.HitBox.Y + go.HitBox.Height; i++)
                    {
                        if (this.hitBox.Contains(go.HitBox.X, i))
                        {
                            state = SideOfObstacle.Right;
                            return state;
                        }

                    }
                    for (int i = go.HitBox.Y; i < go.HitBox.Y + go.HitBox.Height; i++)
                    {
                        if (this.hitBox.Contains(go.HitBox.X + go.HitBox.Width, i))
                        {
                            state = SideOfObstacle.Left;
                            return state;
                        }

                    }
                }*/

                state = SideOfObstacle.NoCollide;
                return state;
            }
            else
            {
                state = SideOfObstacle.NoCollide;
                return state;
            }
        }
    }
}
