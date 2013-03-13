using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using System.Drawing;

namespace TowerDefense
{
    public class GraphicsUtilities
    {
        public static void setWindow(double left, double right, double bottom, double top)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(left, right, bottom, top);
        }

        public static void setViewport(int left, int bottom, int width, int height)
        {
            Gl.glViewport(left, bottom, width, height);
        }

        //Draws a unit square around a given center point
        public static void drawUnitSquare(double cx, double cy)
        {
            Gl.glBegin(Gl.GL_POLYGON);
            {
                Gl.glVertex2d(cx - 0.5, cy - 0.5);
                Gl.glVertex2d(cx - 0.5, cy + 0.5);
                Gl.glVertex2d(cx + 0.5, cy + 0.5);
                Gl.glVertex2d(cx + 0.5, cy - 0.5);
            }
            Gl.glEnd();
        }

        public static void drawUnitSquareLines(double cx, double cy)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glVertex2d(cx - 0.5, cy - 0.5);
                Gl.glVertex2d(cx - 0.5, cy + 0.5);
                Gl.glVertex2d(cx + 0.5, cy + 0.5);
                Gl.glVertex2d(cx + 0.5, cy - 0.5);
            }
            Gl.glEnd();
        }

        public static double pointFromWindowToWorld(double Wx, double Wl, double Sr, double Sl, double Wr)
        {
            return (((Wx - Wl) * (Sr - Sl)) / (Wr - Wl)) + Sl;
        }

        public static double pointFromWorldToWindow(double Sx, double Sl, double Wr, double Wl, double Sr)
        {
            return (((Sx - Sl) * (Wr - Wl)) / (Sr - Sl)) + Wl;
        }

        //public static double dotProduct(Vector3 a, Vector3 b)
        //{
        //    return ((a.X * b.X) + (a.Y * b.Y));
        //}

        //public static Vector3 crossProduct(Vector3 a, Vector3 b)
        //{
        //    return new Vector3((a.Y * b.Z) - (a.Z * b.Y), (a.Z * b.X) - (a.X * b.Z), (a.X * b.Y) - (a.Y * b.X));
        //}


        //DOES NOT WORK
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            //gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }


        public static double degreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double radiansToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }
    }
}
