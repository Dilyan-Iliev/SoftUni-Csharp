﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width
        {
            get => width;
            private set { width = value; }
        }
        public int Height
        {
            get => height;
            private set { height = value; }
        }
        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));
            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine($"*{new string(' ', this.Width - 2)}*");
            }
            Console.WriteLine(new string('*', this.Width));
        }
    }
}
