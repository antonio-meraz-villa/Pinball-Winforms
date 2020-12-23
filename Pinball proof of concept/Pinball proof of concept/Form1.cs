using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinball_proof_of_concept
{
    public partial class Form1 : Form
    {
        int speed = 5; // integer called speed holding value of 5
        int bally = 15; // horizontal X speed value for the ball object 
        int ballx = 5; // vertical Y speed value for the ball object
        int scores = 0; // score for the player
        public Form1()
        {
            InitializeComponent();
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {

            // if the ball hits the player or the CPU
            if (ball.Bounds.IntersectsWith(paletader.Bounds) || ball.Bounds.IntersectsWith(paletaizq.Bounds))
            {
                // then bounce the ball in the other direction
                ballx = -ballx;
            }

            score.Text = "" + scores; // show player score on label 1
            
            ball.Top -= bally; // assign the ball TOP to ball Y integer
            ball.Left -= ballx; // assign the ball LEFT to ball X integer

            if (ball.Bounds.IntersectsWith(barrader.Bounds)||
                ball.Bounds.IntersectsWith(barraizq.Bounds)
               )
            {
                ballx = -ballx;
            }

            if (ball.Bounds.IntersectsWith(barratop.Bounds)||
                ball.Bounds.IntersectsWith(paletader.Bounds)||
                ball.Bounds.IntersectsWith(paletaizq.Bounds)
                )
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(limit.Bounds))
            {
                endGame();
            }

            if (ball.Bounds.IntersectsWith(objsid1.Bounds) ||
                ball.Bounds.IntersectsWith(objsid2.Bounds) ||
                ball.Bounds.IntersectsWith(objsid3.Bounds) ||
                ball.Bounds.IntersectsWith(objsid4.Bounds) ||
                ball.Bounds.IntersectsWith(objsid5.Bounds) ||
                ball.Bounds.IntersectsWith(objsid6.Bounds))
            {
                ballx = -ballx;
                scores++;
            }

            if(ball.Bounds.IntersectsWith(objtop1.Bounds) ||
                ball.Bounds.IntersectsWith(objtop2.Bounds) ||
                ball.Bounds.IntersectsWith(objtop3.Bounds) ||
                ball.Bounds.IntersectsWith(objdwn1.Bounds) ||
                ball.Bounds.IntersectsWith(objdwn2.Bounds) ||
                ball.Bounds.IntersectsWith(objdwn3.Bounds))
            {
                bally = -bally;
                scores++;
            }
        }
        private void endGame()
        {
            gametimer.Stop();
            score.Text += " Game Over";
        }

        private void keyisdwn(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Right)
            {
                paletader.Top = 374;
            }

            if (e.KeyCode == Keys.Left)
            {
                paletaizq.Top = 374;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                paletader.Top = 407;
            }

            if (e.KeyCode == Keys.Left)
            {
                paletaizq.Top = 407;
            }
        }
    }
}
