using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VisualizationElementOfTurning
{
    class FirstWay : MyWay
    {
       
        public FirstWay()
        {
            indexOfWay = 0;
           
             way =  new Point[7];
             way[0] = new Point(-300,0);
             way[1] = new Point(-20,-20);
             way[2] = new Point(-50,0);
             way[3] = new Point(-20,20);
             way[4] = new Point(-50, 0);
             way[5] = new Point(0, -50);
             way[6] = new Point(300, 0);
        }
  
    }
}
