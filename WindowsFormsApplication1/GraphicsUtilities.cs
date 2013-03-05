using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

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
