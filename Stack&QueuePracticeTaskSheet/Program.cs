using System.Collections;
using System.Diagnostics.Metrics;
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
        public static void HospitalEmergencyRoomTriage()
        {
            Queue<string> triageQueue = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();
            // Add 8 patients to the queue
            triageQueue.Enqueue("Ahmed");
            triageQueue.Enqueue("Sara");
            triageQueue.Enqueue("Ali");
            triageQueue.Enqueue("Mai");
            triageQueue.Enqueue("Khalid");
            triageQueue.Enqueue("Noor");
            triageQueue.Enqueue("Omar");
            triageQueue.Enqueue("Huda");
            
            // Display the full queue with position labels
            Console.WriteLine("=== Full Triage Queue ===");
            int position = 1;
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(position + ". " + patient);
                position++;
            }
            // Show the next patient without removing
            Console.WriteLine("\nNext Patient:");
            Console.WriteLine(triageQueue.Peek());

            // Process (dequeue) the first 3 patients and display each name as they are seen.
            // Process the first 3 patients
            Console.WriteLine("\n=== Processed Patients ===");
            Console.WriteLine("Seen: " + triageQueue.Dequeue());
            Console.WriteLine("Seen: " + triageQueue.Dequeue());
            Console.WriteLine("Seen: " + triageQueue.Dequeue());
            // Display remaining queue
            Console.WriteLine("\n=== Remaining Queue ===");
            position = 1;
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(position + ". " + patient);
                position++;
            }
            // Remove a patient from the middle of the queue
            string targetPatient = "Noor";

            // Dequeue all patients, skip the target patient, and store the rest in tempQueue
            while (triageQueue.Count > 0)
            {
                string patient = triageQueue.Dequeue();

                // Keep all patients except the one who left
                if (patient != targetPatient)
                {
                    tempQueue.Enqueue(patient);
                }
            }

            // Move patients back to the original queue in the same order
            while (tempQueue.Count > 0)
            {
                triageQueue.Enqueue(tempQueue.Dequeue());
            }
            // Display final queue
            Console.WriteLine("\n=== Final Queue After Removal ===");
            position = 1;
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(position + ". " + patient);
                position++;
            }

            // Display final count
            Console.WriteLine("\nFinal Count:");
            Console.WriteLine(triageQueue.Count);
        }
        public static void ParenthesisValidator()
        {
            // Create a stack to store opening brackets
            Stack<char> bracketStack = new Stack<char>();

            // Requirement 1:Define 3 hardcoded test strings: one fully balanced, one unbalanced (mismatched type), one unbalanced (unclosed bracket).
            // Define 3 hardcoded test strings
            string test1 = "{[()]}";   // Balanced
            string test2 = "{[(])}";   // Mismatched brackets
            string test3 = "{[()]}(";  // Unclosed bracket
            Console.WriteLine("=== Test Case 1 ===");
            // Send test1 and the stack to the validation function
            ValidateBrackets(test1, bracketStack);
            // Requirement 7:
            // Clear the stack before the next test
            while (bracketStack.Count > 0)
            {
                bracketStack.Pop();
            }

            Console.WriteLine("\n=== Test Case 2 ===");
            // Send test2 and the same stack to the validation function
            ValidateBrackets(test2, bracketStack);

            // Clear the stack before the next test
            while (bracketStack.Count > 0)
            {
                bracketStack.Pop();
            }

            Console.WriteLine("\n=== Test Case 3 ===");

            // Send test3 and the same stack to the validation function
            ValidateBrackets(test3, bracketStack);
        }
        
        // Function that checks whether brackets are balanced
        public static void ValidateBrackets(string input, Stack<char> bracketStack)
        {
            // Assume the expression is valid
            bool isValid = true;

            // Requirement 2:
            // Loop through each character in the string
            for (int i = 0; i < input.Length; i++)
            {
                // Store the current character
                char currentChar = input[i];

                // Requirement 3:
                // If the character is an opening bracket
                if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                {
                    // Push opening bracket onto the stack
                    bracketStack.Push(currentChar);
                }

                // Requirement 4:
                // If the character is a closing round bracket
                else if (currentChar == ')')
                {
                    // Invalid if stack is empty
                    // or top bracket is not '('
                    if (bracketStack.Count == 0 || bracketStack.Peek() != '(')
                    {
                        isValid = false;
                        break;
                    }

                    // Remove matching opening bracket
                    bracketStack.Pop();
                }

                // If the character is a closing square bracket
                else if (currentChar == ']')
                {
                    // Invalid if stack is empty
                    // or top bracket is not '['
                    if (bracketStack.Count == 0 || bracketStack.Peek() != '[')
                    {
                        isValid = false;
                        break;
                    }

                    // Remove matching opening bracket
                    bracketStack.Pop();
                }

                // If the character is a closing curly bracket
                else if (currentChar == '}')
                {
                    // Invalid if stack is empty
                    // or top bracket is not '{'
                    if (bracketStack.Count == 0 || bracketStack.Peek() != '{')
                    {
                        isValid = false;
                        break;
                    }

                    // Remove matching opening bracket
                    bracketStack.Pop();
                }
            }

            // Requirement 5:
            // If the stack still contains brackets,
            // then some opening brackets were never closed
            if (bracketStack.Count > 0)
            {
                isValid = false;
            }
            // Requirement 6:
            // Display the input string
            Console.WriteLine("Input: " + input);

            // Display the validation result
            if (isValid)
            {
                Console.WriteLine("Result: Valid");
            }
            else
            {
                Console.WriteLine("Result: Invalid");
            }
        }
        public static void ReverseaSentenceWordbyWord()
        {
            // Create a stack to store words
            Stack<string> wordStack = new Stack<string>();
            // Requirement 1:
            // Define 2 hardcoded sentences
            string sentence1 = "C# is fun to learn";
            string sentence2 = "Stacks are easy to understand";
            Console.WriteLine("=== Test Case 1 ===");
            // Requirement 2:
            //For each sentence: split the sentence into words using the Split method on the space character.
            // Split sentence into words
            string[] words = sentence1.Split(' ');
            // Requirement 3:
            // Push each word into the stack
            foreach (string word in words)
            {
                wordStack.Push(word);
            }

            // Requirement 4:
            // Display stack contents before reversal
            Console.WriteLine("Stack Contents:");
            foreach (string word in wordStack)
            {
                Console.WriteLine(word);
            }
            // Variable to store reversed sentence
            string reversedWords = "";

            // Requirement 5:
            // Pop all words from the stack
            while (wordStack.Count > 0)
            {
                reversedWords += wordStack.Pop() + " ";
            }

            // Requirement 6:
            // Display original and reversed sentence
            Console.WriteLine("Original: " + sentence1);
            Console.WriteLine("Reversed: " + reversedWords);

            // Requirement 7:
            // Ensure stack is empty before next test
            while (wordStack.Count > 0)
            {
                wordStack.Pop();
            }
        
        }

        public static void TicketCounterSimulation()
        {
            Queue<string> regularQueue =new Queue<string>();
            Queue<string> vipQueue =new Queue<string>();
            // Requirement 1:
            // Add 3 VIP tickets
            vipQueue.Enqueue("V001");
            vipQueue.Enqueue("V002");
            vipQueue.Enqueue("V003");
            // Regular Tickets
            regularQueue.Enqueue("R001");
            regularQueue.Enqueue("R002");
            regularQueue.Enqueue("R003");
            regularQueue.Enqueue("R004");
            regularQueue.Enqueue("R005");
            
            int totalTickets = 0;

            while (vipQueue.Count > 0 || regularQueue.Count > 0)
            {
                if (vipQueue.Count > 0)
                {
                    Console.WriteLine("Serving VIP: " + vipQueue.Dequeue());
                    totalTickets++;
                }
                if (regularQueue.Count > 0)
                {
                    Console.WriteLine("Serving Regular: " + regularQueue.Dequeue());
                    totalTickets++;
                }
            }
            Console.WriteLine("Total Tickets Processed: " + totalTickets);
        }
        public static void OrderProcessingPipelinewithStatistics()
        {
            Queue<string> orderQueue=new Queue<string>();
            string highestOrder;
            string lowestOrder; 

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
                        HospitalEmergencyRoomTriage();
                        break;

                    case 5://Problem 5: Parenthesis Validator
                        ParenthesisValidator();
                        break;

                    case 6://Problem 6: Print Spooler with Priority Re-Insertion
                        break;

                    case 7://Problem 7: Reverse a Sentence Word by Word
                        ReverseaSentenceWordbyWord();
                        break;

                    case 8://Problem 8: Multi-Level Undo with Redo
                   
                        break;

                    case 9://Problem 9: Ticket Counter Simulation 
                        TicketCounterSimulation();
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