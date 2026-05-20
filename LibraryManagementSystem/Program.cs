using System.Runtime.InteropServices.JavaScript;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace LibraryManagementSystem
{
    internal class Program
    {
        //System Storage 
        static string memberName = "";
        static int memberID = 0;
        static string memberEmail = "";
        static string membershipExpiryDate = "";
        static string memberTier = "";
        static bool isMemberRegistered = false;
        static string bookTitle = "";
        static string bookAuthor = "";
        static string bookGenre = "";
        static int availableCopies = 0;
        static bool isBookRegistered = false;
        static int totalBooksBorrowedThisSession = 0;
        static double totalFinesPaidThisSession = 0;
        

        public static void PrintMenuStyle()
        { //PrintMenu-style functions 
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("0.Register Member ");
            Console.WriteLine("1.Display Member Profile ");
            Console.WriteLine("2.Search Book by Title ");
            Console.WriteLine("3.Borrow a Book ");
            Console.WriteLine("4.Return a Book  ");
            Console.WriteLine("5.Calculate Late Fine  ");
            Console.WriteLine("6.Apply Member Discount ");
            Console.WriteLine("7.Check Borrowing Eligibility ");
            Console.WriteLine("8.Register Book ");
            Console.WriteLine("9.Generate Member ID ");
            Console.WriteLine("10.Display Book Details  ");
            Console.WriteLine("11.Calculate Renewal Fee  ");
            Console.WriteLine("12.Update Member Email  ");
            Console.WriteLine("13.Session Summary   ");
            Console.WriteLine("14.Exit  ");
            Console.WriteLine("///////////////////////////////////");
            Console.Write(" Enter your choice: ");

        }
        public static DateTime GetTodaysDate()
        {
            //return type is DateTime , no parametrs
            return DateTime.Now;
        }
        public static void RegisterMember()
        {
            Console.Write("Enter Member Name :");
            memberName = Console.ReadLine(); 
            Console.Write("Enter member email :");
            memberEmail = Console.ReadLine();
            Console.Write("Enter membership expiry date :");
            membershipExpiryDate = Console.ReadLine();
            Console.Write("Enter member tier :");
            memberTier = Console.ReadLine();
            isMemberRegistered = true;

            memberID = new Random().Next(100000, 200000);
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("Member Registered Successfully... " + memberName.Substring(0,5).ToUpper());
            Console.WriteLine("ID Member : " + memberID);
            Console.WriteLine("Date and Time : " + DateTime.Now);
        }
        public static void DisplayMemberProfile()
        {
            Console.WriteLine("Member Name : " + memberName.PadLeft(20));
            Console.WriteLine("Member ID : "  + Convert.ToString(memberID).PadLeft(20));
            Console.WriteLine("Member Email : " + memberEmail.PadLeft(20));
            Console.WriteLine("Expiry Date : " + membershipExpiryDate.PadLeft(20));
            Console.WriteLine("Member Tier : " + memberTier.PadLeft(20));
        }
            //main methods
            static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                PrintMenuStyle();

                int EnterChoise = int.Parse(Console.ReadLine());
                switch (EnterChoise)
                {
                    case 0://0.Register Member
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("0.Register Member ");
                        Console.WriteLine("///////////////////////////////////");
                        if (isMemberRegistered)
                        {
                            Console.WriteLine("A member is already registered.");
                        }
                        else
                        {
                            RegisterMember();
                          
                        }

                    break;
                    case 1://1.Display Member Profile
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine(" Member Profile ");
                        Console.WriteLine("///////////////////////////////////");
                        if (isMemberRegistered == false)
                        {
                            Console.WriteLine("No member registered.");
                          
                        }
                        else
                        {
                            DisplayMemberProfile();
                        }
                        break;
                    case 2://2.Search Book by Title 
                        Console.WriteLine("2.Search Book by Title ");
                        break;
                    case 3://3.Borrow a Book
                        Console.WriteLine("3.Borrow a Book ");
                        break;
                    case 4://4.Return a Book
                        Console.WriteLine("4.Return a Book  ");
                        break;
                    case 5://5.Calculate Late Fine
                        Console.WriteLine("5.Calculate Late Fine  ");
                        break;
                    case 6://6.Apply Member Discount
                        Console.WriteLine("6.Apply Member Discount ");
                        break;
                    case 7://7.Check Borrowing Eligibility 
                        Console.WriteLine("7.Check Borrowing Eligibility ");
                        break;
                    case 8://8.Register Book
                        Console.WriteLine("8.Register Book ");
                        break;
                    case 9://9.Generate Member ID
                        Console.WriteLine("9.Generate Member ID ");
                        break;
                    case 10://10.Display Book Details
                        Console.WriteLine("10.Display Book Details  ");
                        break;
                    case 11://11.Calculate Renewal Fee
                        Console.WriteLine("11.Calculate Renewal Fee  ");
                        break;
                    case 12://12.Update Member Email
                        Console.WriteLine("12.Update Member Email  ");
                        break;
                    case 13://13.Session Summary
                        Console.WriteLine("13.Session Summary   ");
                        break;
                    case 14://14.Exit
                        Console.WriteLine("14.Exit  ");
                        exit = true;
                        break;
                   

                }//end of switch
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }//end of while 

        }
    }
}
