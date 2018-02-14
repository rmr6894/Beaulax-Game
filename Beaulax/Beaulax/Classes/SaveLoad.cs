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
        private int locationX;
        private int locationY;

        // default contructor
        public SaveLoad()
        {
            flashlight = false;
            jumppack = false;
            spaceSuit = false;
            access = 0;
            locationX = 0;
            locationY = 0;
        }

        // methods

        /// <summary>
        /// This method saves the player's data to an external file, allowing them to reaccess it later.
        /// </summary>
        /// <param name="p"></param>
        public void Save(Player p)
        {
            flashlight = p.HasFlashlight;
            jumppack = p.HasJumppack;
            spaceSuit = p.HasSpacesuit;
            access = p.AccessLevel;
            locationX = p.Location;
            locationY = p.Location;

            Stream outStream = File.OpenWrite("save.data");

            BinaryWriter output = new BinaryWriter(outStream);

            output.Write(flashlight);
            output.Write(jumppack);
            output.Write(spaceSuit);
            output.Write(access);
            output.Write(locationX);
            output.Write(locationY);

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
