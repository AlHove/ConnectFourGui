using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using static ConnectFour.Game;
using static ConnectFour.Board;
using static ConnectFour.Player;

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

        /// <summary>
        /// GUI elements we want to control
        /// </summary>
        private Label WordStatusLbl = null;
        private TextBox txtPlayerTurn = null;
        private TextBox ImageTxb = null;
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
        public Controller(Button sr, Panel i, Player s)
        {
          
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
      

        }

        private void GoPlayState()
        {
            TopLevelState = States.Play;
            IfGameOverTransition();
        }

        private void GoFinishState()
        {
            TopLevelState = States.Finish;
        }

        private void GoGameOverState()
        {
            FinishState = States.GameOver;
            GoFinishState();

            RestartGameTransition();
        }

        private void GoSaveGameState()
        {
            FinishState = States.SaveGame;
            GoFinishState();

            Stream saveFile = File.Create(saveFileName);
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(saveFile, game);
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
        public void SvRstBtnEvent()
        {
            if (TopLevelState == States.SetUp && SetUpState == States.CouldRestore)
            {
                GoRestoreState();
            }
            else if (TopLevelState == States.Play ||
                TopLevelState == States.SetUp && SetUpState == States.StartGame)
            {
                GoFinishState();
                GoSaveGameState();
            }
        }

        public void StartGameBtnEvent()
        {
            if (TopLevelState == States.SetUp &&
                (SetUpState == States.Init || SetUpState == States.CouldRestore))
            {
                GoNewGameState();
            }
        }

        public void GuessEvent()
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
        }

        private void IfGameOverTransition()
        {
            if (game.IsSolved() && TopLevelState == States.Play)
            {
                GoGameOverState();
            }
        }

        /// <summary>
        /// general update of display
        /// </summary>
        /// <param name="msg"></param>

    }
}
