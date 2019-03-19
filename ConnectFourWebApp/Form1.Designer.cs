// Alyssa Hove and Katheryn Weeden
// 2/25/19
// GUI Prototype for Connect Four

namespace ConnectFourWebApp
{
    partial class ConnectFour
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
            this.panelBoard = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPlayerTurn = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.rowUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.columnUpDown = new System.Windows.Forms.NumericUpDown();
            this.placeBtn = new System.Windows.Forms.Button();
            this.NewGamebtn = new System.Windows.Forms.Button();
            this.SaveRestoreBtn = new System.Windows.Forms.Button();
            this.WinBox = new System.Windows.Forms.TextBox();
            this.txtInvalidLocation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.BackColor = System.Drawing.Color.SteelBlue;
            this.panelBoard.Location = new System.Drawing.Point(100, 73);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(586, 365);
            this.panelBoard.TabIndex = 0;
            this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(703, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPlayerTurn
            // 
            this.txtPlayerTurn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlayerTurn.Enabled = false;
            this.txtPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtPlayerTurn.ForeColor = System.Drawing.Color.Black;
            this.txtPlayerTurn.Location = new System.Drawing.Point(100, 12);
            this.txtPlayerTurn.Name = "txtPlayerTurn";
            this.txtPlayerTurn.Size = new System.Drawing.Size(198, 22);
            this.txtPlayerTurn.TabIndex = 0;
            this.txtPlayerTurn.Text = "Turn: Player 1";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(703, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rowUpDown
            // 
            this.rowUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rowUpDown.Location = new System.Drawing.Point(703, 104);
            this.rowUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.rowUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowUpDown.Name = "rowUpDown";
            this.rowUpDown.Size = new System.Drawing.Size(85, 32);
            this.rowUpDown.TabIndex = 3;
            this.rowUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRow.Location = new System.Drawing.Point(699, 81);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(41, 20);
            this.lblRow.TabIndex = 4;
            this.lblRow.Text = "Row";
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblColumn.Location = new System.Drawing.Point(699, 149);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(63, 20);
            this.lblColumn.TabIndex = 6;
            this.lblColumn.Text = "Column";
            // 
            // columnUpDown
            // 
            this.columnUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.columnUpDown.Location = new System.Drawing.Point(703, 172);
            this.columnUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.columnUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnUpDown.Name = "columnUpDown";
            this.columnUpDown.Size = new System.Drawing.Size(85, 32);
            this.columnUpDown.TabIndex = 5;
            this.columnUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // placeBtn
            // 
            this.placeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.placeBtn.Location = new System.Drawing.Point(703, 220);
            this.placeBtn.Name = "placeBtn";
            this.placeBtn.Size = new System.Drawing.Size(75, 38);
            this.placeBtn.TabIndex = 7;
            this.placeBtn.Text = "Place";
            this.placeBtn.UseVisualStyleBackColor = true;
            this.placeBtn.Click += new System.EventHandler(this.placeBtn_Click);
            // 
            // NewGamebtn
            // 
            this.NewGamebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NewGamebtn.Location = new System.Drawing.Point(12, 73);
            this.NewGamebtn.Name = "NewGamebtn";
            this.NewGamebtn.Size = new System.Drawing.Size(75, 52);
            this.NewGamebtn.TabIndex = 8;
            this.NewGamebtn.Text = "New Game";
            this.NewGamebtn.UseVisualStyleBackColor = true;
            this.NewGamebtn.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // SaveRestoreBtn
            // 
            this.SaveRestoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaveRestoreBtn.Location = new System.Drawing.Point(12, 152);
            this.SaveRestoreBtn.Name = "SaveRestoreBtn";
            this.SaveRestoreBtn.Size = new System.Drawing.Size(75, 52);
            this.SaveRestoreBtn.TabIndex = 9;
            this.SaveRestoreBtn.Text = "Load Game";
            this.SaveRestoreBtn.UseVisualStyleBackColor = true;
            this.SaveRestoreBtn.Click += new System.EventHandler(this.SaveRestoreBtn_Click);
            // 
            // WinBox
            // 
            this.WinBox.BackColor = System.Drawing.SystemColors.Control;
            this.WinBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.WinBox.Location = new System.Drawing.Point(338, 11);
            this.WinBox.Name = "WinBox";
            this.WinBox.Size = new System.Drawing.Size(259, 22);
            this.WinBox.TabIndex = 10;
            // 
            // txtInvalidLocation
            // 
            this.txtInvalidLocation.BackColor = System.Drawing.SystemColors.Control;
            this.txtInvalidLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInvalidLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtInvalidLocation.Location = new System.Drawing.Point(100, 40);
            this.txtInvalidLocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtInvalidLocation.Multiline = true;
            this.txtInvalidLocation.Name = "txtInvalidLocation";
            this.txtInvalidLocation.Size = new System.Drawing.Size(198, 20);
            this.txtInvalidLocation.TabIndex = 11;
            this.txtInvalidLocation.Text = "Invalid Location. Try Again.";
            this.txtInvalidLocation.Visible = false;
            // 
            // ConnectFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtInvalidLocation);
            this.Controls.Add(this.WinBox);
            this.Controls.Add(this.SaveRestoreBtn);
            this.Controls.Add(this.NewGamebtn);
            this.Controls.Add(this.placeBtn);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.columnUpDown);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.rowUpDown);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPlayerTurn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelBoard);
            this.Name = "ConnectFour";
            this.Text = "Connect Four - Hove and Weeden";
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPlayerTurn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown rowUpDown;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.NumericUpDown columnUpDown;
        private System.Windows.Forms.Button placeBtn;
        private System.Windows.Forms.Button NewGamebtn;
        private System.Windows.Forms.Button SaveRestoreBtn;
        private System.Windows.Forms.TextBox WinBox;
        private System.Windows.Forms.TextBox txtInvalidLocation;
    }
}

