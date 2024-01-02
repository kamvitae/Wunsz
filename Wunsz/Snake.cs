using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wunsz
{
    class Snake
    {
        public int segments;
        public int segment;
        public int[] x = new int[900];
        public int[] y = new int[900];
        public string movement;

        public Snake(int width, int height)
        {
            segment = width / 20;
            segments = 3;
            movement = "right";
            int xg = segment * 9;
            int yg = segment * 9;
            for (int i = 0; i < segments; i++)
            {
                x[i] = xg - (i * segment);
                y[i] = yg;
            }

            
        }

        public void move()
        {
            for (int i = segments; i > 0; i--)
            {
                x[i] = x[(i - 1)];
                y[i] = y[(i - 1)];
            }
            if (movement == "left")
            {
                x[0] = x[0] - segment;
            }
            if (movement == "right")
            {
                x[0] = x[0] + segment;
            }
            if (movement == "up")
            {
                y[0] -= segment; 
            }
            if (movement == "down")
            {
                y[0] += segment;
            }
            if (x[0] < 0) { x[0] = segment * 19; }
            if (y[0] < 0) { y[0] = segment * 19; }
            if (x[0] > segment * 19) { x[0] = 0; }
            if (y[0] > segment * 19) { y[0] = 0; }
        }

        public void draw(Graphics g, Brush b)
        {
            g.FillRectangle(new SolidBrush(Color.Green), x[0], y[0], segment, segment);
            for (int i = 1; i < segments; i++)
            {
                g.FillRectangle(b , x[i], y[i], segment, segment);
            }
        }

        public void add()
        {
            x[segments] = x[segments - 1];
            y[segments] = y[segments - 1];
            segments = segments + 1;
        }

        public bool is_snake_alive()
        {
            for (int i = 1; i < segments; i++)
            {
                if (x[0] == x[i] && y[0] == y[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
  
}
