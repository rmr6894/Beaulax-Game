using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExternalTool_CharacterEditor
{
    public partial class Form1 : Form
    {

        // attributes: easier to save to files.
        public float pSpeed, eSpeed;
        public int pDamage, eDamage;
        public int pHealth, eHealth;
        public int pJumpHeight, eJumpHeight;
        public bool hasJumpPack;
        public bool hasFlashLight;
        public bool hasSpaceSuit;
        public int accessLevel;

        public Form1()
        {
            InitializeComponent();
        }

        // ignore this
        private void label8_Click(object sender, EventArgs e)
        {

        }

        // ignore this
        private void progressBar7_Click(object sender, EventArgs e)
        {

        }


        private void playerSpeed_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((playerSpeed.Value / playerSpeed.Maximum) * 100);
            playerSpeedProgress.Value = level;
        }

        private void playerJump_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((playerJump.Value / playerJump.Maximum) * 100);
            playerJumpProgress.Value = level;
        }

        private void playerDamage_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((playerDamage.Value / playerDamage.Maximum) * 100);
            playerDamageProgress.Value = level;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((playerHealth.Value / playerHealth.Maximum) * 100);
            playerHealthProgress.Value = level;
        }

        private void enemySpeed_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((enemySpeed.Value / enemySpeed.Maximum) * 100);
            enemySpeedProgress.Value = level;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((enemyJump.Value / enemyJump.Maximum) * 100);
            enemyJumpProgress.Value = level;
        }

        private void enemyDamage_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((enemyDamage.Value / enemyDamage.Maximum) * 100);
            enemyDamageProgress.Value = level;
        }

        private void enemyHealth_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((enemyHealth.Value / enemyHealth.Maximum) * 100);
            enemyHealthProgress.Value = level;
        }

        // saving player stats
        private void savePlayer_Click(object sender, EventArgs e)
        {
            pHealth = (int)playerHealth.Value; // set the stats
            pDamage = (int)playerDamage.Value;
            pSpeed = (int)playerSpeed.Value;
            pJumpHeight = (int)playerJump.Value;

            if (levelOne.Checked) // set the access level
            {
                accessLevel = 1;
            }
            if (levelTwo.Checked)
            {
                accessLevel = 2;
            }
            if (levelThree.Checked)
            {
                accessLevel = 3;
            }
            if (levelFour.Checked)
            {
                accessLevel = 4;
            }
            if (levelFive.Checked)
            {
                accessLevel = 5;
            }

            if (jumpPackCheck.Checked) // checks the Jump Pack button
            {
                hasJumpPack = true;
            }
            else
            {
                hasJumpPack = false;

            }
            if (flashlightCheck.Checked) // checks the FlashLight button
            {
                hasFlashLight = true;
            }
            else
            {
                hasFlashLight = false;

            }
            if (spaceSuitCheck.Checked) // checks the SpaceSuit button
            {
                hasSpaceSuit = true;
            }
            else
            {
                hasSpaceSuit = false;
            }

            Console.WriteLine(pHealth + " " + pDamage + " " + pSpeed + " " + pJumpHeight + " " + accessLevel + " " + hasJumpPack + " " + hasFlashLight + " " + hasSpaceSuit);

            // write data out to save file

            Stream outStream = File.OpenWrite("playerSave.data"); 

            BinaryWriter output = new BinaryWriter(outStream);

            output.Write(pHealth);
            output.Write(pDamage);
            output.Write(pSpeed);
            output.Write(pJumpHeight);
            output.Write(accessLevel);
            output.Write(hasJumpPack);
            output.Write(hasFlashLight);
            output.Write(hasSpaceSuit);

            outStream.Close();

            Console.WriteLine("Save complete");

        }

        // saving enemy stats
        private void enemySave_Click(object sender, EventArgs e)
        {
            eHealth = (int)enemyHealth.Value; // set the stats
            eDamage = (int)enemyDamage.Value;
            eSpeed = (int)enemySpeed.Value;
            eJumpHeight = (int)enemyJump.Value;

            Console.WriteLine(eHealth + " " + eDamage + " " + eSpeed + " " + eJumpHeight);

            // write data out to save file

            Stream outStream = File.OpenWrite("enemySave.data");

            BinaryWriter output = new BinaryWriter(outStream);

            output.Write(eHealth);
            output.Write(eDamage);
            output.Write(eSpeed);
            output.Write(eJumpHeight);

            outStream.Close();

            Console.WriteLine("Save complete");
        }
    }
}
