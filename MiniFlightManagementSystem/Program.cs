using System.Net.Sockets;
namespace MiniFlightManagementSystem
{
        internal class Program
        {
        // 5 passenger names
        static List<string> passengerNames = new List<string>() { "Wajdan", "Hidya", "Rahaf", "Baraa", "Hafisa" };

        // 5 ticket IDs matching passengerNames index
        static List<string> ticketNumbers = new List<string>() { "TKT-001", "TKT-002", "TKT-003", "TKT-004", "TKT-005" };

        static string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        
        // 4 available booking dates (dd-MMM-yyyy)
        static List<string> availableDates = new List<string>() { "12-Jan-2026", "15-Jan-2026", "18-Jan-2026", "20-Jan-2026" };

        // Key = ticketNumber, Value = flightNumber+date (e.g.'OA101|12-Jan-2026')
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        // Passengers who have checked in, awaiting boarding
        static Queue<string> checkedInQueue = new Queue<string>();

        // Passengers boarding the aircraft (last checked-in, first to board)
        static Stack<string> boardingStack = new Stack<string>();

        // Ticket IDs that have been cancelled
        static List<string> cancelledTickets = new List<string>();

        // Key = passengerName, Value = assigned seat (e.g. '14A')
        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();

        // Passenger names on the standby waitlist
        static Queue<string> waitlistQueue = new Queue<string>();

