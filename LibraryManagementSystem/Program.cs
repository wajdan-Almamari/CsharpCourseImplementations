using System.Runtime.InteropServices.JavaScript;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
  
        public static void RegisterMember()
        {
            //void — no parameters 
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
        public static bool SearchBookByTitle(string keyword)
        {

            Console.WriteLine(bookTitle.Substring(0, bookTitle.Length));
            if (bookTitle.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }

            return false;
        }
        public static void RegisterBook(string title,string author,int copies,string genre = "General")
        {
           
            bookTitle = title.Trim();
            bookAuthor = author.Trim();
            availableCopies = copies;
            bookGenre = genre.Trim();

            isBookRegistered = true;

            Console.WriteLine("Book Registered Successfully.");
        }
        public static void BorrowBook(ref int copies)
        {
            copies = Math.Max(0, copies - 1); //
            totalBooksBorrowedThisSession++;

            Console.WriteLine("Book Borrowed Successfully.");
            Console.WriteLine("Available Copies : " + copies);
        }

        public static void ReturnBook(ref int copies)
        {
            copies = copies + 1;
            Console.WriteLine("Book Returned Successfully.");
            Console.WriteLine("Available Copies : " + copies);
        }

        public static double CalculateLateFine(int overdueDays)
        {
            // Calculates the late fine based on overdue days
            Console.Write("Enter overdue days : ");
            double fine = Math.Sqrt(overdueDays) * 2;// Calculate fine using square root
            fine = Math.Round(fine, 2);// Round the result to 2 decimal places

            return fine;// Return the final fine amount

        }

        // Applies default discount
        public static double ApplyDiscount(double amount)
        {
            double finalAmount = amount -(amount * 0.10); // Apply a 10% discount
            return Math.Round(finalAmount, 2); // Round the result to 2 decimal places

        }
        // Applies discount based on member tier
        public static double ApplyDiscount(double amount, string tier)
        {
            tier = tier.ToUpper(); // Convert tier to uppercase
            double discount = 0.10;

            // Gold members get 20% discount
            if (tier == "GOLD") {
               discount = 0.20;
            }
            // Calculate discounted amount
            double finalAmount = amount - (amount * discount);

            // Return rounded result
            return Math.Round(finalAmount, 2);

        }
        public static bool CheckBorrowingEligibility(string expiryDate)
        {
            // Convert string to DateTime
            DateTime expiry = DateTime.Parse(expiryDate);
            // Compare expiry date with today's date
            if (expiry >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
        // Generates a unique member ID
        public static string GenerateMemberID()
        {
            // Take first 3 letters from member name
            string namePart = memberName.Substring(0, 3).ToUpper();
            // Apply mathematical operation on timestamp
            double number = Math.Sqrt(DateTime.Now.Millisecond);
            // Combine name and number
            string memberID = namePart + ((int)number);

            return memberID;
        }
        // Displays book details
        public static void DisplayBookDetails (string title, string author,  string genre,int copies )
        {
            Console.WriteLine("Book Title : ".PadRight(20) + title);
            Console.WriteLine("Book Author : ".PadRight(20) + author);
            Console.WriteLine("Book Genre : ".PadRight(20) + genre);
            Console.WriteLine("Available Copies : ".PadRight(20) + Convert.ToString(copies));
        }
        // Calculates renewal fee for standard members
        public static double CalculateRenewalFee(int renewalDays)
        {
            double fee = renewalDays * 0.5;

            // Round fee up to nearest whole number
            return Math.Ceiling(fee);
        }

        // Calculates renewal fee for premium members
        public static double CalculateRenewalFee(int renewalDays, bool isPremium)
        {
            double fee = renewalDays * 0.5;
            // Premium members pay half the fee
            if (isPremium)
            {
                fee = fee / 2;
            }

            // Round fee up to nearest whole number
            return Math.Ceiling(fee);
        }
        // Validates and updates member email
        public static bool UpdateMemberEmail(string newEmail, out string cleanedEmail)
        {
            // Remove extra spaces
            cleanedEmail = newEmail.Trim();

            return false;
        }
        // Displays session summary
        public static void SessionSummary()
        {
            Console.WriteLine("/////////////////////////////////////");
            Console.WriteLine("========== Session Summary ==========");
            Console.WriteLine("/////////////////////////////////////");
            Console.WriteLine("Member Name : " + memberName);
            Console.WriteLine("Books Borrowed : "   + Convert.ToString(totalBooksBorrowedThisSession));
            Console.WriteLine("Total Fines Paid : "  + Convert.ToString(Math.Round(totalFinesPaidThisSession, 2)));
            Console.WriteLine("Current Date & Time : "   + DateTime.Now);
        }
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
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("Search Book by Title ");
                        Console.WriteLine("///////////////////////////////////");
                        Console.Write("Enter keyword : ");
                        string keyword = Console.ReadLine();

                        if (isBookRegistered == false)
                        {
                            Console.WriteLine("No book registered.");
                        }
                        else
                        {
                           

                            if (SearchBookByTitle(keyword))
                            {
                                Console.WriteLine("Book Found:    " + bookTitle);
                            }
                            else
                            {
                                Console.WriteLine("Book Not Found");
                            }
                        }
                        break;
                    case 3://3.Borrow a Book
                        Console.WriteLine("3.Borrow a Book ");
                        if (isBookRegistered ==false)
                        {
                            Console.WriteLine("No book registered.");
                        }
                        else
                        {
                            BorrowBook(ref availableCopies);
                        }

                        break;
                   
                    case 4://4.Return a Book
                        Console.WriteLine("4.Return a Book  ");
                        if (isBookRegistered ==false)
                        {
                            Console.WriteLine("No book registered.");
                        }
                        else
                        {
                            ReturnBook(ref availableCopies);
                        }
                        break;
                    case 5://5.Calculate Late Fine
                        Console.WriteLine("5.Calculate Late Fine  ");
                        Console.Write("Enter overdue days : ");
                        int overdueDays = int.Parse(Console.ReadLine());
                        double fine = CalculateLateFine(overdueDays);
                        Console.WriteLine("Late Fine : " + fine);


                        break;
                    case 6://6.Apply Member Discount
                        Console.WriteLine("6.Apply Member Discount ");
                        Console.Write("Enter amount : ");
                        double amount = double.Parse(Console.ReadLine());

                        Console.Write("Enter member tier : ");
                        string tier = Console.ReadLine();
                        double finalAmount = ApplyDiscount(amount, tier);
                        Console.WriteLine("Discounted Amount : " + finalAmount);
                        break;
                    case 7://7.Check Borrowing Eligibility 
                        Console.WriteLine("7.Check Borrowing Eligibility ");
                        if (CheckBorrowingEligibility(membershipExpiryDate))
                        {
                            Console.WriteLine("Member is eligible to borrow.");
                        }
                        else
                        {
                            Console.WriteLine("Membership expired.");
                        }

                        break;
                    case 8://8.Register Book
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("8.Register Book ");
                        Console.WriteLine("///////////////////////////////////");

                        //optional parameter 
                        Console.Write("Enter Book Title : ");
                       string title = Console.ReadLine();
                        Console.Write("Enter Book Author : ");
                       string author = Console.ReadLine();
                        Console.Write("Enter Copies : ");
                      int copies = int.Parse(Console.ReadLine());

                        RegisterBook(title,author, copies);
                        break;
                    case 9://9.Generate Member ID
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("9.Generate Member ID ");
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("Generated Member ID : " + GenerateMemberID());
                        break;
                    case 10://10.Display Book Details
                        Console.WriteLine("10.Display Book Details  ");
                            DisplayBookDetails( title: bookTitle,author: bookAuthor,genre: bookGenre,copies: availableCopies);
                        break;
                    case 11://11.Calculate Renewal Fee
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("11.Calculate Renewal Fee  ");
                        Console.WriteLine("///////////////////////////////////");
                        Console.Write("Enter renewal days : ");
                        int renewalDays = int.Parse(Console.ReadLine());
                        Console.Write("Is Premium Member? (true/false) : ");
                        bool isPremium = bool.Parse(Console.ReadLine());
                        double fee = CalculateRenewalFee(renewalDays, isPremium);

                        Console.WriteLine("Renewal Fee : " + fee);

                        break;
                    case 12://12.Update Member Email
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("12.Update Member Email  ");
                        Console.WriteLine("///////////////////////////////////");
                        Console.Write("Enter New Email : ");

                        string newEmail = Console.ReadLine();

                        string cleanedEmail;

                        if (UpdateMemberEmail(newEmail, out cleanedEmail))
                        {
                            memberEmail = cleanedEmail;

                            Console.WriteLine("Email Updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Email.");
                        }
                        break;
                    case 13://13.Session Summary
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("13.Session Summary   ");
                        SessionSummary();
                        break;
                    case 14://14.Exit
                        Console.WriteLine("14.Exit  ");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("///////////////////////////////////");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;


                }//end of switch
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }//end of while 

        }
    }
}
