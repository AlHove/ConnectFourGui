// Alyssa Hove and Katheryn Weeden
// 3/19/19
// Game Form for Connect Four

using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
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

        //Save the current game
        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrl.SvBtnEvent();
        }

        //Initiate place a piece
        private void placeBtn_Click(object sender, EventArgs e)
        {
            ctrl.PlaceEvent();
        }

        //Restore a saved game
        private void SaveRestoreBtn_Click(object sender, EventArgs e)
        {
            ctrl.SvRstBtnEvent();
        }

        //Initiate a new game
        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            ctrl.StartNewGameBtnEvent();
        }
    }
}
