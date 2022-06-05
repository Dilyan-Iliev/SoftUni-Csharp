using System;
using System.Collections.Generic;
using System.Text;

namespace P._01_ClassBoxData
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
            get => this.length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            double area = 2 * (this.length * this.height) + 2 * (this.length * this.width) + 2 * (this.height * this.width);

            return area;
        }
        public double LateralSurfaceArea()
        {
            double area = 2 * (this.length * this.height) + 2 * (this.width * this.height);

            return area;
        }
        public double Volume()
        {
            double area = this.length * this.width * this.height;

            return area;
        }
        
    }
}
