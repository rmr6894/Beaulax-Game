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
    enum SideOfObstacle { Left, Right, Top, Bottom };

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

            if (isCollid)
            {
                WhereCollide(player); // check if the platform and character collides

                if (state == SideOfObstacle.Right)
                {
                    player.Position = new Vector2(player.Location.X + 1, player.Location.Y);
                }

                else if (state == SideOfObstacle.Left)
                {
                    player.Position = new Vector2(player.Location.X - 1, player.Location.Y);
                }

                else if (state == SideOfObstacle.Bottom)
                {
                    player.Position = new Vector2(player.Location.X, player.Location.Y + 1);
                }

                else if (state == SideOfObstacle.Top)
                {
                    player.Position = new Vector2(player.Location.X, hitBox.Y);

                    if (player.Position.X < this.hitBox.X || player.Position.X > this.hitBox.Width)
                    {
                        player.Position = player.InitialPos;
                    }
                }
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.Black);
        }

        public SideOfObstacle WhereCollide(GameObjects go)
        {
            if (this.CheckCollision(go))
            {
                for (int i = 0; i < go.HitBox.Height; i++)
                {
                    if (this.hitBox.Contains(go.HitBox.X + Width, i))
                    {
                        state = SideOfObstacle.Right;
                        return state;
                    }

                }
                for (int i = 0; i < go.HitBox.Height; i++)
                {
                    if (this.hitBox.Contains(go.HitBox.X, i))
                    {
                        state = SideOfObstacle.Left;
                        return state;
                    }

                }

                for (int i = 0; i < go.HitBox.Width; i++)
                {
                    if (this.hitBox.Contains(i, go.HitBox.Y + Height))
                    {
                        state = SideOfObstacle.Bottom;
                        return state;
                    }

                }
                for (int i = 0; i < go.HitBox.Width; i++)
                {
                    if (this.hitBox.Contains(i, go.HitBox.Y))
                    {
                        state = SideOfObstacle.Top;
                        return state;
                    }

                }

                return SideOfObstacle.Top;
            }
            else
            {
                return SideOfObstacle.Top;
            }
        }
    }
}
