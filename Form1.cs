using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);

            Pen withPen=new Pen(white);
            withPen.Width = 15;

            withPen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            withPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(withPen, 400, 250, 1000, 250);
            e.Graphics.DrawLine(withPen, 400, 370, 1000, 370);

            e.Graphics.DrawLine(withPen, 600, 140, 600, 500);
            e.Graphics.DrawLine(withPen, 800, 140, 800, 500);

        }

        stGameStatus GameStatus;
        enPlayer TurnPlayer = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }


        public bool CheckValues(Button button1, Button button2, Button button3)
        {

            if (button1.Tag.ToString() != "?" && button1.Tag.ToString() == button2.Tag.ToString() && button1.Tag.ToString() == button3.Tag.ToString())
            {
                button1.BackColor = Color.GreenYellow;
                button2.BackColor = Color.GreenYellow;
                button3.BackColor = Color.GreenYellow;

                if(button1.Tag.ToString()=="X")
                {
                    GameStatus.Winner = enWinner.Player1;  
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatus.GameOver = false;
            return false;
        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch(GameStatus.Winner)
            {

                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over","Game Over",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void CheckWinner()
        {

            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;


            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;


            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

        }



        public void ChangeImage(Button btn)
        {

            if(btn.Tag.ToString()=="?")
            {

                switch (TurnPlayer)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        TurnPlayer = enPlayer.Player2;
                        lblTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        TurnPlayer = enPlayer.Player1;
                        lblTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice!","Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount==9)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;
                EndGame();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        private void Restart()
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            TurnPlayer = enPlayer.Player1;
            lblTurn.Text = "Player1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            lblWinner.Text = "In Progress";
            GameStatus.Winner = enWinner.GameInProgress;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
