using System;

namespace ClassBoxDataValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