        static int currentRow = 10;
        static char currentSeat = 'A';
            public static bool TicketExists(string ticketID)
        {
            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Ticket not found.");
                return false;
            }
            return true;
        }
            public static bool NotCancelled(string ticketID)
        {
            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return false;
            }
            return true;
        }
            public static bool BookingExists(string ticketID)
        {
            if (!bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("No booking found for this ticket.");
                return false;
            }
            return true;
        }
            public static string GetPassengerName(string ticketID)
        {
            int passengerIndex = ticketNumbers.IndexOf(ticketID);
            return passengerNames[passengerIndex];
        }
            public static void RegisterNewPassenger()
            {
                Console.Write("Enter passenger name: ");
                string EnterpassengerName = Console.ReadLine();

                // Check if name is empty
                if (EnterpassengerName.Trim() == "")
                {
                    Console.WriteLine("Name cannot be empty.");
                    return;
                }

                // Check if the passenger already exists in the list
                for (int i = 0; i < passengerNames.Count; i++)
                {
                    // Compare names ignoring uppercase and lowercase letters
                    if (EnterpassengerName.ToLower().Trim() == passengerNames[i].ToLower().Trim())
                    {
                        Console.WriteLine("Passenger already exists.");
                        return;
                    }
                }//end of for

                // Generate new ticket ID
                string ticketID = "TKT-" + (ticketNumbers.Count + 1).ToString("000");

                // Add passenger name and ticket ID at the same index
                passengerNames.Add(EnterpassengerName);
                ticketNumbers.Add(ticketID);

                // Display success message
                Console.WriteLine("Passenger registered successfully.");
                Console.WriteLine("Passenger Name: " + EnterpassengerName);
                Console.WriteLine("Ticket ID: " + ticketID);
            }
            public static void ViewAllPassengers()
            {
                // Check if there are any registered passengers
                if (passengerNames.Count == 0)
                {
                    Console.WriteLine("No passengers registered yet.");
                    return;
                }

                // Display table header
                Console.WriteLine("No.".PadRight(5) + " | " + "Passenger Name".PadRight(22) + " | " + "Ticket ID".PadRight(22) + " | " + "Status");
                Console.WriteLine("======================================================");

                // Loop through all passengers
                for (int index = 0; index < passengerNames.Count; index++)
                {
                    // Default passenger status
                    string status = "Active";
                    // Check if the ticket has been cancelled
                    if (cancelledTickets.Contains(ticketNumbers[index]))
                    {
                        status = "CANCELLED";
                    }
                    // Display passenger information
                    Console.WriteLine((index + 1).ToString().PadRight(5) + " | " + passengerNames[index].PadRight(22) + " | " + ticketNumbers[index].PadRight(22) + " | " + status);
                }
                // Display total number of passengers

                Console.WriteLine("Total Passengers: " + passengerNames.Count);
                Console.WriteLine("=======================================");



            }
            public static void BookFlightTicket()
            {
                Console.Write("Enter a ticket ID : ");
                string ticketID = Console.ReadLine();
                // Check if ticket ID exists
                if (!ticketNumbers.Contains(ticketID))
                {
                    Console.WriteLine("Ticket not found.");
                    return;
                }
                // Check if ticket is cancelled
               
                // Check if ticket already has a booking
                if (bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("Ticket already booked.");
                    return;
            }

            if (cancelledTickets.Contains(ticketID))
            {
                cancelledTickets.Add(ticketID);
                //Console.WriteLine("This ticket has been cancelled beforer and now you will proceed to another booking.");
               // return;
            }

            // Display available flights
            Console.WriteLine("\nAvailable Flights:");
                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                }
                // Select flight
                Console.Write("Select Flight: ");
                int flightChoice = int.Parse(Console.ReadLine());
                if (flightChoice < 1 || flightChoice > flightNumbers.Length)
                {
                    Console.WriteLine("Invalid flight choice.");
                    return;
                }
                string selectedFlight = flightNumbers[flightChoice - 1];
                // Display available dates
                Console.WriteLine("\nAvailable Dates:");
                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + availableDates[i]);
                }
                // Select date
                Console.Write("Select Date: ");
                int dateChoice = int.Parse(Console.ReadLine());
                if (dateChoice < 1 || dateChoice > availableDates.Count)
                {
                    Console.WriteLine("Invalid date choice.");
                    return;
                }
                // Store the selected date
                string selectedDate = availableDates[dateChoice - 1];

                // Save booking in dictionary
                bookingRecord.Add(ticketID, selectedFlight + "|" + selectedDate);
                cancelledTickets.Remove(ticketID);
                // Find passenger name using ticket index
                int passengerIndex = ticketNumbers.IndexOf(ticketID);

                // Display booking confirmation
                Console.WriteLine("\nBooking Successful");
                Console.WriteLine("Passenger Name: " + passengerNames[passengerIndex]);
                Console.WriteLine("Ticket ID: " + ticketID);
                Console.WriteLine("Flight: " + selectedFlight);
                Console.WriteLine("Date: " + selectedDate);
            }
            public static void ViewBookingDetails()
            {
                Console.WriteLine("Enter tickit ID : ");
                string ticketId = Console.ReadLine();
            // Check if ticket exists
            if (!TicketExists(ticketId)) return;
            if (!NotCancelled(ticketId)) return;
            if (!BookingExists(ticketId)) return;

            string passengerName = GetPassengerName(ticketId);

            // Get booking value from dictionary
            string bookingValue = bookingRecord[ticketId];
            // Split flight and date
            string[] bookingParts = bookingValue.Split('|');

                string flight = bookingParts[0];
                string date = bookingParts[1];

                // Display booking details
                Console.WriteLine("\nBooking Details");
                Console.WriteLine("Passenger Name: " + passengerName);
                Console.WriteLine("Ticket ID: " + ticketId);
                Console.WriteLine("Flight: " + flight);
                Console.WriteLine("Date: " + date);
            }
            public static void UpdateBooking()
            {
                Console.Write("Enter Ticket ID: ");
                string ticketID = Console.ReadLine();

                // Check if ticket exists
                if (!ticketNumbers.Contains(ticketID))
                {
                    Console.WriteLine("Ticket not found.");
                    return;
                }

                // Check if ticket is cancelled
                if (cancelledTickets.Contains(ticketID))
                {
                    Console.WriteLine("This ticket has been cancelled.");
                    return;
                }

                // Check if booking exists
                if (!bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("No booking found.");
                    return;
                }
            // Get booking details from dictionary
            string bookingValue = bookingRecord[ticketID];

            // Split booking into flight and date
            string[] parts = bookingValue.Split('|');

            // Store current flight
            string currentFlight = parts[0];

            // Store current date
            string currentDate = parts[1];

            // Display current booking details
            Console.WriteLine("Current Flight: " + currentFlight);
            Console.WriteLine("Current Date: " + currentDate);

            // Display update menu options
            Console.WriteLine("\n1. Change flight only");
            Console.WriteLine("2. Change date only");
            Console.WriteLine("3. Change both");
            Console.WriteLine("0. Cancel update");

            // Read user choice
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Process user selection
            switch (choice)
            {
                case 1:
                    // Update flight only
                    Console.WriteLine("Change flight only");
                    // Display available flights
                    for (int i = 0; i < flightNumbers.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                    }

                    // Read new flight choice
                    Console.Write("Select new flight: ");
                    int flightChoice = int.Parse(Console.ReadLine());

                    // Validate flight choice
                    if (flightChoice < 1 || flightChoice > flightNumbers.Length)
                    {
                        Console.WriteLine("Invalid flight choice.");
                        return;
                    }

                    // Get selected flight
                    string newFlight = flightNumbers[flightChoice - 1];

                    // Update booking with new flight and old date
                    bookingRecord[ticketID] = newFlight + "|" + currentDate;

                    // Display confirmation
                    Console.WriteLine("Flight updated successfully.");
                    Console.WriteLine("Old Flight: " + currentFlight);
                    Console.WriteLine("New Flight: " + newFlight);
                    break;
            
                case 2:
                    Console.WriteLine("Change date only");

                    // Display available dates
                    for (int i = 0; i < availableDates.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + availableDates[i]);
                    }

                    // Read new date choice
                    Console.Write("Select new date: ");
                    int dateChoice = int.Parse(Console.ReadLine());

                    // Validate date choice
                    if (dateChoice < 1 || dateChoice > availableDates.Count)
                    {
                        Console.WriteLine("Invalid date choice.");
                        return;
                    }

                    // Get selected date
                    string newDate = availableDates[dateChoice - 1];

                    // Update booking with old flight and new date
                    bookingRecord[ticketID] = currentFlight + "|" + newDate;

                    // Display confirmation
                    Console.WriteLine("Date updated successfully.");
                    Console.WriteLine("Old Date: " + currentDate);
                    Console.WriteLine("New Date: " + newDate);
                    break;

                case 3:
                    // Update flight and date
                    Console.WriteLine("Change both");

                    // Display available flights
                    for (int i = 0; i < flightNumbers.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                    }

                    // Read new flight choice
                    Console.Write("Select new flight: ");
                    int newFlightChoice = int.Parse(Console.ReadLine());

                    // Validate flight choice
                    if (newFlightChoice < 1 || newFlightChoice > flightNumbers.Length)
                    {
                        Console.WriteLine("Invalid flight choice.");
                        return;
                    }

                    // Get selected flight
                    string bothNewFlight = flightNumbers[newFlightChoice - 1];

                    // Display available dates
                    for (int i = 0; i < availableDates.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + availableDates[i]);
                    }

                    // Read new date choice
                    Console.Write("Select new date: ");
                    int newDateChoice = int.Parse(Console.ReadLine());

                    // Validate date choice
                    if (newDateChoice < 1 || newDateChoice > availableDates.Count)
                    {
                        Console.WriteLine("Invalid date choice.");
                        return;
                    }

                    // Get selected date
                    string bothNewDate = availableDates[newDateChoice - 1];

                    // Update booking with new flight and new date
                    bookingRecord[ticketID] = bothNewFlight + "|" + bothNewDate;

                    // Display confirmation
                    Console.WriteLine("Booking updated successfully.");
                    Console.WriteLine("Old Flight: " + currentFlight);
                    Console.WriteLine("New Flight: " + bothNewFlight);
                    Console.WriteLine("Old Date: " + currentDate);
                    Console.WriteLine("New Date: " + bothNewDate);

                    break;

                case 0:
                    // Cancel update process
                    Console.WriteLine("Update cancelled.");
                    return;

                default:
                    // Invalid menu option
                    Console.WriteLine("Invalid choice.");
                    return;
            }
        }
            public static void CencelTicket()
        {
            // Ask user to enter a ticket ID
            Console.Write("Enter a ticket ID : ");
            string ticketID = Console.ReadLine();

            // Check if ticket ID exists in the ticket list
            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Ticket ID not found.");
                return;
            }

            // Check if ticket has already been cancelled
            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("Ticket already cancelled.");
                return;
            }
            // Find passenger index using ticket ID
            int passengerIndex = ticketNumbers.IndexOf(ticketID);

            // Get passenger name from the same index
            string passengerName = passengerNames[passengerIndex];
            if (bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("Booking was removed: " + bookingRecord[ticketID]);

                bookingRecord.Remove(ticketID);
            }
            // Add ticket to cancelled tickets list
            cancelledTickets.Add(ticketID);
            Console.WriteLine("Ticket cancelled successfully.");
            Console.WriteLine("Passenger Name: " + passengerName);
            Console.WriteLine("Ticket ID: " + ticketID);

            // Check if passenger exists in the check-in queue
            if (checkedInQueue.Contains(passengerName))
            {
                // Create a temporary queue
                Queue<string> tempQueue = new Queue<string>();

                // Process all passengers in the queue
                while (checkedInQueue.Count > 0)
                {
                    
                    string currentPassenger = checkedInQueue.Dequeue();// Remove first passenger from original queue


                    if (currentPassenger != passengerName)// Add passenger to temp queue if not cancelled passenger
                    {
                        tempQueue.Enqueue(currentPassenger);
                    }
                }
                
                checkedInQueue = tempQueue;// Replace original queue with updated queue
               
                Console.WriteLine(passengerName + " was removed from the check-in queue."); // Display confirmation message
            }
               // Check if passenger exists in boarding stack
            if (boardingStack.Contains(passengerName))
            {
                // Create temporary stack
                Stack<string> tempStack = new Stack<string>();

                // Remove all passengers from original stack
                while (boardingStack.Count > 0)
                {
                    // Get top passenger
                    string currentPassenger = boardingStack.Pop();

                    // Keep all passengers except cancelled passenger
                    if (currentPassenger != passengerName)
                    {
                        tempStack.Push(currentPassenger);
                    }
                  
                    Console.WriteLine(passengerName + " was removed from the boarding stack.");
                }
            }
            }
            public static void PassengerCheckIn()
        {
            bool back1 = false;

            while (back1 == false)
            {
                Console.WriteLine("(1) Check in a passenger");
                Console.WriteLine("(2) View check-in queue");
                Console.WriteLine("(3) Process next passenger");
                Console.WriteLine("(0) Back.");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Check in a passenger");
                        Console.Write("Enter Ticket ID: ");
                        string ticketID = Console.ReadLine();
                        // Check if ticket exists
                        if (!TicketExists(ticketID)) break;
                        if (!NotCancelled(ticketID)) break;
                        if (!BookingExists(ticketID)) break;

                        string passengerName = GetPassengerName(ticketID);
                        if (checkedInQueue.Contains(passengerName))
                        {
                            Console.WriteLine("Passenger already in check-in queue.");
                            return;
                        }
                        if (checkedInQueue.Count < 10)
                        {
                            checkedInQueue.Enqueue(passengerName);
                            Console.WriteLine(passengerName + " checked in successfully.");
                        }
                        else
                        {
                            waitlistQueue.Enqueue(passengerName);
                            Console.WriteLine(passengerName + " checked in waiting list.");
                        }


                        break;

                    case 2:
                        Console.WriteLine("View check-in queue");
                        int pos = 1;
                        foreach (string p in checkedInQueue)
                        {
                            Console.WriteLine(pos + ". " + p);
                            pos++;
                        }
                        Console.WriteLine("WaitList count: " + waitlistQueue.Count);
                        break;

                    case 3:
                        Console.WriteLine("Process next passenger");
                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("Queue is empty");
                            break;
                        }
                        string frontPassanger = checkedInQueue.Dequeue();
                        Console.WriteLine("Processed: " + frontPassanger);

                        if (waitlistQueue.Count > 0)
                        {
                            string nextPassenger = waitlistQueue.Dequeue();
                            checkedInQueue.Enqueue(nextPassenger);
                            Console.WriteLine(nextPassenger + "Moved from wait List to check in queue..");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Back to main menu");
                        back1 = true;

                       break;

                    default:
                        Console.WriteLine("Invalid choice.");
                       break;
                }
                Console.WriteLine("Press Any Key To Continue .....");
                Console.ReadKey();
                Console.Clear();
            }
        }
            public static void BoardPassengers()
        {
            bool back = false;

            while (back == false)
            {
                Console.WriteLine("1. Load boarding stack from check-in queue");
                Console.WriteLine("2. Board next passenger");
                Console.WriteLine("3. View boarding stack");
                Console.WriteLine("4. View boarding log");
                Console.WriteLine("0. Back");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Load passengers from check-in queue to boarding stack
                        if (checkedInQueue.Count == 0 && boardingStack.Count > 0)
                        {
                            Console.WriteLine("Boarding stack already loaded.");
                            break;
                        }

                        if (checkedInQueue.Count == 0)
                        {
                            Console.WriteLine("No passengers in check-in queue.");
                            break;
                        }

                        int loadedCount = 0;

                        while (checkedInQueue.Count > 0)
                        {
                            string passengerName = checkedInQueue.Dequeue();
                            boardingStack.Push(passengerName);
                            loadedCount++;
                        }

                        Console.WriteLine("Loaded passengers: " + loadedCount);
                        break;

                    case 2:
                        // Board next passenger from stack
                        if (boardingStack.Count == 0)
                        {
                            Console.WriteLine("No passengers in boarding stack.");
                            break;
                        }

                        string boardedPassenger = boardingStack.Pop();

                        string seat = currentRow.ToString() + currentSeat;

                        passengerSeatMap[boardedPassenger] = seat;

                        Console.WriteLine("Passenger boarded: " + boardedPassenger);
                        Console.WriteLine("Assigned Seat: " + seat);

                        // Move to next seat
                        if (currentSeat == 'F')
                        {
                            currentSeat = 'A';
                            currentRow++;
                        }
                        else
                        {
                            currentSeat++;
                        }

                        break;

                    case 3:
                        // View boarding stack without removing passengers
                        if (boardingStack.Count == 0)
                        {
                            Console.WriteLine("Boarding stack is empty.");
                            break;
                        }

                        int position = 1;

                        foreach (string passenger in boardingStack)
                        {
                            Console.WriteLine(position + ". " + passenger);
                            position++;
                        }

                        break;

                    case 4:
                        // View boarding log
                        if (passengerSeatMap.Count == 0)
                        {
                            Console.WriteLine("No passengers boarded yet.");
                            break; 
                        }

                        foreach (KeyValuePair<string, string> passenger in passengerSeatMap)
                        {
                            Console.WriteLine(passenger.Key + " -> Seat " + passenger.Value);
                        }

                        break;

                    case 0:
                        Console.WriteLine("Back to main menu.");
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("Press Any Key To Continue .....");
                Console.ReadKey();
                Console.Clear();
            }
        }

            public static void showMenue()
            {
                
                Console.WriteLine("=======================================");
                Console.WriteLine("\nSKY WINGS FLIGHT MANAGEMENT SYSTEM");
                Console.WriteLine("=======================================");
                Console.WriteLine("\n1. Register New Passenger");
                Console.WriteLine("\n2. View All Passengers");
                Console.WriteLine("\n3. Book a Flight Ticke");
                Console.WriteLine("\n4. View Booking Details");
                Console.WriteLine("\n5. Update a Booking");
                Console.WriteLine("\n6. Cancel a Ticket");
                Console.WriteLine("\n7. Passenger Check-In");
                Console.WriteLine("\n8. Board Passengers (Boarding Stack)");
                Console.WriteLine("\n9. Generate Flight Manifest");
                Console.WriteLine("\n10. Manage Waitlist & Seat Assignment");
                Console.WriteLine("\n0. Exit");
                Console.WriteLine("=======================================");
                Console.Write("\nEnter your choice: ");
            }
            static void Main(string[] args)
            {
                bool exit = false;
                while (exit == false)
                {
                showMenue();
                    int enterChoise = int.Parse(Console.ReadLine());
                    switch (enterChoise)
                    {
                        case 1://1. Register New Passenger
                            RegisterNewPassenger();
                            break;
                        case 2://2. View All Passengers
                            ViewAllPassengers();
                            break;
                        case 3://3. Book a Flight Ticke
                            BookFlightTicket();
                            break;
                        case 4://4. View Booking Details
                            ViewBookingDetails();
                            break;
                        case 5://5. Update a Booking
                            UpdateBooking();
                            break;
                        case 6://6. Cancel a Ticket
                            CencelTicket();
                            break;
                        case 7://7. Passenger Check-In
                            PassengerCheckIn();
                            break;
                        case 8://8. Board Passengers (Boarding Stack
                            BoardPassengers();
                            break;
                        case 9://9. Generate Flight Manifest
                            break;
                        case 10://10. Manage Waitlist & Seat Assignment
                            break;
                        case 0://0. Exit
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("=======================================");
                            Console.WriteLine("Invalid choice. Please try again.");

                            break;

                    }
                    Console.WriteLine("Press Any Key To Continue .....");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }