using System;
using System.Text;

namespace PracticeForJudge.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage());
                }

                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage());
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage());
                }

                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (this.Length * this.Height) + 2 * (this.Length * this.Width) 
                + 2 * (this.Height * this.Width);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.Append($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();
        }
        private string ErrorMessage()
        {
            return $"{this.GetType().Name} cannot be zero or negative.";
        }
    }
}
