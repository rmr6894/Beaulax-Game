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
        }

        public Player(Texture2D sprite, bool ihasFlashlight, bool ihasJumpsuit, bool ihasSpacesuit, int iaccessLevel, float ispeed, float ijumpHeight, Vector2 ilocation)
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
            state = Keyboard.GetState();
            location += velocity;

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
                location.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }
            else if (state.IsKeyDown(Keys.W) && prevState.IsKeyUp(Keys.W) && hasJumped == true && hasJumppack == true && hasDoubleJumped == false)
            {
                location.Y -= 10f;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)location.X, (int)location.Y, 50, 74), Color.White);
        }
    }
}

