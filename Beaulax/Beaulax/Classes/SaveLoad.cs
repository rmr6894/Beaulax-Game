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
        private bool hasJumped;

        // default contructor
        public SaveLoad()
        {
            flashlight = false;
            jumppack = false;
            spaceSuit = false;
            access = 0;
            locationX = 0;
            locationY = 0;
            hasJumped = false;
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
            hasJumped = p.HasJumped;

            Stream outStream = File.OpenWrite("saveFile.data");

            BinaryWriter output = new BinaryWriter(outStream);

            output.Write(flashlight);
            output.Write(jumppack);
            output.Write(spaceSuit);
            output.Write(access);
            output.Write(locationX);
            output.Write(locationY);
            output.Write(hasJumped);

            outStream.Close();

            Console.WriteLine("Save complete");
        }

        /// <summary>
        /// Loads the previously saved
        /// </summary>
        /// <param name="p"></param>
        public void Load(Player p)
        {
            
            Stream inStream;

            try
            {
                inStream = File.OpenRead("saveFile.data");

                BinaryReader input = new BinaryReader(inStream);

                p.HasFlashlight = input.ReadBoolean();
                p.HasJumppack = input.ReadBoolean();
                p.HasSpacesuit = input.ReadBoolean();
                p.AccessLevel = input.ReadInt32();
                locationX = input.ReadInt32();
                locationY = input.ReadInt32();
                p.HasJumped = input.ReadBoolean();

                p.Location = new Rectangle(locationX, locationY, p.Location.Width, p.Location.Height);
                Console.WriteLine(p);

                inStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Warning: File Does Not Exist");
            }
        }
    }
}
