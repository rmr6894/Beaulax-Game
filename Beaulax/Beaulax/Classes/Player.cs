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
    class Player : Characters
    {
        // saving attributes
        private bool hasFlashlight;
        private bool hasJumppack;
        private bool hasSpacesuit;
        private int accessLevel;
        private Texture2D sprite;
        private Texture2D laser;
        private Vector2 velocity;
        private bool hasJumped;
        private bool hasDoubleJumped;
        private Vector2 initialLocation;
        private float jumpHeight;
<<<<<<< HEAD
=======
        private int width;
        private int height;
        Rectangle hitBox;
        Rectangle attackBox;
        private float laserRotation = 0f;
        private bool firingLaser = false;
>>>>>>> 6a60018bd01758af2536c2469570eb76d6ea8006
        private bool takingDamage = false;

        // defining states
        KeyboardState state; // moved up here for easier use/// gives the current state of pressed keys
        KeyboardState prevState;  // will give the precious state of pressed keys

        // constructors
        public Player()
        {
            hasFlashlight = false;
            hasJumppack = false;
            hasSpacesuit = false;
            accessLevel = 0;
            location = new Vector2(0, 0);
            hasJumped = true;
            hasDoubleJumped = true;
            speed = 3f;
            jumpHeight = 10f;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
            health = 100;
        }

        public Player(Texture2D sprite, Texture2D laserBeam, bool ihasFlashlight, bool ihasJumpsuit, bool ihasSpacesuit, int iaccessLevel, float ispeed, float ijumpHeight, Vector2 ilocation, int iWidth, int iHeight)
        {
            hasFlashlight = ihasFlashlight;
            hasJumppack = ihasJumpsuit;
            hasSpacesuit = ihasSpacesuit;
            accessLevel = iaccessLevel;
            location = ilocation;
            initialLocation = ilocation;
            hasJumped = true;
            hasDoubleJumped = true;
            this.sprite = sprite;
            speed = ispeed;
            jumpHeight = ijumpHeight;
            width = iWidth;
            height = iHeight;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
            laser = laserBeam;
            health = 100;
        }

        // properties
        public bool HasFlashlight { get { return hasFlashlight; } set { hasFlashlight = value; } }
        public bool HasJumppack { get { return hasJumppack; } set { hasJumppack = value; } }
        public bool HasSpacesuit { get { return hasSpacesuit; } set { hasSpacesuit = value; } }
        public int AccessLevel { get { return accessLevel; } set { accessLevel = value; } }
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public bool HasJumped { get { return hasJumped; } set { hasJumped = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public float JumpHeight { get { return jumpHeight; } set { jumpHeight = value; } }

        // method
        public override string ToString()
        {
            return "Flashlight: " + hasFlashlight + "\nJumppack: " + hasJumppack + "\nSpacesuit: " + hasSpacesuit + "\nAccess Level: " + accessLevel + "\nLocation: " + location;
        }

        /// <summary>
        /// Allows player input to be read so the sprite can move and jump
        /// </summary>
        public void Movement()
        {
            state = Keyboard.GetState(); // moved location change to update

            if (state.IsKeyDown(Keys.D) && state.IsKeyUp(Keys.A)) // move player right
            {
                velocity.X = speed;
            }

            else if (state.IsKeyDown(Keys.A) && state.IsKeyUp(Keys.D)) // move player left
            {
                velocity.X = -speed;
            }

            else // makes sure player does not move if there is no input
            {
                velocity.X = 0f;
            }

            if (state.IsKeyDown(Keys.W) && hasJumped == false) // initiates jump if the player is on the ground and W is pressed
            {
                location.Y -= jumpHeight;
                velocity.Y = -5f;
                hasJumped = true;
            }
            else if (state.IsKeyDown(Keys.W) && prevState.IsKeyUp(Keys.W) && hasJumped == true && hasJumppack == true && hasDoubleJumped == false) // double jump: checks if the player presses w a second time, ensures they have the jumppack and haven't already double-jumped
            {
                location.Y -= 5f;
                velocity.Y = -5f;
                hasDoubleJumped = true;
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i; // acceleration
            }

            if (location.Y >= initialLocation.Y) // sets boolean back to false and the landing Y coordinate to initial Y position
            {
                hasJumped = false;
                hasDoubleJumped = false;
                location.Y = initialLocation.Y;
            }

            if (hasJumped == false) // makes sure the sprite does not move passed the floor
            {
                velocity.Y = 0f;
            }

            prevState = state;
        }

        public void Attack(Enemy enemy)
        {
            state = Keyboard.GetState();

            attackBox = new Rectangle(hitBox.X + (hitBox.Width / 2), hitBox.Y + (hitBox.Height / 2), 800, 30);

            // do nothing if both right and left are pressed
            if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Left)) { firingLaser = false; }
            // do nothing if both up and down are pressed
            else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Down)) { firingLaser = false; }
            // shoot diagonally up right
            if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Up))
            {
                laserRotation = (7 * (float)Math.PI) / 4;
                firingLaser = true;
            }
            // shoot diagonally down right
            else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Down))
            {
                laserRotation = (float)Math.PI / 4;
                firingLaser = true;
            }
            // shoot diagonally up left
            else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Up))
            {
                laserRotation = (5 * (float)Math.PI) / 4;
                firingLaser = true;
            }
            // shoot diagonally down left
            else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Down))
            {
                laserRotation = (3 * (float)Math.PI) / 4;
                firingLaser = true;
            }
            // shoot right
            else if (state.IsKeyDown(Keys.Right))
            {
                laserRotation = 0f;
                firingLaser = true;
            }
            // shoot left
            else if (state.IsKeyDown(Keys.Left))
            {
                laserRotation = (float)Math.PI;
                firingLaser = true;
            }
            // shoot up
            else if (state.IsKeyDown(Keys.Up))
            {
                laserRotation = (3 * (float)Math.PI) / 2;
                firingLaser = true;
            }
            // shoot down
            else if (state.IsKeyDown(Keys.Down))
            {
                laserRotation = (float)Math.PI / 2;
                firingLaser = true;
            }
            // if nothing is pressed then the player is not firing the laser
            else
            {
                firingLaser = false;
            }
        }

        /// <summary>
        /// Dameges the player by a certain number.
        /// </summary>
        /// <param name="damage">amount of damage that the player takes</param>
        public void TakeDamage(int damage, Enemy enemy)
        {
            if (health > 0)
            {
                health -= damage;
            }
            if (health < 0)
            {
                health = 0;
            }
            takingDamage = true;
        }

        public void Update(GameTime gameTime)
        {
            location += velocity;
            hitBox = new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // if the player is shooting then draw the laser
            if (firingLaser)
            {
                spriteBatch.Draw(laser, attackBox, new Rectangle(0, 0, laser.Width, laser.Height), Color.White, laserRotation, new Vector2(0, laser.Height / 2), SpriteEffects.None, 0);
            }

            // if the player is taking damage then they turn red
            if (takingDamage)
            {
                spriteBatch.Draw(sprite, hitBox, Color.Red);
                takingDamage = false;
            }
            // if the player is not taking damage then draw them normally
            else
            {
                spriteBatch.Draw(sprite, hitBox, Color.White);
            }
        }
    }
}

