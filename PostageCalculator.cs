using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostageCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }

        protected void groundButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }

        protected void airButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }

        protected void nextDayButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateShipAmt();
        }
        private void calculateShipAmt()
        {
            // Do values exist?
            if (!valuesExitst()) return;

            // What is the volume
            int volume = 0;
            if (!tryGetVolume(out volume)) return;

            // What is the multiplier
            double postageMultiplier = PostageMultiplier;

            // Determine the cost
            double cost = volume * postageMultiplier;

            // Show the user
            resultLabel.Text = String.Format("Your shit will cost {0:C} to ship.", cost);
        }

        private bool valuesExitst()
        {
           
        }

        private double PostageMultiplier
        {
            get
            {
                double postageMultiplier = 0.0;
                if (groundButton.Checked)
                {
                    postageMultiplier = 0.15;
                }
                else if (airButton.Checked)
                {
                    postageMultiplier = 0.25;

                }
                else if (nextDayButton.Checked)
                {
                    postageMultiplier = 0.47;
                }
            }
        }

        private bool tryGetVolume(out int volume)
        {
            throw new NotImplementedException();
        }

        


        private void getBoxWidth(double width)
        {

        }
            
    }
}