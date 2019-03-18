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

namespace ConnectFourWebApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Open form for new game, hide current form
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form1 newGame = new Form1();
            newGame.Show();
            this.Hide();
        }

        //Open form for saved game, hide current form
        private void btnSavedGame_Click(object sender, EventArgs e)
        {
            Form1 savedGame = new Form1();
            savedGame.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
