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
    enum SideOfObstacle { Left, Right, Top, Bottom, NoCollide };

    class Obstacles: StaticObjects
    {
        // attributes
        Texture2D texture;
        SideOfObstacle state;
        static SideOfObstacle prev;
        bool onTop = false;

        // constructor
        public Obstacles(int iWidth, int iHeight, Vector2 iLocation, Texture2D text)
        {
            this.width = iWidth;
            this.height = iHeight;
            this.location = iLocation;
            hitBox = new Rectangle((int)iLocation.X, (int)iLocation.Y, width, height);
            texture = text;
        }

        public void Update(GameTime gameTime, Player player)
        {
            bool isCollid = this.CheckCollision(player); // check if anything is colliding

            // character's location
            int xLoc = (int)player.Location.X;
            int yLoc = (int)player.Location.Y;


            WhereCollide(player); // check if the platform and character collides

            if (isCollid)
            {
                if (state == SideOfObstacle.Right)
                {
                    player.Location = new Vector2(player.Location.X + player.Speed, player.Location.Y);
                    player.Velocity = new Vector2(0f, player.Velocity.Y);
                }

                else if (state == SideOfObstacle.Left)
                {
                    player.Location = new Vector2(player.Location.X - player.Speed, player.Location.Y);
                    player.Velocity = new Vector2(0f, player.Velocity.Y);
                }

                else if (state == SideOfObstacle.Bottom)
                {
                    player.Location = new Vector2(player.Location.X, player.Location.Y + player.JumpHeight);
                    player.Velocity = new Vector2(player.Velocity.X, 0f);
                }

                else if (state == SideOfObstacle.Top)
                {
                    onTop = true;
                    player.Location = new Vector2(player.Location.X, hitBox.Y - player.HitBox.Height + 1);
                    player.HasJumped = false;
                    player.HasDoubleJumped = false;

                    if (player.Location.X + player.HitBox.Width < this.hitBox.X || player.Location.X > this.hitBox.X + this.hitBox.Width)
                    {
                        player.Position = player.InitialPos;
                        player.HasJumped = true;
                        //Console.WriteLine("Falling");
                    }
                }

                prev = state;
            }
            else
            {
                if (onTop == true)
                {
                    player.HasJumped = true;
                    //Console.Write("falling    ");
                    onTop = false;
                }
            }
            //Console.Write(player.HasJumped + "   ");
            //Console.Write(player.HasDoubleJumped + "   ");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
            //Console.WriteLine(state);

        }

        public SideOfObstacle WhereCollide(GameObjects go)
        {
            if (this.CheckCollision(go))
            {
                if (prev == SideOfObstacle.Top)
                {
                    for (int i = go.HitBox.X; i < go.HitBox.X + go.HitBox.Width; i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y + go.HitBox.Height))
                        {
                            state = SideOfObstacle.Top;
                            Console.WriteLine("Hit Top");
                            return state;
                        }
                    }
                    for (int i = go.HitBox.X + 20; i < go.HitBox.X + (go.HitBox.Width - 20); i++)
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
                }


                else
                {
                    for (int i = go.HitBox.X + 20; i < go.HitBox.X + (go.HitBox.Width - 20); i++)
                    {
                        if (this.hitBox.Contains(i, go.HitBox.Y + go.HitBox.Height))
                        {
                            state = SideOfObstacle.Top;
                            Console.WriteLine("Hit Top");
                            return state;
                        }
                    }
                    for (int i = go.HitBox.X + 20; i < go.HitBox.X + (go.HitBox.Width - 20); i++)
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
                }

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
