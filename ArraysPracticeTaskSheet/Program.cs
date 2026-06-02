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

        //Problem 1: Temperature Log
        public static void TemperatureLog() {
            double[] temperatures = { 34.5, 35.2, 33.8, 36.1, 34.9, 35.7, 33.5 };
            // Display each temperature with its day number
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");
            }
            // Display total number of readings
            Console.WriteLine("Total Readings: " + temperatures.Length);
        }

        //Problem 2: Student Score Board
        public static void StudentScoreBoard()
        {
            int[] scores = { 85, 92, 78, 65, 99, 88 };
            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
            Array.Reverse(scores);
            Console.WriteLine("Reversed Order:");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
        }
        //Problem 3: Product Price Finder
        public static void ProductPriceFinder()
        {
            double[] prices = { 4.99, 8.50, 12.75, 15.99, 20.00 }; // Array storing 5 product prices
            Console.WriteLine("Product Prices:");
            for (int i = 0; i < prices.Length; i++)  // display each price with its product number
            {
                Console.WriteLine("Product " + (i + 1) + ": " + prices[i]);
            }
            double targetPrice = 12.75; // Hardcoded target price to search for
            int index = Array.IndexOf(prices, targetPrice);//Search for the target price and return its index
            if (index != -1)
            {
                Console.WriteLine("Price found at index: " + index);
            }
            else
            {
                Console.WriteLine("Price not found.");
            }
            Console.WriteLine("Target Price: " + targetPrice);
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
                        TemperatureLog();
                        break;
                    case 2://Problem 2: Student Score Board
                        StudentScoreBoard();
                        break;
                    case 3://Problem 3: Product Price Finder
                        ProductPriceFinder(); 
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