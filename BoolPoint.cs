using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VisualizationElementOfTurning
{
    class BoolPoint
    {
        private int x;
        private int y;
        private bool state;
        
      
     
        public BoolPoint(int x,int y)
        {
            this.x = x;
            this.y = y;
            state = false;
            
           
        }

        public void SetStateTrue()
        {
            state = true;
        }
        public bool GetState()
        {
            return state;
        }
        public int GetX()
        {
            return x;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
}
