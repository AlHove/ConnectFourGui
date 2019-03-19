// Alyssa Hove and Katheryn Weeden
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
using static ConnectFourWebApp.Board;
using static ConnectFourWebApp.Player;

namespace ConnectFourWebApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
        int col = 1;
        int row = 1;
        Controller ctrl;

        public Form1()
        {
            InitializeComponent();
            //gotta pass these widgets to the controller
                ctrl = new Controller(panelBoard, txtPlayerTurn, btnSave, btnExit, lblRow, 
                                      lblColumn, rowUpDown, columnUpDown);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrl.SvBtnEvent();
        }

        private void panelBoard_drawBoard(object sender, PaintEventArgs e)
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

        private void rowUpDown_ValueChanged(object sender, EventArgs e)
        {
            row = Convert.ToInt32(rowUpDown.Value);
        }

        private void columnUpDown_ValueChanged(object sender, EventArgs e)
        {
            col = Convert.ToInt32(columnUpDown.Value);
        }
        
        //Close form on exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void placeBtn_Click(object sender, EventArgs e)
        {
            ctrl.PlaceEvent();
        }

        private void SaveRestoreBtn_Click(object sender, EventArgs e)
        {
            ctrl.SvRstBtnEvent();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            ctrl.StartGameBtnEvent();
        }
        // check if the piece is in the Board. If it isn't use then no


    }
}
