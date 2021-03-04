using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairsGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        Random Random = new Random(); //Generate random objects
        List<string> icons = new List<string>()
        {
            "z","z","t","t","i","i",
            "v","v","p","p","[","[",
            "(","(","{","{"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = Random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    iconLabel.ForeColor = iconLabel.BackColor; //hides icons by making the forecolor = backcolor
                    icons.RemoveAt(randomNumber); //Removes the icon from the icon list... so you don't get more than 3 of the same icon.
                }
            }
        }

        private void click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedlabel = sender as Label;
            if (clickedlabel != null)
            {
                if (clickedlabel.ForeColor == Color.Black)
                    return;

                //clickedlabel.ForeColor = Color.Black;
                if (firstClicked==null)
                {
                    firstClicked = clickedlabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedlabel;
                secondClicked.ForeColor = Color.Black;

                winnerWinnerChickenDinner();
                timer1.Start();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (firstClicked.Text != secondClicked.Text)
            {
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;
            }
            firstClicked = null;
            secondClicked = null;
        }

        private void winnerWinnerChickenDinner ()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if(iconLabel != null)
                {
                    if(iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Winner");
            Close();
        }
    }
}
