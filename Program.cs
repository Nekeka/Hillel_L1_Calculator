using System.Runtime.CompilerServices;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IMathOperation operation;
            double a = 0;
            double b = 0;
            bool new_a = true;
            while (true)
            {
                if (new_a) {
                    while (true)
                    {
                        Console.WriteLine("Enter A");
                        try
                        {
                            a = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("pls\nenter the number");
                        }
                    }
                }
                while (true)
                {
                    Console.WriteLine("Enter B");
                    try
                    {
                        b = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("pls\nenter the number");
                    }
                }

                Console.WriteLine($"a: {a} and b:{b}\nchoose the opetation:\na - Addition\ns - subtraction\nm - Multiplication\nd - Division");


                string choose = Convert.ToString(Console.ReadLine()).ToLower();


                switch (choose)
                {
                    case "a":
                        operation = new Addition();
                        break;
                    case "s":
                        operation = new Subtraction();
                        break;
                    case "m":
                        operation = new Multiplication();
                        break;
                    case "d":
                        operation = new Division();
                        break;
                    default:
                        operation = new Addition();
                        break;
                }

                Calculate calculator = new Calculate(a, b, operation);

                Console.WriteLine($"c - continue with a = {a}\ns - stop\nn - new number");

                choose = Convert.ToString(Console.ReadLine()).ToLower();

                if (choose == "c")
                    new_a = false;
                else if (choose == "s")
                    break;
                else
                    new_a = true;

                    
            }
            Console.WriteLine("end!!!");  
        }
    }
    public class Calculate
    {
        public double A { get; set; }
        public double B { get; set; }

        public Calculate(double a, double b, IMathOperation operation)
        {
            this.A = a;
            this.B = b;
            Console.WriteLine("result: " +operation.DoMath(a, b));
        }
    }

    public interface IMathOperation
    {
        double DoMath(double a, double b);
    }

    class Addition : IMathOperation
    {
        public double DoMath(double a, double b)
        {
            return a + b;
        }
    }

    class Subtraction : IMathOperation
    {
        public double DoMath(double a, double b)
        {
            return a - b;
        }
    }

    class Multiplication : IMathOperation
    {
        public double DoMath(double a, double b)
        {
            return a * b;
        }
    }
    class Division : IMathOperation {
        public double DoMath(double a, double b)
        {
            return a / b;
        }
    }
}
