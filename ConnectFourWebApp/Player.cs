//Alyssa Hove and Katheryn Weeden
// Started 2/1/19
//Player class: Keeps track of Player Data
using System;

namespace ConnectFourWebApp
{
    [Serializable]
    public class Player
    {
        //Turn 1 = Player 1 = Green Player
        //Turn 2 = Player 2 = Purple Player
        public int turnNumber; 
        public char piece; //Player Symbol held in array
        public char PropPlayer
        {
            get
            {
                return piece;
                
            }
            
            set
            {
                piece = value;
                turnNumber = value;

            }
        }
        public int getTurnNumber()
        {
            return turnNumber;
        }
        

    }
}