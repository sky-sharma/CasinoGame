using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasinoMegaChallenge
{
    [Serializable]
    public partial class Default : System.Web.UI.Page
    {
        Spinner[] spinners;
        SlotGame mySlotGame;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                double initialBalance = 100;
                ViewState.Add("Balance", initialBalance);
            }

            Random spinnerRandom = new Random();
            spinners = new Spinner[3];

            spinners[0] = new Spinner(spinnerRandom, image0);
            spinners[1] = new Spinner(spinnerRandom, image1);
            spinners[2] = new Spinner(spinnerRandom, image2);
            mySlotGame = new SlotGame(spinners);
            mySlotGame.balance = (double)ViewState["Balance"];
        }
        

        protected void leverButton_Click(object sender, EventArgs e)
        {
            double bet;
            double.TryParse(betTextBox.Text, out bet);
            if (mySlotGame.balance <= 0)
            {
                resultLabel.Text = "You're bankrupt! You can spin but you can't bet!";
                moneyLabel.Text = "";
            }
            else
            {
                mySlotGame.spin(bet);
                double winnings = mySlotGame.winnings;
                double balance = mySlotGame.balance;
                moneyLabel.Text = String.Format("You " +
                    ((winnings >= 0) ? "won " : "lost ") +
                    "{0:C}.", Math.Abs(winnings).ToString());

                resultLabel.Text = String.Format("Your balance is {0:C}", balance);
                ViewState.Add("Balance", mySlotGame.balance);
            }
        }
    }
}