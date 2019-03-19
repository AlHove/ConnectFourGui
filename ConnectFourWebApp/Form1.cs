// Alyssa Hove and Katheryn Weeden
// 3/19/19
// Game Form for Connect Four

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
    public partial class ConnectFour : Form
    {
        Graphics g;
        SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
        Controller ctrl;

        public ConnectFour()
        {
            InitializeComponent();
            //gotta pass these widgets to the controller
                ctrl = new Controller(panelBoard, txtPlayerTurn, WinBox, txtInvalidLocation, btnSave, btnExit, lblRow, 
                                      lblColumn, rowUpDown, columnUpDown);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrl.SvBtnEvent();
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
            g = panelBoard.CreateGraphics();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int y = ((j * 50) + 10);
                    int x = ((i * 80) + 40);
                    g.FillEllipse(pen, x, y, 40, 40);
                }
            }
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
            ctrl.StartNewGameBtnEvent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
