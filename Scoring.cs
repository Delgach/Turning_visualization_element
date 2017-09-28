using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VisualizationElementOfTurning
{
    class Scoring : Tool
    {
        
        public Scoring(int x, int y)
        {
            defX = 500;
            defY = 50;
            points = new Point[4];
            points[0] = new Point(defX, defY);
            points[1] = new Point(defX, defY + y);
            points[2] = new Point(defX + x, defY + (int)(y * 0.77));
            points[3] = new Point(defX + x, defY);
        }
        public Scoring(double x, double y) : this((int)x, (int)y)
        {
            
        }
    }
   
}
