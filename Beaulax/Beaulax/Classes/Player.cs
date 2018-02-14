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
    class Player: Characters
    {
        // saving attributes
        private bool hasFlashlight;
        private bool hasJumppack;
        private bool hasSpacesuit;
        private int accessLevel;

        // constructors
        public Character()
        {
            hasFlashlight = false;
            hasJumppack = false;
            hasSpacesuit = false;
            accessLevel = 0;
            location = 0;
        }

        public Character(bool ihasFlashlight, bool ihasJumpsuit, bool ihasSpacesuit, int iaccessLevel, int ilocation)
        {
            hasFlashlight = ihasFlashlight;
            hasJumppack = ihasJumpsuit;
            hasSpacesuit = ihasSpacesuit;
            accessLevel = iaccessLevel;
            location = ilocation;
        }

        // properties
        public bool HasFlashlight { get { return hasFlashlight; } set { hasFlashlight = value; } }
        public bool HasJumppack { get { return hasJumppack; } set { hasJumppack = value; } }
        public bool HasSpacesuit { get { return hasSpacesuit; } set { hasSpacesuit = value; } }
        public int AccessLevel { get { return accessLevel; } set { accessLevel = value; } }
        public int Location { get { return location; } set { location = value; } }

        // method
        public override string ToString()
        {
            return "Flashlight: " + hasFlashlight + "\nJumppack: " + hasJumppack + "\nSpacesuit: " + hasSpacesuit + "\nAccess Level: " + accessLevel + "\nLocation: " + location;
        }
    }
}
