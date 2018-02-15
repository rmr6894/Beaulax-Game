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

        private float floatX; // need this to set the vector for location later
        private float floatY; // need this to set the vector for location later

        // default contructor
        public SaveLoad()
        {
            flashlight = false;
            jumppack = false;
            spaceSuit = false;
            access = 0;
            locationX = 0;
            locationY = 0;
            floatX = 0.0f;
            floatY = 0.0f;
        }

        // methods

        /// <summary>
        /// This method saves the player's data to an external file, allowing them to reaccess it later.
        /// </summary>
        /// <param name="p"> takes in a player object and uses it's properties to save the current gamestate </param>
        public void Save(Player p)
        {
            flashlight = p.HasFlashlight;
            jumppack = p.HasJumppack;
            spaceSuit = p.HasSpacesuit;
            access = p.AccessLevel;
            locationX = (int)p.Location.X;
            locationY = (int)p.Location.Y;

            Stream outStream = File.OpenWrite("saveFile.data");

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

        /// <summary>
        /// Loads the previously saved
        /// </summary>
        /// <param name="p"></param>
        public void Load(Player p)
        {
            try
            {
                Stream inStream = File.OpenRead("saveFile.data");

                BinaryReader input = new BinaryReader(inStream);

                p.HasFlashlight = input.ReadBoolean();
                p.HasJumppack = input.ReadBoolean();
                p.HasSpacesuit = input.ReadBoolean();
                p.AccessLevel = input.ReadInt32();
                floatX = (float)input.ReadInt32();
                floatY = (float)input.ReadInt32();

                p.Location = new Vector2(floatX, floatY);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine("Warning: File Does Not Exist");
            }
        }
    }
}
