using System.Collections;

namespace HotelManagement_ListTasks
{
    internal class Program
    {
        public static void MainMenu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Hotel Management System List Practice");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Problem 1: Room Service Menu");
            Console.WriteLine("Problem 2: Guest Check-In Queue");
            Console.WriteLine("Problem 3: Housekeeping Floor Assignment");
            Console.WriteLine("Problem 4: Hotel Booking Conflict Resolver");
            Console.WriteLine("0:Exit");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------------------------------------");

            Console.Write("Enter your choise : ");
        }
        public static void RoomServiceMenu()
        {
            // Create a list to store menu items

            List<string> menuItems = new List<string>();
            menuItems.AddRange(new string[] { "Sandwich", "Pizza", "Burger", "Steak" });
            Console.WriteLine("--- Current Menu ---");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine(menuItems[i]);
            }
            Console.WriteLine(" Menue Items: " + menuItems.Count);
            menuItems.Add("Pasta");
            menuItems.Add("Salad");
            Console.WriteLine("\n Updated Menu After Adding Dishes ---");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }
            menuItems.Remove("Pizza");
            Console.WriteLine("--- Menu After Removing Pizza ---");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }
            if (menuItems.Contains("Burger"))
            {
                Console.WriteLine("Burger is available.");
            }
            else
            {
                Console.WriteLine("Burger is not available.");
            }
        }
            static void Main(string[] args)
            {
                bool exit = false;
                while (exit == false)
                {
                    MainMenu();
                    int enterChoise = int.Parse(Console.ReadLine());
                    switch (enterChoise)
                    {
                        case 1://Problem 1: Room Service Menu  
                            RoomServiceMenu();
                            break;
                        case 2://Problem 2: Guest Check-In Queue    
                            break;
                        case 3://Problem 3: Housekeeping Floor Assignment
                            break;
                        case 4://Problem 4: Hotel Booking Conflict Resolver 
                            break;
                        case 0://Exit
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("-------------------------------------");
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


