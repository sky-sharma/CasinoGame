using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace CasinoMegaChallenge
{
    [Serializable]
    public class SlotGame
    {
        private Spinner[] theseSpinners;
        public Spinner[] spinners
        {
            get
            {
                return theseSpinners;
            }

            set
            {
                theseSpinners = value;
            }
        }

        private double thisBalance;
        public double balance
        {
            get
            {
                return thisBalance;
            }

            set
            {
                thisBalance = value;
            }
        }

        private double thisBet;
        public double bet
        {
            get
            {
                return thisBet;
            }

            set
            {
                thisBet = value;
            }
        }

        private double thisWinnings;
        public double winnings
        {
            get
            {
                return thisWinnings;
            }

            set
            {
                thisWinnings = value;
            }
        }

        public SlotGame(Spinner[] assignedSpinners)
        {
            spinners = assignedSpinners;
            balance = 100;
            winnings = 0;
        }

        public void spin(double assignedBet)
        {
            bet = assignedBet;
            for (int i = 0; i < 3; i++)
            {
                spinners[i].spin();
            };
            winnings = bet * calculateWinningsMultiplier();
            balance += winnings;
        }

        public double calculateWinningsMultiplier()
        {
            int numCherries = 0;
            for (int i = 0; i < 3; i++)
            {
                // If any Bars received, no winnings!
                if (spinners[i].imageName == "Bar")
                    return -1;

                // Keep track of how many cherries
                else if (spinners[i].imageName == "Cherry")
                    numCherries++;
            }

            // If 1 cherry, winnings are 2x
            // If 2 cherries, winnings are 3x
            // If 3 cherries, winnings are 4x
            if (numCherries > 0)
            {
                numCherries++;
                return numCherries;
            }
            else return -1;
        }
    }
}