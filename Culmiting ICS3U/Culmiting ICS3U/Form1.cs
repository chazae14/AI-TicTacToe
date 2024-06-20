// Chaza Elfizy
// 2023/05/16
// Culminating for ICS3U - creating a two player tic tac toe or to play against a bot
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Culmiting_ICS3U
{
    public partial class frmTicTacToe : Form
    {
        public frmTicTacToe()
        {
            InitializeComponent();
        }

        // declaring variables such a counters and booleans, as well as the player
        string player = "O";
        Label[] toeSquares;
        bool win;
        bool piecePlaced = false; 
        int moveCounter = 0;

        // Form Load!!
        private void Form1_Load(object sender, EventArgs e)
        {
            // hiding the cowboy
            picLuckyLuke.Hide();
            picTextBubble.Hide();
            toeSquares = new Label[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9 }; // array of all my boxes
            // for loop to call on event handler whenever a box is clicked
            for (int i = 0; i < toeSquares.Count(); i++)
            {
                toeSquares[i].Click += new EventHandler(Square_Click);
            }
        }

        // function for AI to check center
        private void Check_Center(Label currentLabel)
        {
            // if so that not more than one box is filled
            if (piecePlaced == false)
            {
                if (currentLabel != lbl5 && lbl5.Text == "") // if the center isn't taken
                {
                    lbl5.Text = player;
                    piecePlaced = true;
                }
                else if (currentLabel == lbl5 && lbl3.Text == "") // if the center is taken
                {
                    lbl3.Text = player;
                    piecePlaced = true;
                }
            }
           
        }

        // Checking for win!
        private void Check_for_Win(Label currentLabel)
        {            
            if (piecePlaced == false) // if so that not more than one box is filled
            {
                // AI checking diagonally for win
                for (int i = 2; i < 6; i += 2)
                {
                    if (i == 2 && currentLabel != toeSquares[2])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 2].Text == "X" && toeSquares[i + 4].Text == "X" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 4 && currentLabel != toeSquares[4])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "X" && toeSquares[i - 4].Text == "X" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 6 && currentLabel != toeSquares[6])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "X" && toeSquares[i + 2].Text == "X" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 0 && currentLabel != toeSquares[0])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 4].Text == "X" && toeSquares[i + 8].Text == "X" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 0 && currentLabel == toeSquares[0])
                    {
                        if (toeSquares[i].Text == "X" && toeSquares[i + 4].Text == "X" && toeSquares[i + 8].Text == "" && piecePlaced == false)
                        {
                            toeSquares[i + 8].Text = player;
                            piecePlaced = true;
                        }
                    }
                }

                // AI checking vertically for win
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 6].Text == "X" && toeSquares[i + 3].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 3].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 3].Text == "X" && toeSquares[i + 6].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 6].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 6; i < 9; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i - 3].Text == "X" && toeSquares[i - 6].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i - 6].Text = player;
                        piecePlaced = true;
                    }
                }

                // AI checking horizontally for win
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 1].Text == "X" && toeSquares[i + 2].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 2].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "" && toeSquares[i + 1].Text == "X" && toeSquares[i + 2].Text == "X" && piecePlaced == false)
                    {
                        toeSquares[i].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 1].Text == "" && toeSquares[i + 2].Text == "X" && piecePlaced == false)
                    {
                        toeSquares[i + 1].Text = player;
                        piecePlaced = true;
                    }
                }
            }       
        }

        // checking to block
        private void Block_a_Win(Label currentLabel)
        {
            if (piecePlaced == false) // if so that not more than one box is filled
            {

                // checking diagonally for block
                for (int i = 0; i < 6; i += 2)
                {
                    if (i == 2 && currentLabel != toeSquares[2])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 2].Text == "O" && toeSquares[i + 4].Text == "O" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 4 && currentLabel != toeSquares[4])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "O" && toeSquares[i - 4].Text == "O" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 6 && currentLabel != toeSquares[6])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "O" && toeSquares[i + 2].Text == "O" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 0 && currentLabel != toeSquares[0])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 4].Text == "O" && toeSquares[i + 8].Text == "O" && piecePlaced == false)
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;
                        }
                    }
                    else if (i == 0 && currentLabel == toeSquares[0])
                    {
                        if (toeSquares[i].Text == "O" && toeSquares[i + 4].Text == "O" && toeSquares[i + 8].Text == "" && piecePlaced == false)
                        {
                            toeSquares[i + 8].Text = player;
                            piecePlaced = true;
                        }
                    }
                }

                // checking vertically for block
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 6].Text == "O" && toeSquares[i + 3].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 3].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 3].Text == "O" && toeSquares[i + 6].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 6].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 6; i < 9; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i - 3].Text == "O" && toeSquares[i - 6].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i - 6].Text = player;
                        piecePlaced = true;
                    }
                }

                // checking horizontally for block
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 1].Text == "O" && toeSquares[i + 2].Text == "" && piecePlaced == false)
                    {
                        toeSquares[i + 2].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "" && toeSquares[i + 1].Text == "O" && toeSquares[i + 2].Text == "O" && piecePlaced == false)
                    {
                        toeSquares[i].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 1].Text == "" && toeSquares[i + 2].Text == "O" && piecePlaced == false)
                    {
                        toeSquares[i + 1].Text = player;
                        piecePlaced = true;
                    }
                }
            }
        }

        // random move if no block/win is possible
        private void Random_Move()
        {
            Random rndm = new Random();
            int rndmBlock;
            // while loop to find an empty space
            do
            {
                rndmBlock = rndm.Next(0, 9);
            } while (toeSquares[rndmBlock].Text != "" && moveCounter < 9);

            if (toeSquares[rndmBlock].Text == "" && piecePlaced == false)
            {
                toeSquares[rndmBlock].Text = player;
                piecePlaced = true;
            }
        }

        // event handler where all the action happen :P
        private void Square_Click (object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            if (win != true) // if structure to block the player from placing a piece is a win/cats game occurs
            {
                if (radBot.Checked) // calling on AI is rad button is checked
                {
                    if (currentLabel.Text == "X" || currentLabel.Text == "O") // prevent cheating
                    {
                        picLuckyLuke.Show();
                        picTextBubble.Show();
                        lblInstruct.Text = "Howdy partner! Just \r\nstoppin' by to tell ya \r\nthat's cheatin'!! Select \r\na different box, son!";
                    }
                    else // calling oon AI procedures
                    {
                        lblInstruct.Text = "";
                        player = "O";
                        currentLabel.Text = $"{player}";
                        picLuckyLuke.Hide();
                        picTextBubble.Hide();
                        lblInstructBot.Text = "";
                        piecePlaced = false;
                        moveCounter++;
                        Check_WinnerBot();                       
                        player = "X";
                        if (piecePlaced == false) // so not more than one piece is placed at once
                        {
                            Check_Center(currentLabel);
                            Check_for_Win(currentLabel);
                            Block_a_Win(currentLabel);
                            Random_Move();
                        }
                        moveCounter++;
                        Check_WinnerBot();
                    }
                }
                else if (radPlayer.Checked) // if vs player is checked
                {
                    if (currentLabel.Text == "X" || currentLabel.Text == "O") // prevent cheating
                    {
                        picLuckyLuke.Show();
                        picTextBubble.Show();
                        lblInstruct.Text = "Howdy partner! Just \r\nstoppin' by to tell ya \r\nthat's cheatin'!! Select \r\na different box, son!";
                    }
                    else // interchange between X and O
                    {
                        picLuckyLuke.Hide();
                        picTextBubble.Hide();
                        lblInstruct.Text = "";
                        if (player == "O")
                        {
                            currentLabel.Text = $"{player}";
                            moveCounter++;
                            Check_Winner();
                            player = "X";
                        }
                        else if (player == "X")
                        {
                            currentLabel.Text = $"{player}";
                            moveCounter++;
                            Check_Winner();
                            player = "O";
                        }
                    }
                }
            }
        }

        // restart button
        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toeSquares.Count(); i++)
            {
                toeSquares[i].Text = "";
            }
            lblInstruct.Text = "";
            lblInstructBot.Text = "";
            win = false;
            moveCounter = 0;
            picLuckyLuke.Hide();
            picTextBubble.Hide();
        }

        // checking for a win when vs player is on
        private void Check_Winner()
        {
            // horizontally
            if (lbl1.Text == player && lbl2.Text == player && lbl3.Text == player)
            {
                lblInstruct.Text = "I am all to pieces \r\nhappy that y'all had a \r\nswell time!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl4.Text == player && lbl5.Text == player && lbl6.Text == player)
            {
                lblInstruct.Text = "Three in a row!! Bam!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl7.Text == player && lbl8.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Yee-haw! I am no \r\nlonger all beer and skittles \r\never since you won!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // vertically
            else if (lbl1.Text == player && lbl4.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = "YEEHAWW!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl2.Text == player && lbl5.Text == player && lbl8.Text == player)
            {
                lblInstruct.Text = "I am all-fired \r\nhappy that you won, \r\npartner.";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl3.Text == player && lbl6.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Hoo-wee! That \r\nwas a hog-killing \r\ntime y'all had.";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // diagonally
            else if (lbl1.Text == player && lbl5.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Hoo-wee! Y'all \r\nsure as blazes were \r\nnot barkin' at a knot \r\nduring this game!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl3.Text == player && lbl5.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = "A win! Bully for you!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // cat's game
            else if (moveCounter == 9)
            {
                lblInstruct.Text = "Hoo-wee! I guess \r\nthat's a cat's game!";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
        }

        // checking for win when AI is on
        private void Check_WinnerBot()
        {
            // horizontally
            if (lbl1.Text == player && lbl2.Text == player && lbl3.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl4.Text == player && lbl5.Text == player && lbl6.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl7.Text == player && lbl8.Text == player && lbl9.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // vertically 
            else if (lbl1.Text == player && lbl4.Text == player && lbl7.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl2.Text == player && lbl5.Text == player && lbl8.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl3.Text == player && lbl6.Text == player && lbl9.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // diagonally
            else if (lbl1.Text == player && lbl5.Text == player && lbl9.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            else if (lbl3.Text == player && lbl5.Text == player && lbl7.Text == player)
            {
                lblInstructBot.Text = $"{player}'s won";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
            // cat's game
            else if (moveCounter == 9)
            {
                lblInstructBot.Text = $"Cat's game";
                win = true;
                picLuckyLuke.Show();
                picTextBubble.Show();
            }
        }
        // button to exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}