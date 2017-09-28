using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;                          //нужно избавиться от длишних классов
using System.Threading;
using System.Windows.Forms;
using BitmapProcessing;

namespace VisualizationElementOfTurning
{
    public partial class MainForm : Form
    {
         
        Tool tool = null;
        Bitmap bitmap = null;
        FastBitmap fast_bmp = null;
        WorkPiece workPiece = null;
        ReadWay readWay = null;
      //  MyWay way = null;
        int width;
        int height;
        int toolWidth;
        int toolHeight;
        Thread t;
        delegate void myDelegate();
        myDelegate de;
        myDelegate FTW;
               
        public MainForm()
        {                                       
            InitializeComponent();
           // way = new FirstWay();
           
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            fast_bmp = new FastBitmap(bitmap);
            if(textBox1.Text.Contains("."))
            {
                width = (int)Convert.ToDouble(textBox1.Text);
            }
            else width = Convert.ToInt32(textBox1.Text);
            if(textBox2.Text.Contains("."))
            {
                height = (int)Convert.ToDouble(textBox2.Text);
            }
            else height = Convert.ToInt32(textBox2.Text);
            if(textBox3.Text.Contains("."))
            {
                toolWidth = (int) Convert.ToDouble(textBox3.Text);
            }
            else toolWidth = Convert.ToInt32(textBox3.Text);
            if(textBox4.Text.Contains("."))
            {
                toolHeight = (int)Convert.ToDouble(textBox4.Text);
            }
            else toolHeight = Convert.ToInt32(textBox4.Text);
            tool = new Scoring(toolWidth, toolHeight);
            workPiece = new WorkPiece(width, height);
            FTW = new myDelegate(Repaint);
            DoubleBuffered = true;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
          Graphics g_bmp = Graphics.FromImage(bitmap);
          g_bmp.Clear(Color.White);
          workPiece.PaintFigure(fast_bmp);
          tool.PaintFigure(g_bmp); 
          e.Graphics.DrawImageUnscaled(bitmap, new Point(0, 0));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(!radioButton3.Checked )
            {
                if (openFileDialog1.FileName != null)
                {
                    readWay.Moving(tool);
                }
                else
                {
                    //way.Moving(tool);
                }
            }

            FTW();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                
                timer1.Enabled = false;
                button1.Text = "Stop";
               
            }
            else
            {
                if (!radioButton3.Checked && openFileDialog1.FileName != openFileDialog1.InitialDirectory)
                {
                    readWay = new ReadWay(openFileDialog1.FileName);
                    readWay.ReadFile();
                }
                 
                timer1.Enabled = true;
                button1.Text = "Start";
            }

        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
          
          bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
          fast_bmp = new FastBitmap(bitmap);
          if (textBox1.Text.Contains(","))
          {
              width = (int)Convert.ToDouble(textBox1.Text);
          }
          else width = Convert.ToInt32(textBox1.Text);
          if (textBox2.Text.Contains(","))
          {
              height = (int)Convert.ToDouble(textBox2.Text);
          }
          else height = Convert.ToInt32(textBox2.Text);
          if (textBox3.Text.Contains(","))
          {
              toolWidth = (int)Convert.ToDouble(textBox3.Text);
          }
          else toolWidth = Convert.ToInt32(textBox3.Text);
          if (textBox4.Text.Contains(","))
          {
              toolHeight = (int)Convert.ToDouble(textBox4.Text);
          }
          else toolHeight = Convert.ToInt32(textBox4.Text);

          /*width = Convert.ToInt32(textBox1.Text);
          height = Convert.ToInt32(textBox2.Text);
          toolWidth = Convert.ToInt32(textBox3.Text);
          toolHeight = Convert.ToInt32(textBox4.Text);*/

         if(radioButton1.Checked == true)
         {
             tool = new Scoring(toolWidth, toolHeight);
         }
         else
         {
             tool = new Cutter(toolWidth, toolHeight);

         }
          workPiece = new WorkPiece(width, height);
          
          pictureBox1.Invalidate();
        }

        private void buttonUp_MouseDown(object sender, MouseEventArgs e)
        {
            de = new myDelegate(GoUp);
            ThreadStart del = new ThreadStart(de);
            t = new Thread(del);
            t.Start();
        }

        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            t.Abort();
        }


        public void GoUp()
        {
            while(true)
            {
                tool.MoveUp();
                FTW();
            }
        }

        public void GoLeft()
        {
            while (true)
            {
                tool.MoveLeft();
                FTW();
            }
        }
        public void GoDown()
        {
            while (true)
            {
                tool.MoveDown();
                FTW();
            }
        }
        public void GoRight()
        {
            while (true)
            {
                tool.MoveRight();
                FTW();
            }
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            de = new myDelegate(GoLeft);
            ThreadStart del = new ThreadStart(de);
            t = new Thread(del);
            t.Start();
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            t.Abort();
        }

        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            de = new myDelegate(GoDown);
            ThreadStart del = new ThreadStart(de);
            t = new Thread(del);
            t.Start();
        }

        private void buttonDown_MouseUp(object sender, MouseEventArgs e)
        {
            t.Abort();
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            de = new myDelegate(GoRight);
            ThreadStart del = new ThreadStart(de);
            t = new Thread(del);
            t.Start();
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            t.Abort();
        }

        public void Repaint()
        {
            workPiece.Interaction(tool);
            workPiece.Check();
            pictureBox1.Invalidate();
        }

        private void opebFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

      

      
    }
}
