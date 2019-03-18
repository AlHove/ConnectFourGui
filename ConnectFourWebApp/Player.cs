//Alyssa Hove and Katheryn Weeden
// Started 2/1/19
//Player class: Keeps track of Player Data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourWebApp
{
    public class Player
    {
        //public string color;
        public int turnNumber; 
        public char piece; // Player Symbol
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