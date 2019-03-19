// Alyssa Hove and Katheryn Weeden
// 3/19/19
// Main Program for Connect Four

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

        //Open form for new game, hide current form
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ConnectFour newGame = new ConnectFour();
            newGame.Show();
            this.Hide();
        }

        //Open form for saved game, hide current form
        private void btnSavedGame_Click(object sender, EventArgs e)
        {
            ConnectFour savedGame = new ConnectFour();
            savedGame.Show();
            this.Hide();
        }
    }
}
