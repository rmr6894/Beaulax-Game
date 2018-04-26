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
    class Narratives : GameObjects
    {
        // attributes
        private string narrativeText;
        private SpriteFont font;

        // constructor
        public Narratives(string narrative)
        {
            narrativeText = narrative;
        }

        // methods
        /// <summary>
        /// Format story piece to fit dialogue box
        /// </summary>
        /// <returns></returns>
        public void formatNarrative()
        {
            
        }

        /// <summary>
        /// Draws story in box to screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="n"></param>
        public void DrawStory(SpriteBatch spriteBatch, Narratives n)
        {
            spriteBatch.Begin();
            // spriteBatch.DrawString(); // add font
            spriteBatch.End();
        }
    }
}
