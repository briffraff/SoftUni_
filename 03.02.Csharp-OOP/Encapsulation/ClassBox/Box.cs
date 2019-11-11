using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box()
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        //Volume = lwh
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh

        public static void GetVolume(double l, double w, double h)
        {
            double result = (l * w * h);
            Console.WriteLine($"Volume - {result:f2}");
        }

        public static void LateralSurfaceArea(double l, double w, double h)
        {
            double result = (2 * l * h) + (2 * w * h);
            Console.WriteLine($"Lateral Surface Area - {result:f2}");
        }

        public static void SurfaceArea(double l, double w, double h)
        {
            double result = (2 * l * w) + (2 * l * h) + (2 * w * h);
            Console.WriteLine($"Surface Area - {result:f2}");
        }
    }
}
