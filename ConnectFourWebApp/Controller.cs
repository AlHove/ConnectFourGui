using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using static ConnectFourWebApp.Game;
using static ConnectFourWebApp.Board;
using static ConnectFourWebApp.Player;

namespace ConnectFourWebApp
{
    class Controller
    {
        /// <summary>
        /// general constants
        /// </summary>
        const string saveFileName = "ConnectFourSave.xml";
        const string saveText = "Save Game";
        const string restoreText = "Restore Game";

        /// <summary>
        /// State names and statechart state variables
        /// </summary>
        private enum States
        {
            SetUp, Init, CouldRestore, Restore, StartGame,
            Play, Finish, GameOver, SaveGame, NULL
        };
        private States TopLevelState = States.NULL;
        private States SetUpState = States.NULL;
        private States FinishState = States.NULL;

        /// <summary>
        /// Model interface elements
        /// </summary>
        private Board board = null;
        private Player currentP = null;
        private SolidBrush p1Brush = new SolidBrush(Color.FromArgb(65, 102, 0));
        private SolidBrush p2Brush = new SolidBrush(Color.FromArgb(201, 131, 220));
        /// <summary>
        /// GUI elements we want to control
        /// </summary>

        private TextBox txtPlayerTurn = null;
        private Button btnSave = null;
        private Button btnExit = null;
        private Label lblRow = null;
        private Label lblCol = null;
        private Panel panelBoard = null;
        private NumericUpDown rowUpDown = null;
        private NumericUpDown columnUpDown = null;

        /// <summary>
        /// Default constructor to grab GUI widgets to control
        /// </summary>
        public Controller(Panel board, TextBox PlayerT, Button save, Button exit, Label row, Label col, NumericUpDown udRow, NumericUpDown udCol)
        {
            panelBoard = board;
            txtPlayerTurn = PlayerT;
            btnSave = save;
            btnExit = exit;
            lblRow = row;
            lblCol = col;
            rowUpDown = udRow;
            columnUpDown = udCol;
            //enter initial state
            GoSetupState();
        }

        ///////////////////////////// S T A T E S ////////////////////////

        /// <summary>
        /// Each state method has the pattern:
        /// PROLOGUE:
        ///     stateVar = state (repeat as necessary)
        ///     call inner statechart entry (as warranted)
        /// A c t i o n s (as warranted)
        /// EPILOGUE:
        ///     non-event transition call (as warranted)
        /// </summary>
        private void GoSetupState()
        {
            TopLevelState = States.SetUp;
            GoInitState();
        }

        private void GoInitState()
        {

            SetUpState = States.Init;

            IfSavedFileTransition();
        }

        private void GoCouldRestoreState()
        {
            SetUpState = States.CouldRestore;
            GoRestoreState();
        }

        private void GoRestoreState()
        {
            SetUpState = States.Restore;

            Stream saveFile = File.OpenRead(saveFileName);
            SoapFormatter deserializer = new SoapFormatter();
            int turn = (int)(deserializer.Deserialize(saveFile));
            char[,] g = (char[,])(deserializer.Deserialize(saveFile));
            saveFile.Close();
            Console.WriteLine();
        }

        private void GoNewGameState()
        {
            currentP = new Player();
            currentP.piece = 'X';
            currentP.turnNumber = 1;
            board = new Board();
            board.SetBoard();
            if (File.Exists(saveFileName))
            {
                File.Delete(saveFileName);
            }
        }

        private void GoPlayState()
        {
            bool valid = false;
            Graphics g;
            int row = Convert.ToInt32(rowUpDown.Value) - 1;
            int col = Convert.ToInt32(columnUpDown.Value) - 1;
            char c = currentP.piece;
            int playerTurn = currentP.piece;
            valid = board.ValidateLocation(board, row, col);

            if (valid == true)
            {
                board.Grid[row, col] = c;
                g = panelBoard.CreateGraphics();
                int y = (col * 50) + 10;
                int x = (row * 80) + 40;
                bool win = false;
                if (currentP.turnNumber == 1)
                {
                    g.FillEllipse(p1Brush, x, y, 40, 40);
                    win = board.CheckWin(board, currentP);
                    if (win == true)
                    {
                        TopLevelState = States.Play;
                        IfGameOverTransition();
                    }
                    currentP.turnNumber = 2;
                    currentP.piece = 'O';
                    txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;
                }
                else if (currentP.turnNumber == 2)
                {
                    g.FillEllipse(p2Brush, x, y, 40, 40);
                    win = board.CheckWin(board, currentP);
                    if (win == true)
                    {
                        TopLevelState = States.Play;
                        IfGameOverTransition();
                    }
                    currentP.turnNumber = 1;
                    currentP.piece = 'X';
                    txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;
                }

                TopLevelState = States.Play;
                IfGameOverTransition();
            }
        }

        private void GoFinishState()
        {
            TopLevelState = States.Finish;
        }

        private void GoGameOverState()
        {
            FinishState = States.GameOver;
            txtPlayerTurn.Text = "Winner: Player " + currentP.turnNumber;
            GoFinishState();

            RestartGameTransition();
        }

        private void GoSaveGameState()
        {
            FinishState = States.SaveGame;
            GoFinishState();

            Stream saveFile = File.Create(saveFileName);
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(saveFile, board);
            saveFile.Close();

            //allow start over
            RestartGameTransition();
        }

        /////////////////////// E V E N T S //////////////////////
        /// <summary>
        /// public event transition methods
        /// 
        /// Each event determines the state context and if valid calls
        /// the appropriate state method(s)
        /// 
        /// Illegal state/event combos are ignored
        /// </summary>
        public void SvBtnEvent()
        {

           if (TopLevelState == States.Play ||
                TopLevelState == States.SetUp && SetUpState == States.StartGame)
            {
                GoFinishState();
                GoSaveGameState();
            }
        }

        public void SvRstBtnEvent()
        {
            if (TopLevelState == States.SetUp && SetUpState == States.CouldRestore)
            {
                GoRestoreState();
            }
        }

        public void StartGameBtnEvent()
        {
            if (TopLevelState == States.SetUp && SetUpState == States.CouldRestore)
            {
                GoRestoreState();
            }
            else if (TopLevelState == States.SetUp &&
                (SetUpState == States.Init || SetUpState == States.CouldRestore))
            {
                GoNewGameState();
            }
        }

        public void PlaceEvent()
        {
            if (TopLevelState == States.SetUp &&
                (SetUpState == States.Restore || SetUpState == States.StartGame)
                || TopLevelState == States.Play)
            {
                GoPlayState();
            }
        }

        public void ExitEvent()
        {

        }

        /////////////////// NON - EVENT TRANSITIONS ////////////////////////
        /// <summary>
        /// These methodes enable transitions that are not associate
        /// with events.  They are called after the actions of the state
        /// are completed.
        /// 
        /// Guards should include valid current state check and other
        /// context checks.
        /// </summary>
        private void RestartGameTransition()
        {
            Graphics g;
            SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
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
            if (TopLevelState == States.Finish)
            {
                GoSetupState();
            }
        }

        private void IfSavedFileTransition()
        {
            //if save file exists, move to next state
            if (File.Exists(saveFileName) && SetUpState == States.Init)
            {
                GoCouldRestoreState();
            }
            else GoNewGameState();
        }

        private void IfGameOverTransition()
        {
            if (board.CheckWin(board,currentP) && TopLevelState == States.Play)
            {
                GoGameOverState();
            }
        }
    }
}
