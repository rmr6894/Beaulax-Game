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
                }

                else if (state == SideOfObstacle.Left)
                {
                    player.Location= new Vector2(player.Location.X - player.Speed, player.Location.Y);
                }

                else if (state == SideOfObstacle.Bottom)
                {
                    player.Location = new Vector2(player.Location.X, player.Location.Y + player.JumpHeight);
                }

                else if (state == SideOfObstacle.Top)
                {
                    player.Location = new Vector2(player.Location.X, hitBox.Y - player.HitBox.Height);
                    player.HasJumped = false;

                    if (player.HitBox.X + player.HitBox.Width < this.hitBox.X || player.HitBox.X > this.hitBox.X + this.hitBox.Width)
                    {
                        player.Position = player.InitialPos;
                        player.HasJumped = true;
                    }
                }

                else if (state == SideOfObstacle.NoCollide)
                {
                    player.Location = player.Position;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
        }

        public SideOfObstacle WhereCollide(GameObjects go)
        {
            if (this.CheckCollision(go))
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
                for (int i = go.HitBox.X; i < go.HitBox.X + go.HitBox.Width; i++)
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
