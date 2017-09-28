using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VisualizationElementOfTurning
{
     class Tool
    {

        protected int defX;
        protected int defY;
        protected Point[] points;
        public Tool()
        {
    
        }
        public void PaintFigure(Graphics graphics)
        {
            graphics.DrawPolygon(new Pen(Color.DarkGray, 1), points);
            graphics.FillPolygon(new SolidBrush(Color.DarkGray), points);
        }

        public void MoveRight()
        {
            for( int i = 0 ; i < points.Length; i++)
            {
                points[i].X += 1;   
            }
        }
        public void MoveDown()
        {
            for( int i = 0 ; i < points.Length; i++)
            {
                points[i].Y += 1;
            }
        }
        public void MoveLeft()
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i].X -= 1;
            }
        }


        public void MoveUp()
        {
            for (int i = 0; i < points.Length; i++)
            {
              points[i].Y -= 1;
            }
        }

        public Point GetPoint(int i)
        {
            return points[i];
        }
        
        public void SetDefX(int x)
        {
            defX = x;
        }

         public void SetDefY(int y)
        {
            defY = y;
        }

         public int GetDefX()
         {
             return defX;
         }

         public int GetDefY()
         {
             return defY;
         }
    }
}
