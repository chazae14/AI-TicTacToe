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

        string player = "O";
        Label[] toeSquares;
        bool win;
        bool piecePlaced;
        int moveCounter = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            toeSquares = new Label[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9 };
            for (int i = 0; i < toeSquares.Count(); i++)
            {
                toeSquares[i].Click += new EventHandler(Square_Click);
            }
        }

        private void Check_Center(Label currentLabel)
        {
            if (currentLabel != lbl5 && lbl5.Text == "")
            {
                lbl5.Text = player;
            }
            else if (currentLabel == lbl5 && lbl3.Text == "")
            {
                lbl3.Text = player;
            }
        }
        private void Check_for_Win(Label currentLabel)
        {
            piecePlaced = false;
            if (piecePlaced == false)
            {
                // columns
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 6].Text == "X" && toeSquares[i + 3].Text == "")
                    {
                        toeSquares[i + 3].Text = player;
                        piecePlaced = true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 3].Text == "X" && toeSquares[i + 6].Text == "")
                    {
                        toeSquares[i + 6].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 6; i < 9; i++)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i - 3].Text == "X" && toeSquares[i - 6].Text == "")
                    {
                        toeSquares[i - 6].Text = player;
                        piecePlaced = true;

                    }
                }

                // rows
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 1].Text == "X" && toeSquares[i + 2].Text == "")
                    {
                        toeSquares[i + 2].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "" && toeSquares[i + 1].Text == "X" && toeSquares[i + 2].Text == "X")
                    {
                        toeSquares[i].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "X" && toeSquares[i + 1].Text == "" && toeSquares[i + 2].Text == "X")
                    {
                        toeSquares[i + 1].Text = player;
                        piecePlaced = true;

                    }
                }


                // diagonal
                for (int i = 2; i < 6; i += 2)
                {
                    if (i == 2 && currentLabel != toeSquares[2])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 2].Text == "X" && toeSquares[i + 4].Text == "X")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 4 && currentLabel != toeSquares[4])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "X" && toeSquares[i - 4].Text == "X")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 6 && currentLabel != toeSquares[6])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "X" && toeSquares[i + 2].Text == "X")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 0 && currentLabel != toeSquares[0])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 4].Text == "X" && toeSquares[i + 8].Text == "X")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 0 && currentLabel == toeSquares[0])
                    {
                        if (toeSquares[i].Text == "X" && toeSquares[i + 4].Text == "X" && toeSquares[i + 8].Text == "")
                        {
                            toeSquares[i + 8].Text = player;
                            piecePlaced = true;

                        }
                    }
                }
            }
            else
            {
                Block_a_Win(currentLabel);
            }
            
        }

        private void Block_a_Win(Label currentLabel)
        {
            piecePlaced = false;
            if (piecePlaced == false)
            {
                // columns
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 6].Text == "O" && toeSquares[i + 3].Text == "")
                    {
                        toeSquares[i + 3].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 3].Text == "O" && toeSquares[i + 6].Text == "")
                    {
                        toeSquares[i + 6].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 6; i < 9; i++)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i - 3].Text == "O" && toeSquares[i - 6].Text == "")
                    {
                        toeSquares[i - 6].Text = player;
                        piecePlaced = true;

                    }
                }

                // rows
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 1].Text == "O" && toeSquares[i + 2].Text == "")
                    {
                        toeSquares[i + 2].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "" && toeSquares[i + 1].Text == "O" && toeSquares[i + 2].Text == "O")
                    {
                        toeSquares[i].Text = player;
                        piecePlaced = true;

                    }
                }
                for (int i = 0; i < 9; i += 3)
                {
                    if (toeSquares[i].Text == "O" && toeSquares[i + 1].Text == "" && toeSquares[i + 2].Text == "O")
                    {
                        toeSquares[i + 1].Text = player;
                        piecePlaced = true;

                    }
                }


                // diagonal
                for (int i = 0; i < 6; i += 2)
                {
                    if (i == 2 && currentLabel != toeSquares[2])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 2].Text == "O" && toeSquares[i + 4].Text == "O")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 4 && currentLabel != toeSquares[4])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "O" && toeSquares[i - 4].Text == "O")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 6 && currentLabel != toeSquares[6])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i - 2].Text == "O" && toeSquares[i + 2].Text == "O")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 0 && currentLabel != toeSquares[0])
                    {
                        if (toeSquares[i].Text == "" && toeSquares[i + 4].Text == "O" && toeSquares[i + 8].Text == "O")
                        {
                            toeSquares[i].Text = player;
                            piecePlaced = true;

                        }
                    }
                    else if (i == 0 && currentLabel == toeSquares[0])
                    {
                        if (toeSquares[i].Text == "O" && toeSquares[i + 4].Text == "O" && toeSquares[i + 8].Text == "")
                        {
                            toeSquares[i + 8].Text = player;
                            piecePlaced = true;

                        }
                    }
                }
            }
            else
            {
                Random_Move();
            }
        }

        private void Random_Move()
        {
            Random rndm = new Random();
            int rndmBlock;
            do
            {
                rndmBlock = rndm.Next(0, 9);
            } while (toeSquares[rndmBlock].Text != "");

            if (toeSquares[rndmBlock].Text == "")
            {
                toeSquares[rndmBlock].Text = player;
                piecePlaced = true;
            }
        }


        private void Square_Click (object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            if (win != true)
            {
                if (radBot.Checked)
                {
                    if (currentLabel.Text == "X" || currentLabel.Text == "O")
                    {
                        lblInstruct.Text = "Howdy partner! Just stoppin' \r\nby to tell ya that's cheatin'!!\r\nSelect a different box, son!\r\n";
                    }
                    else
                    {
                        lblInstruct.Text = "";
                        player = "O";
                        currentLabel.Text = $"{player}";
                        moveCounter++;
                        Check_WinnerBot();
                        player = "X";
                        Check_Center(currentLabel);
                        Check_for_Win(currentLabel);
                        moveCounter++;
                        piecePlaced = false;
                        Check_WinnerBot();
                    }
                }
                else if (radPlayer.Checked)
                {
                    if (currentLabel.Text == "X" || currentLabel.Text == "O")
                    {
                        lblInstruct.Text = "Howdy partner! Just stoppin' \r\nby to tell ya that's cheatin'!!\r\nSelect a different box, son!\r\n";
                    }
                    else
                    {
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

        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toeSquares.Count(); i++)
            {
                toeSquares[i].Text = "";
            }
            lblInstruct.Text = "";
            win = false;
            moveCounter = 0;
        }
        private void Check_Winner()
        {
            if (lbl1.Text == player && lbl2.Text == player && lbl3.Text == player)
            {
                lblInstruct.Text = "I am all to pieces happy  \r\nthat y'all had a swell time!";
                win = true;
            }
            else if (lbl4.Text == player && lbl5.Text == player && lbl6.Text == player)
            {
                lblInstruct.Text = "Three in a row!! Bam!";
                win = true;
            }
            else if (lbl7.Text == player && lbl8.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Yee-haw! I am no longer all  \r\nbeer and skittles ever since \r\nyou won!";
                win = true;
            }

            else if (lbl1.Text == player && lbl4.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = "YEEHAWW!";
                win = true;
            }
            else if (lbl2.Text == player && lbl5.Text == player && lbl8.Text == player)
            {
                lblInstruct.Text = "I am all-fired happy that  \r\nyou won, partner.";
                win = true;
            }
            else if (lbl3.Text == player && lbl6.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Hoo-wee! That was a  \r\nhog-killing time y'all had.";
                win = true;
            }

            else if (lbl1.Text == player && lbl5.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = "Hoo-wee! Y'all sure as blazes  \r\nwere not barkin' at a knot  \r\nduring this game!";
                win = true;
            }
            else if (lbl3.Text == player && lbl5.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = "A win! Bully for you!";
                win = true;
            }

            else if (moveCounter == 9)
            {
                lblInstruct.Text = "Hoo-wee! I guess that's \r\na cat's game!";
                win = true;
            }
        }
        private void Check_WinnerBot()
        {
            if (lbl1.Text == player && lbl2.Text == player && lbl3.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }
            else if (lbl4.Text == player && lbl5.Text == player && lbl6.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }
            else if (lbl7.Text == player && lbl8.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }

            else if (lbl1.Text == player && lbl4.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }
            else if (lbl2.Text == player && lbl5.Text == player && lbl8.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }
            else if (lbl3.Text == player && lbl6.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }

            else if (lbl1.Text == player && lbl5.Text == player && lbl9.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }
            else if (lbl3.Text == player && lbl5.Text == player && lbl7.Text == player)
            {
                lblInstruct.Text = $"{player}'s won";
                win = true;
            }

            else if (moveCounter == 9)
            {
                lblInstruct.Text = $"Cat's game";
                win = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}