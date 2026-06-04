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
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                ShowMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 0:
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