using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VisualizationElementOfTurning
{

    class MyWay
    {
        protected Point[] way;
        protected int indexOfWay;

        public MyWay()
        {

        }
        public void Moving(Tool tool)
        {
            if (way[indexOfWay].X == 0 && way[indexOfWay].Y == 0 && indexOfWay < way.Length - 1)
            {
                indexOfWay += 1;
            }
            if (way[indexOfWay].X < 0)
            {
                tool.MoveLeft();
                way[indexOfWay].X += 1;
            }

            if (way[indexOfWay].X > 0)
            {
                tool.MoveRight();
                way[indexOfWay].X -= 1;
            }
            if (way[indexOfWay].Y > 0)
            {
                tool.MoveDown();
                way[indexOfWay].Y -= 1;
            }
            if (way[indexOfWay].Y < 0)
            {
                tool.MoveUp();
                way[indexOfWay].Y += 1;
            }
        }
    }
}
