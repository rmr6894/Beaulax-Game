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
    enum SideThatHitTheThing { Left, Right, Top, Bottom };

    class Obstacles: StaticObjects
    {
        // attributes
        Texture2D texture;

        // constructor
        public Obstacles(int iWidth, int iHeight, Vector2 iLocation, Texture2D text)
        {
            this.width = iWidth;
            this.height = iHeight;
            this.location = iLocation;
            hitBox = new Rectangle((int)iLocation.X, (int)iLocation.Y, width, height);
            texture = text;
        }

        public void Update(GameTime gameTime, Characters chars)
        {
            bool isCollid = this.CheckCollision(chars); // check if anything is colliding

            if (isCollid)
            {
                WhereCollide(chars); // if it is collide, tehn do the thsi check thing?
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.Black);
        }

        public SideThatHitTheThing WhereCollide(GameObjects go)
        {
            if (this.CheckCollision(go))
            {
                for (int i = 0; i < go.HitBox.Height; i++)
                {
                    if (this.hitBox.Contains(go.HitBox.X + Width, i))
                    {
                        return SideThatHitTheThing.Right;
                    }

                }
                for (int i = 0; i < go.HitBox.Height; i++)
                {
                    if (this.hitBox.Contains(go.HitBox.X, i))
                    {
                        return SideThatHitTheThing.Left;
                    }

                }

                for (int i = 0; i < go.HitBox.Width; i++)
                {
                    if (this.hitBox.Contains(i, go.HitBox.Y + Height))
                    {
                        return SideThatHitTheThing.Bottom;
                    }

                }
                for (int i = 0; i < go.HitBox.Width; i++)
                {
                    if (this.hitBox.Contains(i, go.HitBox.Y))
                    {
                        return SideThatHitTheThing.Top;
                    }

                }

                return SideThatHitTheThing.Top;
            }
            else
            {
                return SideThatHitTheThing.Top;
            }
        }
    }
}
