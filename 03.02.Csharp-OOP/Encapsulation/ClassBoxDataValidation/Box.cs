using System;
using System.Runtime.CompilerServices;

namespace ClassBoxDataValidation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        //Volume = lwh
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh

        public double GetVolume()
        {
            return Length * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }

        public double SurfaceArea()
        {
            return (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        }
    }
}
