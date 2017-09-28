using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace VisualizationElementOfTurning
{
   
    class ReadWay
    {
        private StreamReader reader;
        private String line;
        protected Point[] coordinates;
        protected int indexOfWay;
        protected int count;
        

        public ReadWay(String way)
        {
            try
            {
                indexOfWay = 0;
                count = 0;
                coordinates = new Point[100];
                reader = new StreamReader(way);
                
             
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadFile()
        {
           
            
            while (!reader.EndOfStream)
            {
                try
                {
                    line = reader.ReadLine();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                String[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int x = 0;
                int y = 0;
                char[] n;
                
                for (int i = 0; i < split.Length; i++)
                {

                    if (split[i].Contains('X') || split[i].Contains('x'))
                    {
                        
                        n = split[i].ToCharArray();
                        string v = "";
                        for (int j = 1; j < n.Length; j++ )
                        {
                            v += n[j];
                        }
                        
                            x = Convert.ToInt32(v);


                    }
                    if (split[i].Contains('Y') || split[i].Contains('y'))
                    {
                        n = split[i].ToCharArray();
                        string v = "";
                        for (int j = 1; j < n.Length; j++)
                        {
                            v += n[j];
                        }
                        y = Convert.ToInt32(v);
                    }
                    
                   
                    


                }

                coordinates[count] = new Point(x, y);
                count++;
            }
            reader.Close();

        }
        public void Moving(Tool tool)
        {
            if (coordinates[indexOfWay].X == 0 && coordinates[indexOfWay].Y == 0 && indexOfWay < count - 1)
            {
                indexOfWay++;
            }
            if (coordinates[indexOfWay].X < 0)
            {
                tool.MoveLeft();
                coordinates[indexOfWay].X += 1;   
            }

            if (coordinates[indexOfWay].X > 0)
            {
                tool.MoveRight();
                coordinates[indexOfWay].X -= 1;
            }
            if (coordinates[indexOfWay].Y > 0)
            {
                tool.MoveDown();
                coordinates[indexOfWay].Y -= 1;
            }
            if (coordinates[indexOfWay].Y < 0)
            {
                tool.MoveUp();
                coordinates[indexOfWay].Y += 1;
            }
        }
    }
}
