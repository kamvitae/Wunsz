using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wunsz
{
    class Fruit
    {
        public int x;
        public int y;
        public int segment;

        public Fruit (int segment)
        {
            this.segment = segment;
            new_fruit();
        }

        public void new_fruit()
        {
            Random r = new Random();
            x = r.Next(0, 20) * segment;
            y = r.Next(0, 20) * segment;
        }

        public bool need_new_fruit(int head_x, int head_y)
        {
            if ( x == head_x && y == head_y)
            {
                new_fruit();
                return true;
            }
            return false;
        }

        public void draw_fruit(Graphics g, Brush b)
        {
            g.FillRectangle(b, x, y, segment, segment);
        }
    }
}
