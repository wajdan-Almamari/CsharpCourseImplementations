using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //rejon 1 : system storage ( variables )
            string gName = "";
            string gPhone = "";
            int roomNum = 0;
            char roomType = ' ';
            double nightlyRate = 0;
            DateTime checkinDate ;
            DateTime checkoutDate ;
            int numOfNight = 0;
            string roomNote = "";
            double discountPercentage = 0;
            int loyaltyPoints = 0;
            bool isGuestRegist = false;

            //rejon 2 : system processing ( menu functions )
            bool exit =false;
            while(exit == false)
            {

            
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------Hotel Management System-------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("   0.Register New Guest");
            Console.WriteLine("   1.View Guest Information");
            Console.WriteLine("   2.Check-In Guest");
            Console.WriteLine("   3.Check-Out & Bil");
            Console.WriteLine("   4.Apply Discount");
            Console.WriteLine("   5.Upgrade Room");
            Console.WriteLine("   6.Add Room Service Note");
            Console.WriteLine("   7.Search Guest by Name");
            Console.WriteLine("   8.Calculate Loyalty Points");
            Console.WriteLine("   9.Print Receipt");
            Console.WriteLine("   10.Edit Guest Name");
            Console.WriteLine("   11.Exit");
            Console.WriteLine("-------------------------------------");
            Console.Write(" Enter your choice: ");

            int EnterChoise = Convert.ToInt32(Console.ReadLine());

                switch (EnterChoise)
                {
                    case 0://0.Register New Guest
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("   0.Register New Guest");
                        Console.WriteLine("-------------------------------------");
                        Console.Write("Enter gust Name : ");
                        gName = Console.ReadLine().Trim();
                        Console.Write("Enter gust Phone : ");
                        gPhone = Console.ReadLine().Trim();
                        Console.Write("Enter Room Type (S/D/F) : ");
                        roomType=char.Parse(Console.ReadLine());
                        Console.Write("Enter your Nightly Rate : ");
                        nightlyRate = double.Parse(Console.ReadLine());
                        
                        roomNum  = new Random().Next(1,20);
                        //Random random = new Random();
                        //roomNum = random.Next(1, 20);

                        isGuestRegist = true;

                        Console.WriteLine("Guest registered successfully.");
                        Console.WriteLine("Room Number: " + roomNum);
                        
                        
                        break;
                    case 1://1.View Guest Information
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("   1.View Guest Information");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("No guest information found.");
                        }
                        else
                        {
                            Console.WriteLine("Guest Name: " + gName.ToUpper());
                            Console.WriteLine("Guest Phone: " + gPhone);
                            Console.WriteLine("Room Number: " + Convert.ToString(roomNum));
                            Console.WriteLine("Room Type : " + roomType);
                            Console.WriteLine("Nightly Rate : " + Math.Round(nightlyRate));

                        }
                      
                        break;
                    case 2:// 2.Check-In Guest
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("   2.Check-In Guest");
                        Console.WriteLine("-------------------------------------");
                        if(isGuestRegist== false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            Console.Write("Enter Number of Nights : ");
                            numOfNight=int.Parse(Console.ReadLine());
                       
                            checkinDate = DateTime.Now;
                            checkoutDate = DateTime.Today.AddDays(numOfNight);
                            
                            Console.WriteLine("Check-In Date: " + checkinDate);
                            Console.WriteLine("Check-Out Date: " + checkoutDate);

                        }
                        break;
                    case 3://3.Check-Out & Bil
                        Console.WriteLine();
                        break;
                    case 4:// 4.Apply Discount
                        Console.WriteLine();
                        break;
                    case 5://5.Upgrade Room
                        Console.WriteLine();
                        break;
                    case 6://6.Add Room Service Note
                        Console.WriteLine();
                        break;
                    case 7://7.Search Guest by Name
                        Console.WriteLine();
                        break;
                    case 8:// 8.Calculate Loyalty Points
                        Console.WriteLine();
                        break;
                    case 9://9.Print Receipt
                        Console.WriteLine();
                        break;
                    case 10://10.Edit Guest Name
                        Console.WriteLine();
                        break;
                    case 11://11.Exit
                        exit=true;

                        break;
                }//end of switch

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }//end of while
        }
    }
}
