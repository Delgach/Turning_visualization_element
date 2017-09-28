using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



namespace VisualizationElementOfTurning
{
    class Cutter : Tool
    {

        public Cutter(int x, int y)
        {
            defX = 500;
            defY = 50;
            points = new Point[8];
            points[0] = new Point(defX,defY);
            points[1] = new Point(defX, defY + (int)(y * 0.38));
            points[2] = new Point(defX + (int)(x * 0.4), defY + (int)(y * 0.46));
            points[3] = new Point(defX + (int)(x * 0.3), defY + y);
            points[4] = new Point(defX + (int)(x * 0.7), defY + y);
            points[5] = new Point(defX + (int)(x * 0.6), (int)((defY + y) * 0.6));
            points[6] = new Point(defX + x, defY + (int)(y * 0.38));
            points[7] = new Point(defX + x, defY);  
            
        }

        public Cutter(double x, double y) : this((int)x, (int)y)
        {

        }
    }
    
}
