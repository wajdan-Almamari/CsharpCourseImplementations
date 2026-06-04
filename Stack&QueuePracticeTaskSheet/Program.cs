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
        public static void HotelCheckInQueue() 
        { 
            Queue <string> checkInQueue = new Queue<string>();
            // Add 5 guests
            checkInQueue.Enqueue("Ahmed");
            checkInQueue.Enqueue("Sara");
            checkInQueue.Enqueue("Ali");
            checkInQueue.Enqueue("Mai");
            checkInQueue.Enqueue("Wajdan");
            //Display all waiting guests in order using a foreach loop.
            Console.WriteLine("\nWaiting Guests ");
            foreach(string gust in checkInQueue)
            {
                Console.WriteLine(gust);
            }
            // Use Peek to display who is next without removing them from the queue.
            Console.WriteLine("\nNext Guest:");
            Console.WriteLine(checkInQueue.Peek());

            // Serve the next 2 guests — dequeue twice and display each served guest's name.
            Console.WriteLine("\nServed Guest 1:");
            Console.WriteLine(checkInQueue.Dequeue());

            Console.WriteLine("\nServed Guest 2:");
            Console.WriteLine(checkInQueue.Dequeue());

            //Display the remaining queue after serving.
            Console.WriteLine("\n Remaining Queue:");
            foreach (string guest in checkInQueue)
            {
                Console.WriteLine(guest);
            }
            // Check if guest still waiting
            Console.Write("\nIs Ali still waiting?");
            Console.WriteLine(checkInQueue.Contains("Ali"));

            // Display count
            Console.Write("\nGuests Remaining:");
            Console.WriteLine(checkInQueue.Count);
        }
        public static void TextEditorUndoSystem()
        {
             Stack<string > undoStack= new Stack<string>();
             Stack<string> tempStack = new Stack<string>();
            // Push 7 hardcoded action descriptions onto undoStack.
            undoStack.Push("Typed: Hello");
            undoStack.Push("Typed: World");
            undoStack.Push("Deleted: World");
            undoStack.Push("Typed: C#");
            undoStack.Push("Changed Font");
            undoStack.Push("Inserted Image");
            undoStack.Push("Saved File");
            // Display the full undo history using foreach.
            Console.WriteLine($"Full Undo History");
            Console.WriteLine("=================");
            foreach (string undo in undoStack)
            {
                Console.WriteLine(undo);
            }
            //Use Peek to show which action would be undone next.
            Console.WriteLine("=================");
            Console.WriteLine("Next Undo Action:");
            Console.WriteLine(undoStack.Peek());
            // Undo the last 2 actions — pop twice, displaying each removed action.
            Console.WriteLine("=================");
            Console.WriteLine("Undo Last 2 Actions:");
            Console.WriteLine("Removed: " + undoStack.Pop());
            Console.WriteLine("Removed: " + undoStack.Pop());
            // Display the remaining undo history.
            Console.WriteLine("=================");
            Console.WriteLine(" Remaining Undo History");
            foreach (string undo in undoStack)
            {
                Console.WriteLine(undo);
            }
            /*
              Selective undo: remove one specific hardcoded action from the middle of the stack. 
              Use tempStack to preserve the order of all other actions.
              Display the stack before and after the selective undo
             */
            Console.WriteLine("=================");
            Console.WriteLine("Before Selective Undo ");
            foreach (string undo in undoStack)
            {
                Console.WriteLine(undo);
            }
            string targetAction = "Deleted: World";
            // Remove target undo from middle
        
             while (undoStack.Count > 0)//Remove the target action while moving all other actions to the temporary stack
            {
                string action = undoStack.Pop();
                // Keep all actions except the one we want to remove
                if (action != targetAction)
                {
                    tempStack.Push(action);
                }
            }
            // Restore the remaining actions back to the original stack
            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }
            Console.WriteLine("=================");
            Console.WriteLine("After Selective Undo ");
            foreach (string undo in undoStack)
            {
                Console.WriteLine(undo);
            }
            Console.WriteLine("=================");
            Console.WriteLine("Final Count:");
            Console.WriteLine(undoStack.Count);
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
                        HotelCheckInQueue();
                        break;

                    case 3:// Problem 3 (Stack) + Problem 4 (Queue) 
                        TextEditorUndoSystem();
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