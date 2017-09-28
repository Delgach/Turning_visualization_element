using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BitmapProcessing;

namespace VisualizationElementOfTurning
{
    class WorkPiece
    {
        
        private BoolPoint[,] workPiece;
        private int height;
        private int width;

        public WorkPiece(int width, int hight)
        {
            this.width = width;
            this.height = hight;
            workPiece = new BoolPoint[width, hight];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    workPiece[i, j] = new BoolPoint(i + 50, j + 150);
                }
            }
        }
          
        public WorkPiece(double width, double height) : this((int) width, (int) height)
        {

        }
     


        public void Interaction(Tool tool)
        {
            if (tool.GetType() == typeof(Cutter))
            {
                Parallel.For(0, width, i =>
                    {
                        for (int j = 0; j < height/2; j++)
                        {
                            /*if (this.GetPoint(i, j).GetState())
                                continue;
                             */

                            if (this.GetPoint(i, j).GetY() == tool.GetPoint(3).Y && this.GetPoint(i, j).GetX() <= tool.GetPoint(4).X && this.GetPoint(i, j).GetX() >= tool.GetPoint(3).X)
                            {
                                this.GetPoint(i, j).SetStateTrue();
                                this.GetPoint(i, height - 1 - j).SetStateTrue();
                            }

                        }
                    });
            }
            else
            {
                Parallel.For(0, width, i =>
                {
                    for (int j = 0; j < height / 2; j++)
                    {
                        if (this.GetPoint(i, j).GetState())
                            continue;

                        if (this.GetPoint(i, j).GetY() <= tool.GetPoint(1).Y && this.GetPoint(i, j).GetX() == tool.GetPoint(0).X)
                        {
                            this.GetPoint(i, j).SetStateTrue();
                            this.GetPoint(i, height - 1 - j).SetStateTrue();
                        }

                    }
                });
            }
        }

        public void PaintFigure(FastBitmap bitmap)
        {
          bitmap.LockImage();
          for (int i = 0; i < width; i++)
            {
              for (int j = 0; j < height; j++)
                {
                    if (workPiece[i, j].GetState() == false)
                    {
                        bitmap.SetPixel(workPiece[i, j].GetX(), workPiece[i, j].GetY(), Color.Black);
                    }else
                    {
                        bitmap.SetPixel(workPiece[i, j].GetX(), workPiece[i, j].GetY(), Color.White);
                    }
                }
            }
            bitmap.UnlockImage();
        }

       
        public BoolPoint GetPoint(int x, int y)
        {
            return workPiece[x, y];
        }
        public void SetWorkPiece(BoolPoint[,] workPiece)
        {
            this.workPiece = workPiece;
        }

        public void Check()
        {
            Parallel.For(0, width, i =>
            {
                int count = 0;
                for (int j = 0; j < height / 2; j++)
                {
                    if (this.GetPoint(i, j).GetState())
                    {
                        count++;
                    }
                }
                if(count == height/2)
                {
                    SetAPartTrue(i);
                }
            });
           
        }

        public void SetAPartTrue(int w)
        {
            
            Parallel.For(w, width, i =>
            {
                for (int j = 0; j < height / 2; j++)
                {
                    this.GetPoint(i, j).SetStateTrue();
                    this.GetPoint(i, height - 1 - j).SetStateTrue();
                }
            });
        }


    }
}
