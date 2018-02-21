using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalTool_CharacterEditor
{
    public partial class Form1 : Form
    {
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

        // ignore this
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
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

        // ignore this
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int level = Convert.ToInt32((playerHealth.Value / playerHealth.Maximum) * 100);
            playerHealthProgress.Value = level;
        }

    }
}
