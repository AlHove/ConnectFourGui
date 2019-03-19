// Alyssa Hove and Katheryn Weeden
// 3/19/19
// GUI Prototype for Connect Four

using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;

namespace ConnectFourWebApp
{
    class Controller
    {
        /// <summary>
        /// general constants
        /// </summary>
        const string saveFileName = "ConnectFourSave.xml";

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
        private TextBox WinBox = null;
        private TextBox txtInvalidLocation = null;
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
        public Controller(Panel board, TextBox PlayerT, TextBox WinB, TextBox invalidLoc, Button save, Button exit, Label row, Label col, NumericUpDown udRow, NumericUpDown udCol)
        {
            panelBoard = board;
            txtPlayerTurn = PlayerT;
            WinBox = WinB;
            txtInvalidLocation = invalidLoc;
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
            GoNewGameState();
        }

        private void GoCouldRestoreState()
        {
            SetUpState = States.CouldRestore;
        }

        private void GoRestoreState()
        {
            SetUpState = States.Restore;

            //Clear anything on board currently before loading saved game
            clearBoard();

            //Read saved game and extract the board and current player then close it
            Stream saveFile = File.OpenRead(saveFileName);
            SoapFormatter deserializer = new SoapFormatter();
            board = (Board)(deserializer.Deserialize(saveFile));
            currentP = (Player)(deserializer.Deserialize(saveFile));
            saveFile.Close();

            //Delete saved game after reading it's information
            File.Delete(saveFileName);

            //Testing purposes
            Console.WriteLine();
            System.Diagnostics.Debug.WriteLine("Hit Restore");

            //Output current player from saved game
            txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;
            txtInvalidLocation.Visible = false;

            //Redraw board to reflect saved game
            redrawBoard();
        }

        private void GoNewGameState()
        {
            SetUpState = States.StartGame;

            //Clear anything on board before starting a new game
            clearBoard();

            //Reset widgets and info to start a new game
            currentP = new Player();
            currentP.piece = 'X';
            currentP.turnNumber = 1;
            columnUpDown.Value = 1;
            rowUpDown.Value = 1;
            board = null;
            board = new Board();
            board.SetBoard();
            txtInvalidLocation.Visible = false;
            txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;

            //Testing purposes
            System.Diagnostics.Debug.WriteLine("hit");
        }

        private void GoPlayState()
        {
            TopLevelState = States.Play;

            bool valid = false;
            Graphics g;
            int row = Convert.ToInt32(rowUpDown.Value) - 1;
            int col = Convert.ToInt32(columnUpDown.Value) - 1;
            char c = currentP.piece;

            //Validate if selected location is available
            valid = board.ValidateLocation(board, row, col);
            System.Diagnostics.Debug.WriteLine(col);
            System.Diagnostics.Debug.WriteLine(row);
            System.Diagnostics.Debug.WriteLine(currentP.turnNumber);
            System.Diagnostics.Debug.WriteLine(valid);

            txtInvalidLocation.Visible = false;

            //If selected location is valid fill circle in with corresponding player color
            //Player 1 is green (p1Brush) and Player 2 is purple (p2Brush)
            if (valid == true)
            {
                board.Grid[row, col] = c;
                g = panelBoard.CreateGraphics();
                int y = ((row * 50) + 10);
                int x = ((col * 80) + 40);
                bool win = false;
                if (currentP.turnNumber == 1)
                {
                    g.FillEllipse(p1Brush, x, y, 40, 40);
                    win = board.CheckWin(board, currentP);
                    if (win)
                    {
                        txtPlayerTurn.Text = "Winner: Player " + currentP.turnNumber;
                    }
                    if (!win)
                    {
                        currentP.turnNumber = 2;
                        currentP.piece = 'O';
                        txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;
                    }
                }
                else if (currentP.turnNumber == 2)
                {
                    g.FillEllipse(p2Brush, x, y, 40, 40);
                    win = board.CheckWin(board, currentP);
                    if (win) {
                        txtPlayerTurn.Text = "Winner: Player " + currentP.turnNumber;
                    }
                    if (!win)
                    {
                        currentP.turnNumber = 1;
                        currentP.piece = 'X';
                        txtPlayerTurn.Text = "Turn: Player " + currentP.turnNumber;
                    }
                }

                //Check for a win
                IfGameOverTransition();

            } else //if the selection was invalid alert the user with a textbox
            {
                txtInvalidLocation.Visible = true;
            }
        }

        private void GoFinishState()
        {
            TopLevelState = States.Finish;
        }

        private void GoGameOverState()
        {
            FinishState = States.GameOver;
            GoFinishState();

            //Testing purposes
            System.Diagnostics.Debug.WriteLine("Game Over Hit");

            RestartGameTransition();
        }

        private void GoSaveGameState()
        {
            FinishState = States.SaveGame;
            GoFinishState();

            //Create an XML file to save current state of game
            Stream saveFile = File.Create(saveFileName);
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(saveFile, board);
            serializer.Serialize(saveFile, currentP);
            saveFile.Close();

            //Allow start over
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

        //Restore a saved game
        public void SvRstBtnEvent()
        {
            IfSavedFileTransition();
            if (TopLevelState == States.SetUp && SetUpState == States.CouldRestore)
            {
                GoRestoreState();
            }
        }

        public void StartNewGameBtnEvent()
        {
                GoNewGameState();
        }

        public void PlaceEvent()
        {
            //Testing purposes
            System.Diagnostics.Debug.WriteLine("hit");
            System.Diagnostics.Debug.WriteLine(TopLevelState);
            System.Diagnostics.Debug.WriteLine(SetUpState);

            if (TopLevelState == States.SetUp &&
                (SetUpState == States.Restore || SetUpState == States.StartGame)
                || TopLevelState == States.Play)
            {
                GoPlayState();
            }
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
            clearBoard();
            if (TopLevelState == States.Finish)
            {
                GoSetupState();
            }
        }

        private void IfSavedFileTransition()
        {
            //if save file exists, move to next state
            if (File.Exists(saveFileName))
            {
                GoCouldRestoreState();
            }
            else GoNewGameState();
        }

        private void IfGameOverTransition()
        {
            if (board.CheckWin(board,currentP) && TopLevelState == States.Play)
            {
                WinBox.Text = "Last Winner: Player " + currentP.turnNumber;
                GoGameOverState();
            }
        }

        //Reset to a clean board
        private void clearBoard()
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

        //Redraw the board and fill in for each player
        private void redrawBoard()
        {
            Graphics g;
            SolidBrush pen = new SolidBrush(Color.FromArgb(250, 255, 255));
            g = panelBoard.CreateGraphics();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
        
                    if (board.Grid[i, j] == 'X')
                    {
                        int y = ((i * 50) + 10);
                        int x = ((j * 80) + 40);
                        g.FillEllipse(p1Brush, x, y, 40, 40);
                    }
                    else if (board.Grid[i, j] == 'O')
                    {
                        int y = ((i * 50) + 10);
                        int x = ((j * 80) + 40);
                        g.FillEllipse(p2Brush, x, y, 40, 40);
                    }
                }
            }
        }
    }

