using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wunsz
{
    public partial class Form1 : Form
    {
        private bool game_active;
        private Snake snake;
        private Fruit fruit;

        public Form1()
        {
            InitializeComponent();
            game_active = false;   
            timer1.Enabled = true;
            pauzaToolStripMenuItem.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game_active)
            {
                game_field.CreateGraphics().Clear(Color.Black);
                snake.move();
                snake.draw(game_field.CreateGraphics(), new SolidBrush(Color.AntiqueWhite));
                fruit.draw_fruit(game_field.CreateGraphics(), new SolidBrush(Color.Red));
                if (fruit.need_new_fruit(snake.x[0], snake.y[0]))
                {
                    snake.add();
                }
                if (snake.is_snake_alive() == false)
                {
                    game_field.CreateGraphics().Clear(Color.Black);
                    game_active = false;
                }
            }
            else
            {
                FontFamily fontFamily1 = new FontFamily("Arial");
                Font f = new Font(fontFamily1, 15);
                Brush b = new SolidBrush(Color.Green);
                game_field.CreateGraphics().DrawString("Push 'Start' button", f, b, 50, 135);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game_active = true;
            snake = new Snake(game_field.Width, game_field.Height);
            fruit = new Fruit(snake.segment);
            pauzaToolStripMenuItem.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) snake.movement = "up";
            if (e.KeyCode == Keys.Down) snake.movement = "down";
            if (e.KeyCode == Keys.Left) snake.movement = "left";
            if (e.KeyCode == Keys.Right) snake.movement = "right";
        }

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game_active)
            {
                game_active = false;
                pauzaToolStripMenuItem.Text = "Resume";
            }
            else
            {
                game_active = true;
                pauzaToolStripMenuItem.Text = "Pause";
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game_active)
            {
                snake = new Snake(game_field.Width, game_field.Height);
                fruit = new Fruit(snake.segment);
            }
        }

     
        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval += 10; 
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e) // czyli Speed Up //
        {
            if (timer1.Interval >10) { timer1.Interval -= 10; }
        }
    }
}
