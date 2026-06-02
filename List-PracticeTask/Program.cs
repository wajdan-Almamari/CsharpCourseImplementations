namespace List_PracticeTask
{
    internal class Program
    {
        public static void PrintMenuStyle()
        { //PrintMenu-style functions 
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine(" Arrays Practice Task Sheet ");
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
        public static void TemperatureLog()
        {
            List<double> temperatures = new List<double>();
            temperatures.AddRange(new double[] { 34.5, 35.2, 33.8, 36.1, 34.9, 35.7, 33.5 });

            // Display each temperature with its day number
            for (int i = 0; i < temperatures.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");
            }
            // Display total number of readings
            Console.WriteLine("Total Readings: " + temperatures.Count);
        }

        //Problem 2: Student Score Board
        public static void StudentScoreBoard()
        {
            List<int> scores = new List<int>();
            scores.AddRange(new int[] { 85, 92, 78, 65, 99, 88 });
      
            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
           scores.Reverse();
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
        //Problem 4: Race Finish Times 
        public static void RaceFinishTimes()
        {
            // Store finish times for 8 runners
            int[] finishTimes = { 35, 55, 83, 32, 85, 61, 93, 22 };
            Console.WriteLine("Original Finish Times:");
            // Display original finish times using foreach
            foreach (int time in finishTimes)
            {
                Console.WriteLine(time);
            }
            // Sort finish times in ascending order
            Array.Sort(finishTimes);
            Console.WriteLine("Sorted Finish Times: ");
            // Display sorted finish times
            foreach (int time in finishTimes)
            {
                Console.WriteLine(time);
            }
            Console.WriteLine("Total of participants : " + finishTimes.Length);
        }
        //Problem 5: Classroom Grade Report 
        public static void ClassroomGradeReport()
        {
            int[] grades = { 50, 66, 88, 90, 99, 70, 55, 87, 95, 30 };
            //Sort the grades in ascending order. 
            Array.Sort(grades);
            Console.WriteLine("Grades in  Ascending order : ");
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine(grades[i]);
            }
            // Reverse grades to descending order
            Array.Reverse(grades);
            Console.WriteLine("\nGrades in Descending order : ");

            //Print each grade with a rank label (Rank 1, Rank 2, ...) using a for loop.
            for (int rank = 0; rank < grades.Length; rank++)
            {
                Console.WriteLine("Rank " + (rank + 1) + ": " + grades[rank]);
            }
        }
        //Problem 6: Warehouse Inventory Check
        public static void WarehouseInventoryCheck()
        {
            int[] quantities = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int totalStock = 0;
            for (int i = 0; i < quantities.Length; i++)
            {
                totalStock += quantities[i];

            }
            Console.WriteLine("Total Stock: " + totalStock);
            double averageStock = (double)totalStock / quantities.Length;
            Console.WriteLine("Average Stock: " + averageStock);

            int targetQuantity = 5;
            int index = Array.IndexOf(quantities, targetQuantity);
            if (index == -1)
            {
                Console.WriteLine("Target quantity not found.");
            }
            else
            {
                Console.WriteLine("Target quantity found at index: " + index);
            }
        }
        //Problem 7: Library Book Shelf Scanner  
        public static void LibraryBookShelfScanner()
        {
            // Store available copies for 9 book titles
            int[] copies = { 5, 0, 8, 3, 12, 6, 1, 9, 4 };

            Console.WriteLine("Original Copy Counts:");

            // Display original copy counts
            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            // Sort copy counts in ascending order
            Array.Sort(copies);
            Console.WriteLine("\nSorted Copy Counts:");

            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            // Display the highest copy count (last element)
            Console.WriteLine("\nMost Copies: " + copies[copies.Length - 1]);

            // Check if any title has zero copies
            bool foundZero = false;

            for (int i = 0; i < copies.Length; i++)
            {
                if (copies[i] == 0)
                {
                    foundZero = true;
                    break;
                }
            }

            if (foundZero)
            {
                Console.WriteLine("At least one title has zero copies.");
            }
            else
            {
                Console.WriteLine("No title has zero copies.");
            }
        }
        //Problem 8: Sales Performance Analyzer 
        public static void SalesPerformanceAnalyzer()
        {
            // Store monthly revenue for 12 months
            double[] revenue = { 1200.50, 950.75, 1800.00, 1350.25, 1600.80, 1100.40, 2000.90, 1750.30, 1450.60, 1900.20, 1250.10, 2100.45 };
            // Create second array to store sorted values
            double[] sortedCopy = new double[revenue.Length];

            Console.WriteLine("Original Monthly Revenue:");
            // Display original revenue with month labels
            for (int i = 0; i < revenue.Length; i++)
            {
                Console.WriteLine("Month " + (i + 1) + ": " + revenue[i] + " OMR");
            }
            // Copy revenue into sortedCopy manually using for loop
            for (int i = 0; i < revenue.Length; i++)
            {
                sortedCopy[i] = revenue[i];
            }
            // Sort the copied array
            Array.Sort(sortedCopy);

            Console.WriteLine("\nSorted Revenue Trend:");
            // Display sorted revenue values
            for (int i = 0; i < sortedCopy.Length; i++)
            {
                Console.WriteLine(sortedCopy[i] + " OMR");
            }
            // Best revenue is the last value after sorting
            Console.WriteLine("\nBest Month Revenue: " + sortedCopy[sortedCopy.Length - 1] + " OMR");
            // Worst revenue is the first value after sorting
            Console.WriteLine("Worst Month Revenue: " + sortedCopy[0] + " OMR");
            // Calculate total revenue
            double totalRevenue = 0;

            for (int i = 0; i < revenue.Length; i++)
            {
                totalRevenue += revenue[i];
            }
            // Calculate average revenue using .Length
            double averageRevenue = totalRevenue / revenue.Length;

            Console.WriteLine("Average Monthly Revenue: " + averageRevenue + " OMR");
        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                PrintMenuStyle();
                int EnterChoise = Convert.ToInt32(Console.ReadLine());
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
                        RaceFinishTimes();
                        break;
                    case 5://Problem 5: Classroom Grade Report
                        ClassroomGradeReport();
                        break;
                    case 6://Problem 6: Warehouse Inventory Check
                        WarehouseInventoryCheck();
                        break;
                    case 7://Problem 7: Library Book Shelf Scanner
                        LibraryBookShelfScanner();
                        break;
                    case 8://Problem 8: Sales Performance Analyzer
                        SalesPerformanceAnalyzer();
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