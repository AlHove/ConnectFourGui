// Alyssa Hove and Katheryn Weeden
// 2/25/19
// GUI Prototype for Connect Four

namespace ConnectFourWebApp
{
    partial class Main
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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnSavedGame = new System.Windows.Forms.Button();
            this.lblConnectFour = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNewGame.Location = new System.Drawing.Point(160, 174);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(139, 56);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnSavedGame
            // 
            this.btnSavedGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSavedGame.Location = new System.Drawing.Point(327, 174);
            this.btnSavedGame.Name = "btnSavedGame";
            this.btnSavedGame.Size = new System.Drawing.Size(139, 56);
            this.btnSavedGame.TabIndex = 1;
            this.btnSavedGame.Text = "Continue Saved Game";
            this.btnSavedGame.UseVisualStyleBackColor = true;
            this.btnSavedGame.Click += new System.EventHandler(this.btnSavedGame_Click);
            // 
            // lblConnectFour
            // 
            this.lblConnectFour.AutoSize = true;
            this.lblConnectFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectFour.ForeColor = System.Drawing.Color.Maroon;
            this.lblConnectFour.Location = new System.Drawing.Point(156, 85);
            this.lblConnectFour.Name = "lblConnectFour";
            this.lblConnectFour.Size = new System.Drawing.Size(316, 55);
            this.lblConnectFour.TabIndex = 2;
            this.lblConnectFour.Text = "Connect Four";
            this.lblConnectFour.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblConnectFour);
            this.Controls.Add(this.btnSavedGame);
            this.Controls.Add(this.btnNewGame);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnSavedGame;
        private System.Windows.Forms.Label lblConnectFour;
    }
}