namespace ExternalTool_CharacterEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelOne = new System.Windows.Forms.RadioButton();
            this.levelTwo = new System.Windows.Forms.RadioButton();
            this.levelThree = new System.Windows.Forms.RadioButton();
            this.levelFour = new System.Windows.Forms.RadioButton();
            this.levelFive = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playerSpeedProgress = new System.Windows.Forms.ProgressBar();
            this.playerSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playerJump = new System.Windows.Forms.NumericUpDown();
            this.playerJumpProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playerDamage = new System.Windows.Forms.NumericUpDown();
            this.playerDamageProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.enemyDamageProgress = new System.Windows.Forms.ProgressBar();
            this.enemyDamage = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.enemyJumpProgress = new System.Windows.Forms.ProgressBar();
            this.enemyJump = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.enemySpeed = new System.Windows.Forms.NumericUpDown();
            this.enemySpeedProgress = new System.Windows.Forms.ProgressBar();
            this.playerHealthProgress = new System.Windows.Forms.ProgressBar();
            this.playerHealth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.enemyHealthProgress = new System.Windows.Forms.ProgressBar();
            this.enemyHealth = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.savePlayer = new System.Windows.Forms.Button();
            this.enemySave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerJump)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerDamage)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyJump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyHealth)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemListBox
            // 
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.Items.AddRange(new object[] {
            "Has Jump Pack",
            "Has Flashlight",
            "Has Space Suit"});
            this.ItemListBox.Location = new System.Drawing.Point(82, 123);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(151, 67);
            this.ItemListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Posession";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.levelFive);
            this.groupBox1.Controls.Add(this.levelFour);
            this.groupBox1.Controls.Add(this.levelThree);
            this.groupBox1.Controls.Add(this.levelTwo);
            this.groupBox1.Controls.Add(this.levelOne);
            this.groupBox1.Location = new System.Drawing.Point(295, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Access Level";
            // 
            // levelOne
            // 
            this.levelOne.AutoSize = true;
            this.levelOne.Location = new System.Drawing.Point(7, 26);
            this.levelOne.Name = "levelOne";
            this.levelOne.Size = new System.Drawing.Size(36, 24);
            this.levelOne.TabIndex = 0;
            this.levelOne.TabStop = true;
            this.levelOne.Text = "1";
            this.levelOne.UseVisualStyleBackColor = true;
            // 
            // levelTwo
            // 
            this.levelTwo.AutoSize = true;
            this.levelTwo.Location = new System.Drawing.Point(6, 56);
            this.levelTwo.Name = "levelTwo";
            this.levelTwo.Size = new System.Drawing.Size(36, 24);
            this.levelTwo.TabIndex = 1;
            this.levelTwo.TabStop = true;
            this.levelTwo.Text = "2";
            this.levelTwo.UseVisualStyleBackColor = true;
            // 
            // levelThree
            // 
            this.levelThree.AutoSize = true;
            this.levelThree.Location = new System.Drawing.Point(7, 86);
            this.levelThree.Name = "levelThree";
            this.levelThree.Size = new System.Drawing.Size(36, 24);
            this.levelThree.TabIndex = 2;
            this.levelThree.TabStop = true;
            this.levelThree.Text = "3";
            this.levelThree.UseVisualStyleBackColor = true;
            // 
            // levelFour
            // 
            this.levelFour.AutoSize = true;
            this.levelFour.Location = new System.Drawing.Point(64, 25);
            this.levelFour.Name = "levelFour";
            this.levelFour.Size = new System.Drawing.Size(36, 24);
            this.levelFour.TabIndex = 3;
            this.levelFour.TabStop = true;
            this.levelFour.Text = "4";
            this.levelFour.UseVisualStyleBackColor = true;
            // 
            // levelFive
            // 
            this.levelFive.AutoSize = true;
            this.levelFive.Location = new System.Drawing.Point(64, 56);
            this.levelFive.Name = "levelFive";
            this.levelFive.Size = new System.Drawing.Size(36, 24);
            this.levelFive.TabIndex = 4;
            this.levelFive.TabStop = true;
            this.levelFive.Text = "5";
            this.levelFive.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.playerHealthProgress);
            this.groupBox2.Controls.Add(this.playerHealth);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.playerDamageProgress);
            this.groupBox2.Controls.Add(this.playerDamage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.playerJumpProgress);
            this.groupBox2.Controls.Add(this.playerJump);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.playerSpeed);
            this.groupBox2.Controls.Add(this.playerSpeedProgress);
            this.groupBox2.Location = new System.Drawing.Point(82, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 230);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Statistics";
            // 
            // playerSpeedProgress
            // 
            this.playerSpeedProgress.Location = new System.Drawing.Point(130, 47);
            this.playerSpeedProgress.Name = "playerSpeedProgress";
            this.playerSpeedProgress.Size = new System.Drawing.Size(201, 27);
            this.playerSpeedProgress.TabIndex = 0;
            // 
            // playerSpeed
            // 
            this.playerSpeed.Location = new System.Drawing.Point(74, 47);
            this.playerSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.playerSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerSpeed.Name = "playerSpeed";
            this.playerSpeed.Size = new System.Drawing.Size(50, 26);
            this.playerSpeed.TabIndex = 1;
            this.playerSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerSpeed.ValueChanged += new System.EventHandler(this.playerSpeed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jump Height";
            // 
            // playerJump
            // 
            this.playerJump.Location = new System.Drawing.Point(115, 89);
            this.playerJump.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.playerJump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerJump.Name = "playerJump";
            this.playerJump.Size = new System.Drawing.Size(50, 26);
            this.playerJump.TabIndex = 4;
            this.playerJump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerJump.ValueChanged += new System.EventHandler(this.playerJump_ValueChanged);
            // 
            // playerJumpProgress
            // 
            this.playerJumpProgress.Location = new System.Drawing.Point(171, 89);
            this.playerJumpProgress.Name = "playerJumpProgress";
            this.playerJumpProgress.Size = new System.Drawing.Size(160, 27);
            this.playerJumpProgress.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.savePlayer);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ItemListBox);
            this.groupBox3.Location = new System.Drawing.Point(17, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(670, 596);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player Stats";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Damage";
            // 
            // playerDamage
            // 
            this.playerDamage.Location = new System.Drawing.Point(86, 130);
            this.playerDamage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerDamage.Name = "playerDamage";
            this.playerDamage.Size = new System.Drawing.Size(50, 26);
            this.playerDamage.TabIndex = 7;
            this.playerDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerDamage.ValueChanged += new System.EventHandler(this.playerDamage_ValueChanged);
            // 
            // playerDamageProgress
            // 
            this.playerDamageProgress.Location = new System.Drawing.Point(142, 129);
            this.playerDamageProgress.Name = "playerDamageProgress";
            this.playerDamageProgress.Size = new System.Drawing.Size(189, 27);
            this.playerDamageProgress.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.enemySave);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(693, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(670, 596);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enemy Stats";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.enemyHealthProgress);
            this.groupBox5.Controls.Add(this.enemyHealth);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.enemyDamageProgress);
            this.groupBox5.Controls.Add(this.enemyDamage);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.enemyJumpProgress);
            this.groupBox5.Controls.Add(this.enemyJump);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.enemySpeed);
            this.groupBox5.Controls.Add(this.enemySpeedProgress);
            this.groupBox5.Location = new System.Drawing.Point(82, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 223);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Player Statistics";
            // 
            // enemyDamageProgress
            // 
            this.enemyDamageProgress.Location = new System.Drawing.Point(142, 129);
            this.enemyDamageProgress.Name = "enemyDamageProgress";
            this.enemyDamageProgress.Size = new System.Drawing.Size(189, 27);
            this.enemyDamageProgress.TabIndex = 8;
            // 
            // enemyDamage
            // 
            this.enemyDamage.Location = new System.Drawing.Point(86, 130);
            this.enemyDamage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enemyDamage.Name = "enemyDamage";
            this.enemyDamage.Size = new System.Drawing.Size(50, 26);
            this.enemyDamage.TabIndex = 7;
            this.enemyDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Damage";
            // 
            // enemyJumpProgress
            // 
            this.enemyJumpProgress.Location = new System.Drawing.Point(171, 89);
            this.enemyJumpProgress.Name = "enemyJumpProgress";
            this.enemyJumpProgress.Size = new System.Drawing.Size(160, 27);
            this.enemyJumpProgress.TabIndex = 5;
            // 
            // enemyJump
            // 
            this.enemyJump.Location = new System.Drawing.Point(115, 89);
            this.enemyJump.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.enemyJump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enemyJump.Name = "enemyJump";
            this.enemyJump.Size = new System.Drawing.Size(50, 26);
            this.enemyJump.TabIndex = 4;
            this.enemyJump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enemyJump.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Jump Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Speed";
            // 
            // enemySpeed
            // 
            this.enemySpeed.Location = new System.Drawing.Point(74, 47);
            this.enemySpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.enemySpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enemySpeed.Name = "enemySpeed";
            this.enemySpeed.Size = new System.Drawing.Size(50, 26);
            this.enemySpeed.TabIndex = 1;
            this.enemySpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // enemySpeedProgress
            // 
            this.enemySpeedProgress.Location = new System.Drawing.Point(130, 47);
            this.enemySpeedProgress.Name = "enemySpeedProgress";
            this.enemySpeedProgress.Size = new System.Drawing.Size(201, 27);
            this.enemySpeedProgress.TabIndex = 0;
            // 
            // playerHealthProgress
            // 
            this.playerHealthProgress.Location = new System.Drawing.Point(130, 171);
            this.playerHealthProgress.Name = "playerHealthProgress";
            this.playerHealthProgress.Size = new System.Drawing.Size(201, 27);
            this.playerHealthProgress.TabIndex = 11;
            this.playerHealthProgress.Click += new System.EventHandler(this.progressBar7_Click);
            // 
            // playerHealth
            // 
            this.playerHealth.Location = new System.Drawing.Point(72, 172);
            this.playerHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerHealth.Name = "playerHealth";
            this.playerHealth.Size = new System.Drawing.Size(50, 26);
            this.playerHealth.TabIndex = 10;
            this.playerHealth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerHealth.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Health";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // enemyHealthProgress
            // 
            this.enemyHealthProgress.Location = new System.Drawing.Point(132, 172);
            this.enemyHealthProgress.Name = "enemyHealthProgress";
            this.enemyHealthProgress.Size = new System.Drawing.Size(201, 27);
            this.enemyHealthProgress.TabIndex = 14;
            // 
            // enemyHealth
            // 
            this.enemyHealth.Location = new System.Drawing.Point(74, 173);
            this.enemyHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enemyHealth.Name = "enemyHealth";
            this.enemyHealth.Size = new System.Drawing.Size(50, 26);
            this.enemyHealth.TabIndex = 13;
            this.enemyHealth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Health";
            // 
            // savePlayer
            // 
            this.savePlayer.Location = new System.Drawing.Point(503, 526);
            this.savePlayer.Name = "savePlayer";
            this.savePlayer.Size = new System.Drawing.Size(161, 64);
            this.savePlayer.TabIndex = 7;
            this.savePlayer.Text = "Save";
            this.savePlayer.UseVisualStyleBackColor = true;
            // 
            // enemySave
            // 
            this.enemySave.Location = new System.Drawing.Point(503, 526);
            this.enemySave.Name = "enemySave";
            this.enemySave.Size = new System.Drawing.Size(161, 64);
            this.enemySave.TabIndex = 8;
            this.enemySave.Text = "Save";
            this.enemySave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 632);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerJump)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerDamage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyJump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyHealth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ItemListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton levelFive;
        private System.Windows.Forms.RadioButton levelFour;
        private System.Windows.Forms.RadioButton levelThree;
        private System.Windows.Forms.RadioButton levelTwo;
        private System.Windows.Forms.RadioButton levelOne;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar playerDamageProgress;
        private System.Windows.Forms.NumericUpDown playerDamage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar playerJumpProgress;
        private System.Windows.Forms.NumericUpDown playerJump;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown playerSpeed;
        private System.Windows.Forms.ProgressBar playerSpeedProgress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar playerHealthProgress;
        private System.Windows.Forms.NumericUpDown playerHealth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ProgressBar enemyDamageProgress;
        private System.Windows.Forms.NumericUpDown enemyDamage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar enemyJumpProgress;
        private System.Windows.Forms.NumericUpDown enemyJump;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown enemySpeed;
        private System.Windows.Forms.ProgressBar enemySpeedProgress;
        private System.Windows.Forms.ProgressBar enemyHealthProgress;
        private System.Windows.Forms.NumericUpDown enemyHealth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button savePlayer;
        private System.Windows.Forms.Button enemySave;
    }
}

