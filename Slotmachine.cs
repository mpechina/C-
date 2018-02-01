using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasinoChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("MyValue", 100);
                string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
                displayImages(reels);

            }
        }

        protected void pullButton_Click(object sender, EventArgs e)
        {

            pullLever();


        }
        private void pullLever()
        {
            string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
            displayImages(reels);
        }
        
        private void displayImages(string[] reels)
        {
            reel1.ImageUrl = "/Images/" + reels[0] + ".png";
            reel2.ImageUrl = "/Images/" + reels[1] + ".png";
            reel3.ImageUrl = "/Images/" + reels[2] + ".png";
            findImageValues(reels);
        }
        Random random = new Random();
        private string spinReel()
        {
            
            string[] images = new string[] {"Strawberry","Bar","Lemon","Bell","Clover",
            "Cherry","Diamond","Orange","Seven","HorseShoe","Plum","Watermelon"};

            return images[random.Next(11)];
        }
        private void findImageValues(string[] reels)
        {
            int winningsTotal = 0;
            
            if (reels[0] == "Cherry" || reels[1] == "Cherry" || reels[2] == "Cherry") winningsTotal = 2;
            if (reels[0] == "Cherry" && reels[1] == "Cherry") winningsTotal = 3;
            if (reels[0] == "Cherry" && reels[1] == "Cherry" && reels[2] == "Cherry") winningsTotal = 4;
            if (reels[0] == "Cherry" && reels[2] == "Cherry") winningsTotal = 3;
            if (reels[1] == "Cherry" && reels[2] == "Cherry") winningsTotal = 3;
            if (reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven") winningsTotal = 100;
            if (reels[0] == "Bar" || reels[1] == "Bar" || reels[2] == "Bar") winningsTotal = 0;

            //  moneyLabel.Text = String.Format("You win {0:C} bucks,", winningsTotal);
            betTimesWinnings(winningsTotal);
        }
        private void betTimesWinnings(int winningsTotal)
        {
            if (betTextBox.Text.Trim().Length == 0) return;

            int bet = 0;
            if (!int.TryParse(betTextBox.Text, out bet)) return;

            int overallWinnings = 0;
            overallWinnings = bet * winningsTotal;

            moneyLabel.Text = String.Format("You win {0:C} bucks,", overallWinnings);

            playersCash(overallWinnings, bet);


        }
        private void playersCash(int overallWinnings, int bet)
        {
            int playerMoney = 0;
            playerMoney = Convert.ToInt32(ViewState["MyValue"]);
            if (overallWinnings > 0) playerMoney += overallWinnings;

            else playerMoney -= bet;
            ViewState["MyValue"] = playerMoney;

            resultLabel.Text = playerMoney.ToString() + ".00";
        }
    }
}