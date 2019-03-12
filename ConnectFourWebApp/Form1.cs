﻿// Alyssa Hove and Katheryn Weeden
// 2/25/19
// GUI Prototype for Connect Four

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConnectFour.Board;
using static ConnectFour.Player;

namespace ConnectFourWebApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
        int playerTurn = 1;
        int col = 0;
        int row = 0
        Player playerCurrent;

        public Form1()
        {
            InitializeComponent();

            //gotta pass these widgets to the controller
                ctrl = new Controller(btnSave, panelBoard, playerCurrent);
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
            // check if the piece is in the Board. If it isn't use then no
            // math to do the painting g.FillEllipse(pen, 40, 10, 40, 40);\
            // for y: 10 + (col - 1) * 50
            // for x: 40 + (row - 1) * 80

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void playerTurn_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void drawBoard()
        {
            g = panelBoard.CreateGraphics();
            g.FillEllipse(pen, 40, 10, 40, 40);
            g.FillEllipse(pen, 40, 60, 40, 40);
            g.FillEllipse(pen, 40, 110, 40, 40);
            g.FillEllipse(pen, 40, 160, 40, 40);
            g.FillEllipse(pen, 40, 210, 40, 40);
            g.FillEllipse(pen, 40, 260, 40, 40);
            g.FillEllipse(pen, 40, 310, 40, 40);
            g.FillEllipse(pen, 120, 10, 40, 40);
            g.FillEllipse(pen, 120, 60, 40, 40);
            g.FillEllipse(pen, 120, 110, 40, 40);
            g.FillEllipse(pen, 120, 160, 40, 40);
            g.FillEllipse(pen, 120, 210, 40, 40);
            g.FillEllipse(pen, 120, 260, 40, 40);
            g.FillEllipse(pen, 120, 310, 40, 40);
            g.FillEllipse(pen, 200, 10, 40, 40);
            g.FillEllipse(pen, 200, 60, 40, 40);
            g.FillEllipse(pen, 200, 110, 40, 40);
            g.FillEllipse(pen, 200, 160, 40, 40);
            g.FillEllipse(pen, 200, 210, 40, 40);
            g.FillEllipse(pen, 200, 260, 40, 40);
            g.FillEllipse(pen, 200, 310, 40, 40);
            g.FillEllipse(pen, 280, 10, 40, 40);
            g.FillEllipse(pen, 280, 60, 40, 40);
            g.FillEllipse(pen, 280, 110, 40, 40);
            g.FillEllipse(pen, 280, 160, 40, 40);
            g.FillEllipse(pen, 280, 210, 40, 40);
            g.FillEllipse(pen, 280, 260, 40, 40);
            g.FillEllipse(pen, 280, 310, 40, 40);
            g.FillEllipse(pen, 360, 10, 40, 40);
            g.FillEllipse(pen, 360, 60, 40, 40);
            g.FillEllipse(pen, 360, 110, 40, 40);
            g.FillEllipse(pen, 360, 160, 40, 40);
            g.FillEllipse(pen, 360, 210, 40, 40);
            g.FillEllipse(pen, 360, 260, 40, 40);
            g.FillEllipse(pen, 360, 310, 40, 40);
            g.FillEllipse(pen, 440, 10, 40, 40);
            g.FillEllipse(pen, 440, 60, 40, 40);
            g.FillEllipse(pen, 440, 110, 40, 40);
            g.FillEllipse(pen, 440, 160, 40, 40);
            g.FillEllipse(pen, 440, 210, 40, 40);
            g.FillEllipse(pen, 440, 260, 40, 40);
            g.FillEllipse(pen, 440, 310, 40, 40);
            g.FillEllipse(pen, 520, 10, 40, 40);
            g.FillEllipse(pen, 520, 60, 40, 40);
            g.FillEllipse(pen, 520, 110, 40, 40);
            g.FillEllipse(pen, 520, 160, 40, 40);
            g.FillEllipse(pen, 520, 210, 40, 40);
            g.FillEllipse(pen, 520, 260, 40, 40);
            g.FillEllipse(pen, 520, 310, 40, 40);
        }
    }
}
