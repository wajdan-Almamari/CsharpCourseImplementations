using System.Security.Cryptography.X509Certificates;

namespace Stack_QueuePracticeTaskSheet
{
    internal class Program
    {
        public static void ShowMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" Stack & Queue Practice TS-DS-03");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Browser History Tracker");
            Console.WriteLine("2. Hotel Check-In Queue");
            Console.WriteLine("3. Text Editor Undo System");
            Console.WriteLine("4. Hospital Emergency Room Triage");
            Console.WriteLine("5. Parenthesis Validator");
            Console.WriteLine("6. Print Spooler");
            Console.WriteLine("7. Reverse a Sentence");
            Console.WriteLine("8. Multi-Level Undo with Redo");
            Console.WriteLine("9. Ticket Counter Simulation");
            Console.WriteLine("10. Order Processing Pipeline");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
        }
        public static void BrowserHistoryTracker() 
        {
            // Create empty stack
            Stack<string> browserHistory = new Stack<string>();
            // Push 5 URLs
            browserHistory.Push("www.google.com");
            browserHistory.Push("www.youtube.com");
            browserHistory.Push("www.github.com");
            browserHistory.Push("www.microsoft.com");
            browserHistory.Push("www.openai.com");
            // Display history
            Console.WriteLine("=== Browser History ===");
            foreach (string url in browserHistory)
            {
                Console.WriteLine(url);
            }
            // Current page
            Console.Write("\nCurrent Page:  ");
            Console.WriteLine(browserHistory.Peek());

            // Back twice
            Console.WriteLine("\nBack 1:");
            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine("\nBack 2:");
            Console.WriteLine(browserHistory.Pop());

            //Display the remaining history after both pops
            Console.WriteLine("\n=== Remaining History ===");
            foreach (string url in browserHistory)
            {
                Console.WriteLine(url);
            }
            // Check whether a specific hardcoded URL is still in the history and print the result.
            Console.Write("\nIs www.github.com still in history? ");
            Console.WriteLine(browserHistory.Contains("www.github.com"));

            //Display the total number of pages remaining in the history using Count.
            Console.Write("\n Page remaining : ");
            Console.WriteLine(browserHistory.Count());

        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                ShowMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1://Problem 1: Browser History Tracker
                        BrowserHistoryTracker();
                        break;

                    case 2://Problem 2: Hotel Check-In Queue
                        break;

                    case 3:// Problem 3 (Stack) + Problem 4 (Queue) 
                        break;

                    case 4://Problem 4: Hospital Emergency Room Triage
                        break;

                    case 5://Problem 5: Parenthesis Validator
                        break;

                    case 6://Problem 6: Print Spooler with Priority Re-Insertion
                        break;

                    case 7://Problem 7: Reverse a Sentence Word by Word
                        break;

                    case 8://Problem 8: Multi-Level Undo with Redo
                        break;

                    case 9://Problem 9: Ticket Counter Simulation 
                        break;

                    case 10://Problem 10: Order Processing Pipeline with Statistics
                        break;

                    case 0:
                        exit= true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}