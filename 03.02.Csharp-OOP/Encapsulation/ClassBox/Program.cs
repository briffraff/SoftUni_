﻿using System;

namespace ClassBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box.SurfaceArea(lenght,width,height);
            Box.LateralSurfaceArea(lenght,width,height);
            Box.GetVolume(lenght, width, height);
            
        }
    }
}
