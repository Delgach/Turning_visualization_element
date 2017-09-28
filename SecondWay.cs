using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VisualizationElementOfTurning
{
    class SecondWay : MyWay
    {
        public SecondWay()
        {
            way = new Point[5];
            way[0] = new Point(0, -50);
            way[1] = new Point(-320, 0);
            way[2] = new Point(0, 70);
            way[3] = new Point(0, -70);
            way[4] = new Point(250, 0);
        }
    }
}
