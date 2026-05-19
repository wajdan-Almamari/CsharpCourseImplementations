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
            Console.WriteLine("0.Register New Guest");
            Console.WriteLine("1.View Guest Information");
            Console.WriteLine("2.Check-In Guest");
            Console.WriteLine("3.Check-Out & Bill");
            Console.WriteLine("4.Apply Discount");
            Console.WriteLine("5.Upgrade Room");
            Console.WriteLine("6.Add Room Service Note");
            Console.WriteLine("7.Search Guest by Name");
            Console.WriteLine("8.Calculate Loyalty Points");
            Console.WriteLine("9.Print Receipt");
            Console.WriteLine("10.Edit Guest Name");
            Console.WriteLine("11.Exit");
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
                        roomType = char.Parse(Console.ReadLine());
                        Console.Write("Enter your Nightly Rate : ");
                        nightlyRate = double.Parse(Console.ReadLine());

                        roomNum = new Random().Next(1, 20);
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
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            Console.Write("Enter Number of Nights : ");
                            numOfNight = int.Parse(Console.ReadLine());

                            checkinDate = DateTime.Now;
                            checkoutDate = DateTime.Today.AddDays(numOfNight);

                            Console.WriteLine("Check-In Date: " + checkinDate);
                            Console.WriteLine("Check-Out Date: " + checkoutDate);

                        }
                        break;
                    case 3://3.Check-Out & Bil
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("   3.Check-Out & Bill");
                        Console.WriteLine("------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            double totalBill = nightlyRate * numOfNight;
                            double discountAmount = totalBill * (discountPercentage / 100);
                            Console.WriteLine("Total Bill: " + Math.Round(totalBill));
                            isGuestRegist = false;

                        }
                        break;
                    case 4:// 4.Apply Discount
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("4.Apply Discount");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");

                        }
                        else
                        {

                            double orginAmount = nightlyRate * numOfNight;

                            Console.Write("Enter discount percentage: ");
                            discountPercentage = Convert.ToDouble(Console.ReadLine());

                            double discountAmount = orginAmount * (discountPercentage / 100);
                            double discountedAmount = orginAmount - discountAmount;
                            double amountSaved = Math.Abs(discountAmount);

                            Console.WriteLine("Orginal Amount : " + Math.Round(orginAmount, 2));
                            Console.WriteLine("Discount Amount : " + Math.Round(discountedAmount, 2));
                            Console.WriteLine("Amount Saved : " + Math.Round(amountSaved, 2));

                        }
                        break;

                    case 5://5.Upgrade Room
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("5.Upgrade Room");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            char newRoomType;
                            double newRate;

                            Console.Write("Enter new room type (S/D/F): ");
                            newRoomType = char.Parse(Console.ReadLine());

                            Console.Write("Enter new nightly rate: ");
                            newRate = Convert.ToDouble(Console.ReadLine());
                            double higherRate = Math.Max(nightlyRate, newRate);
                            double lowerRate = Math.Min(nightlyRate, newRate);
                            double difference = Math.Abs(newRate - nightlyRate);
                            Console.WriteLine("Higher Rate : " + Math.Round(higherRate, 2));
                            Console.WriteLine("Lower Rate : " + Math.Round(lowerRate, 2));
                            Console.WriteLine("Difference Per Night : " + Math.Round(difference, 2));

                            roomType = newRoomType;
                            nightlyRate = newRate;

                            Console.WriteLine("Room upgraded successfully.");

                        }
                        break;
                    case 6://6.Add Room Service Note
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("6.Add Room Service Note");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            string newNote;
                            Console.Write("Enter room service note: ");
                            newNote = Console.ReadLine().Trim();
                            if (newNote == "")
                            {
                                Console.WriteLine("Note cannot be blank.");
                            }
                            else
                            {
                                roomNote = roomNote + newNote;

                                roomNote = roomNote.Replace("dirty", "***");

                                Console.WriteLine("Updated Notes : " + roomNote);
                                Console.WriteLine("Total Notes Length : " + roomNote.Length);
                            }
                        }

                        break;
                    case 7://7.Search Guest by Name
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("7.Search Guest by Name");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            string keyword;
                            Console.Write("Enter search keyword: ");
                            keyword = Console.ReadLine().Trim();

                            if (gName.ToLower().Contains(keyword.ToLower()))
                            {
                                Console.WriteLine("Guest found.");
                            }
                            else
                            {
                                Console.WriteLine("Guest not found.");
                            }
                        }
                
                        break;
                    case 8:// 8.Calculate Loyalty Points
                        Console.WriteLine(" ");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("8.Calculate Loyalty Points");
                        Console.WriteLine("-------------------------------------");

                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }

                        else
                        {
                            double earnedPoints;
                            earnedPoints = Math.Pow(numOfNight, 2);
                            loyaltyPoints = loyaltyPoints + Convert.ToInt32(earnedPoints);

                            Console.WriteLine("Earned Points : " + Math.Round(earnedPoints, 2));
                            Console.WriteLine("Total Loyalty Points : " + loyaltyPoints);
                        }

                        break;
                    case 9://9.Print Receipt
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("9.Print Receipt");
                        Console.WriteLine("-------------------------------------");
                        string receipt;
                        
                        
                        break;
                    case 10://10.Edit Guest Name
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("10.Edit Guest Name");
                        Console.WriteLine("-------------------------------------");
                        if (isGuestRegist == false)
                        {
                            Console.WriteLine("Please register guest first.");
                        }
                        else
                        {
                            string newName;
                            Console.Write("Enter new guest name: ");
                            newName = Console.ReadLine().Trim();
                            if (newName.Length < 3)
                            {
                                Console.WriteLine("Name is too short.");
                            }

                            else
                            {
                                Console.WriteLine("Uppercase Preview : " + newName.ToUpper());
                                Console.WriteLine("Lowercase Preview : " + newName.ToLower());
                                gName = newName;
                                Console.WriteLine("Guest name updated successfully.");
                            }
                        }
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
