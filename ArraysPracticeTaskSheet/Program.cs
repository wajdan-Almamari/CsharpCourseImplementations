using System.Diagnostics;
using System.Numerics;

namespace ArraysPracticeTaskSheet
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
            for (int rank= 0; rank <  grades.Length; rank++)
            {
                Console.WriteLine("Rank " + (rank + 1) +": " + grades[rank]);
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
            double[] revenue = { 1200.50, 950.75, 1800.00, 1350.25, 1600.80, 1100.40,2000.90, 1750.30, 1450.60, 1900.20, 1250.10, 2100.45 };
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
        // Problem 9: Flight Seat Allocation Display
        public static void FlightSeatAllocationDisplay()
        {
            // Store 15 unique seat numbers
            int[] seats = { 12, 5, 33, 18, 7, 25, 41, 3, 29, 14, 36, 9, 47, 21, 30 };

            // Create a second array to hold reversed values
            int[] reverse = new int[seats.Length];

            Console.WriteLine("Original Assignment Order:");

            // Display original seat assignment order
            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            // Sort seats in ascending order
            Array.Sort(seats);

            Console.WriteLine("\nBoarding Order:");

            // Display sorted boarding order
            foreach (int seat in seats)
            {
                Console.WriteLine(seat);
            }

            // Search for a target seat number in the sorted array
            int targetSeat = 29;

            int index = Array.IndexOf(seats, targetSeat);

            if (index == -1)
            {
                Console.WriteLine("\nTarget seat not found.");
            }
            else
            {
                Console.WriteLine("\nTarget seat found at sorted index: " + index);
            }

            // Copy sorted seats into reverse array
            for (int i = 0; i < seats.Length; i++)
            {
                reverse[i] = seats[i];
            }

            // Reverse the copied array only
            Array.Reverse(reverse);
            Console.WriteLine("\nSorted and Reversed Seats:");

            // Display sorted and reversed arrays side-by-side
            for (int i = 0; i < seats.Length; i++)
            {
                Console.WriteLine( "Index " + i + " - Sorted: " + seats[i] + "   Reversed: " + reverse[i]);
            }

            // Display total seat count
            Console.WriteLine("\nTotal Seat Count: " + seats.Length);
        }
        // Problem 10: Hospital Patient Priority Queue
        public static void HospitalPatientPriorityQueue()
        {
            // Store severity scores for 20 patients
            int[] severity = { 2, 5, 1, 8, 3, 10, 4, 6, 2, 7, 9, 1, 3, 5, 6, 4, 8, 10, 2, 7 };

            // Create a copy array to perform sorting operations
            int[] sortedSeverity = new int[severity.Length];

            // Copy values from severity to sortedSeverity
            for (int i = 0; i < severity.Length; i++)
            {
                sortedSeverity[i] = severity[i];
            }

            // Sort the copied array in ascending order
            Array.Sort(sortedSeverity);

            // Calculate median before reversing
            // Median = average of the two middle elements
            double median = (sortedSeverity[sortedSeverity.Length / 2 - 1] + sortedSeverity[sortedSeverity.Length / 2]) / 2.0;

            // Reverse the sorted array to display highest values first
            Array.Reverse(sortedSeverity);

            Console.WriteLine("Triage Priority List:");

            // Display patients ranked by severity
            for (int rank = 0; rank < sortedSeverity.Length; rank++)
            {
                Console.WriteLine("Rank " + (rank + 1) +  ": Severity " + sortedSeverity[rank]);
            }

            // Count critical cases (severity score <= 3)
            int criticalCount = 0;

            for (int i = 0; i < severity.Length; i++)
            {
                if (severity[i] <= 3)
                {
                    criticalCount++;
                }
            }

            // Display median severity score
            Console.WriteLine("\nMedian Severity Score: " + median);

            // Display total critical cases
            Console.WriteLine("Critical Cases Count: " + criticalCount);

            // Search for a specific severity score
            int targetSeverity = 3;
            int index = Array.IndexOf(sortedSeverity, targetSeverity);

            // Check whether the target severity exists
            if (index == -1)
            {
                Console.WriteLine("Target severity not found.");
            }
            else
            {
                Console.WriteLine("Target severity found at sorted index: " + index);
            }
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
                        FlightSeatAllocationDisplay();
                        break;
                    case 10://Problem 10: Hospital Patient Priority Queue 
                        HospitalPatientPriorityQueue();
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