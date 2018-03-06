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
        private Vector2 velocity;
        private bool hasJumped;
        private bool hasDoubleJumped;
        private Vector2 initialLocation;
        private float jumpHeight;
        private int width;
        private int height;
        Rectangle hitBox;
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

        public Player(Texture2D sprite, bool ihasFlashlight, bool ihasJumpsuit, bool ihasSpacesuit, int iaccessLevel, float ispeed, float ijumpHeight, Vector2 ilocation, int iWidth, int iHeight)
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
            health = 100;
        }

        // properties
        public bool HasFlashlight { get { return hasFlashlight; } set { hasFlashlight = value; } }
        public bool HasJumppack { get { return hasJumppack; } set { hasJumppack = value; } }
        public bool HasSpacesuit { get { return hasSpacesuit; } set { hasSpacesuit = value; } }
        public int AccessLevel { get { return accessLevel; } set { accessLevel = value; } }
        public Vector2 Location { get { return location; } set { location = value; } }
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public bool HasJumped { get { return hasJumped; } set { hasJumped = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public float JumpHeight { get { return jumpHeight; } set { jumpHeight = value; } }
        public Rectangle HitBox { get { return hitBox; } }

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

        /// <summary>
        /// Dameges the player by a certain number.
        /// </summary>
        /// <param name="damage">amount of damage that the player takes</param>
        public void TakeDamage(int damage)
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

