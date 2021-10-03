using System;

namespace Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.Title = "Dreieck";
                Console.Clear();

                // new instance of a triangle
                Triangle t1 = new Triangle(Input("a: "),
                                           Input("b: "),
                                           Input("c: "));

                if (t1.IsTriangular())
                {
                    // Print circumference and area of given triangle
                    Console.WriteLine("\nCircumference: {0}\nArea: {1}",
                                        t1.Circumference(),
                                        Math.Round(t1.Area(), 3));
                }
                else 
                    Console.WriteLine("Wrong inputs, could not generate a triangle ...");

            } while (Retry());
        }


        public static bool Retry()
        {
            // Characters that give back true when pressed
            char[] s = { 'j', 'J', 'y', 'Y' };

            Console.Write("Retry? (Y/N) ");
            return s.Contains(Console.ReadKey(true).KeyChar);
        }


        // Prompt the user for an input an return parsed double value
        public static double Input(string s)
        {
            // Print prompt
            Console.Write(s);
            if (double.TryParse(Console.ReadLine(), out double result)) return result;
            else return 0d;
        }
    }


    class Triangle
    {
        // Triangle class providing geometric functions for triangles

        // Sidelengths
        public double a, b, c;

        // Constructor
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool IsTriangular()
        {
            // Verify geometry of the triangle
            if (a > 0 && b > 0 && c > 0)
            {
                if (Area() > 0) return true;
            }

            return false;
        }

        // Calculate the circumference of a triangle
        public double Circumference()
        {
            return a + b + c;
        }

        // Return the area of the triangle
        public double Area()
        {
            // Calc area of triangle
            double s = this.S();
            double discr = s * (s - a) * (s - b) * (s - c);

            if (discr > 0) return Math.Sqrt(discr);
            else return 0d;
        }

        // Returns half the circumference
        private double S()
        {
            return this.Circumference() / 2;
        }
    }
}