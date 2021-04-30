using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Utils
    {
        static void Step(int x, int y, int w, int h, Bitmap bitmap, Color originColor, Color fillColor, Queue<Point> q)
        {
            if (x >= 0 && y >= 0 && x < w && y < h)
            {
                if (bitmap.GetPixel(x, y) == originColor)
                {
                    bitmap.SetPixel(x, y, fillColor);        
                    q.Enqueue(new Point(x, y));
                }
            }
        }
        public static Bitmap Fill(
            Bitmap bitmap,
            Point originPoint,
            Color originColor,
            Color fillColor)
        {
            Queue<Point> q = new Queue<Point>();
            bitmap.SetPixel(originPoint.X, originPoint.Y, fillColor);
            q.Enqueue(originPoint);
            while (q.Count > 0)
            {
                Point cur = q.Dequeue();
                Step(cur.X + 1, cur.Y, bitmap.Width, bitmap.Height, bitmap, originColor, fillColor, q);
                Step(cur.X - 1, cur.Y, bitmap.Width, bitmap.Height, bitmap, originColor, fillColor, q);
                Step(cur.X, cur.Y + 1, bitmap.Width, bitmap.Height, bitmap, originColor, fillColor, q);
                Step(cur.X, cur.Y - 1, bitmap.Width, bitmap.Height, bitmap, originColor, fillColor, q);
            }
            return bitmap;
        }

     
    }

}
