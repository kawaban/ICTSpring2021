using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    enum Tool
    {
        Line,
        Rectangle,
        Pen,
        Fill,
        Eraser,
        Triangle,
        GDIFill,
        Circle,
        ColorPicker
    }

    public partial class Form1 : Form
    { 
       
        Bitmap bitmap = default(Bitmap);
        Graphics graphics = default(Graphics);
        Pen pen = new Pen(Color.Black, 1);
        Pen eraser = new Pen(Color.White, 3);
        Point prevPoint = default(Point);
        Point currentPoint = default(Point);
        bool isMousePressed = false;
        Tool currentTool = Tool.Pen;
        Color colorFill = Color.Red;
        Point tr1;
        Point tr2;
        Point tr3;


        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pictureBox1.Image = bitmap;
            graphics.Clear(Color.White);
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            numericUpDown2.ValueChanged += NumericUpDown2_ValueChanged;



        }

        public void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen = new Pen(colorDialog1.Color, float.Parse(numericUpDown1.Value.ToString()));
        }

        public void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            eraser = new Pen(Color.White, float.Parse(numericUpDown2.Value.ToString()));
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap = Bitmap.FromFile(openFileDialog1.FileName) as Bitmap;
                pictureBox1.Image = bitmap;
                graphics = Graphics.FromImage(bitmap);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        bitmap.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        bitmap.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        bitmap.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }


        Rectangle GetMRectangle(Point pPoint, Point cPoint)
        {
            return new Rectangle
            {
                X = Math.Min(pPoint.X, cPoint.X),
                Y = Math.Min(pPoint.Y, cPoint.Y),
                Width = Math.Abs(pPoint.X - cPoint.X),
                Height = Math.Abs(pPoint.Y - cPoint.Y)
            };
        }

       


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePressed)
            {
                switch (currentTool)
                {
                    case Tool.Line: 
                    case Tool.Rectangle:
                        currentPoint = e.Location;
                        break;
                    case Tool.Circle:
                        currentPoint = e.Location;
                        break;
                    case Tool.Pen:
                        prevPoint = currentPoint;
                        currentPoint = e.Location;
                        graphics.DrawLine(pen, prevPoint, currentPoint);
                        break;
                    case Tool.Eraser:
                        prevPoint = currentPoint;
                        currentPoint = e.Location;
                        graphics.DrawLine(eraser, prevPoint, currentPoint);
                        break;
                    default:
                        break;
                }

                pictureBox1.Refresh();
            }
        }

     

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
            currentPoint = e.Location;
            isMousePressed = true;

            switch (currentTool)
            {

                case Tool.Fill:
                    currentPoint = e.Location;
                    bitmap = Utils.Fill(bitmap, currentPoint, bitmap.GetPixel(e.X, e.Y), colorFill);
                    graphics = Graphics.FromImage(bitmap);
                    pictureBox1.Image = bitmap;
                    pictureBox1.Refresh();
                    break;
                case Tool.GDIFill:
                   
                    MapFill mf = new MapFill();
                    mf.Fill(graphics, currentPoint, colorFill, ref bitmap);
                    graphics = Graphics.FromImage(bitmap);
                    pictureBox1.Image = bitmap;
                    pictureBox1.Refresh();
                    break;
              
                default:
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMousePressed = false;

            switch (currentTool)
            {
                case Tool.Line:
                    graphics.DrawLine(pen, prevPoint, currentPoint);
                    break;
                case Tool.Rectangle:
                    graphics.DrawRectangle(pen, GetMRectangle(prevPoint, currentPoint));
                    break;
              
                case Tool.Circle:
                    graphics.DrawEllipse(pen, GetMRectangle(prevPoint, currentPoint));
                    break;
                case Tool.Pen:
                    break;
                case Tool.Eraser:
                    break;
                case Tool.Fill:
               
                    break;
                default:
                    break;
            }
            prevPoint = e.Location;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            switch (currentTool)
            {
                case Tool.Line:
                    e.Graphics.DrawLine(pen, prevPoint, currentPoint);
                    break;
                case Tool.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetMRectangle(prevPoint, currentPoint));
                    break;
              
                case Tool.Circle:
                    e.Graphics.DrawEllipse(pen, GetMRectangle(prevPoint, currentPoint));
                    break;
                case Tool.Pen:
                    break;
                case Tool.Eraser:
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Rectangle;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Fill;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
          
            pen = new Pen(colorDialog1.Color, float.Parse(numericUpDown1.Value.ToString()));

            if(currentTool == Tool.GDIFill || currentTool == Tool.Fill)
            {
                colorFill = colorDialog1.Color;
              
            }
            
                
              
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Triangle;
 

        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTool = Tool.GDIFill;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Circle;
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            currentTool = Tool.ColorPicker;
        }
    }
}
