namespace ArraysPracticeTaskSheet
{
    internal class Program
    {
        public static void PrintMenuStyle()
        { //PrintMenu-style functions 
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine(" task sheet contains 10 problems on C# Arrays ");
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("Problem 1: Temperature Log ");
            Console.WriteLine("Problem 2: Student Score Board ");
            Console.WriteLine("Problem 3: Product Price Finder  ");
            Console.WriteLine("Problem 4: Race Finish Times   ");
            Console.WriteLine("Problem 5: Classroom Grade Report  ");
            Console.WriteLine("Problem 6: Warehouse Inventory Check  ");
            Console.WriteLine("Problem 7: Library Book Shelf Scanner   ");
            Console.WriteLine("Problem 8: Sales Performance Analyzer  ");
            Console.WriteLine("Problem 9: Flight Seat Allocation Display  ");
            Console.WriteLine("Problem 10: Hospital Patient Priority Queue ");
            Console.WriteLine("11.Exit  ");
            Console.WriteLine("///////////////////////////////////");
            Console.Write(" Enter your choice: ");

        }

        public static double TemperatureLog() {
            double[] temperatures = { 34.5, 35.2, 33.8, 36.1, 34.9, 35.7, 33.5 };
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");
            }
            return temperatures.Length;
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                PrintMenuStyle();
                int EnterChoise = int.Parse(Console.ReadLine());
                switch (EnterChoise)
                {
                    case 1://Problem 1: Temperature Log
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("Problem 1: Temperature Log ");
                        Console.WriteLine("///////////////////////////////////");
                        double total = TemperatureLog();
                        Console.WriteLine("Total Readings: " + total);
                        break;
                    case 2://Problem 2: Student Score Board
                        break;
                    case 3://Problem 3: Product Price Finder
                        break;
                    case 4://Problem 4: Race Finish Times
                        break;
                    case 5://Problem 5: Classroom Grade Report
                        break;
                    case 6://Problem 6: Warehouse Inventory Check
                        break;
                    case 7://Problem 7: Library Book Shelf Scanner
                        break;
                    case 8://Problem 8: Sales Performance Analyzer
                        break;
                    case 9://Problem 9: Flight Seat Allocation Display
                        break;
                    case 10://Problem 10: Hospital Patient Priority Queue 
                        break;
                    case 11://11.Exit
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}