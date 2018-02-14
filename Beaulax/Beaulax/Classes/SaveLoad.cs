using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Beaulax.Classes
{
    class SaveLoad
    {
        // attributes
        private bool flashlight;
        private bool jumppack;
        private bool spaceSuit;
        private int access;
        private Vector2 location;

        // default contructor
        public SaveLoad()
        {
            flashlight = false;
            jumppack = false;
            spaceSuit = false;
            access = 0;
            location = new Vector2(0,0);
        }

        // methods

        /// <summary>
        /// Allows you to save the various states of the game.
        /// </summary>
        /// <param name="flash"></param>
        /// <param name="jump"></param>
        /// <param name="suit"></param>
        /// <param name="acc"></param>
        /// <param name="loc"></param>
        public void Save(bool flash, bool jump, bool suit, int acc, Vector2 loc)
        {
            flashlight = flash;
            jumppack = jump;
            spaceSuit = suit;
            access = acc;
            location = loc;

            Stream outStream = File.OpenWrite("save.data");

            BinaryWriter output = new BinaryWriter(outStream);

            output.Write(flashlight);
            output.Write(jumppack);
            output.Write(spaceSuit);
            output.Write(access);
            output.Write(location);

            output.Close();

            Console.WriteLine("Save complete");
        }

        public void Load(Player c)
        {
            Stream inStream = File.OpenRead("save.data");

            BinaryReader input = new BinaryReader(inStream);

            c.HasFlashlight = input.ReadBoolean();
            c.HasJumppack = input.ReadBoolean();
            c.HasSpacesuit = input.ReadBoolean();
            c.AccessLevel = input.ReadInt32();
            c.Location = input.ReadInt32();

            Console.WriteLine(c);
        }
    }
}
