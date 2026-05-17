using System.ComponentModel.Design;

namespace ClinicManagementSystem_CMS_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //rejon 1 : system storage ( variables )
            string p1Name = "";
            int p1Age = 0; 
            string p1Phone = ""; 
            bool p1Active = false;
           

            //rejon 2 : system processing ( menu functions )
            bool backToMainP = false;
            while (backToMainP == false)
            
            {
                Console.WriteLine("Clinic Management System");
                Console.WriteLine("================================");
                Console.WriteLine(" 1. Patient Management ");
                Console.WriteLine(" 2. Appointment Management ");
                Console.WriteLine(" 3. Exit   ");
                Console.Write(" Enter your choice: ");

                int EnterChoise = Convert.ToInt32(Console.ReadLine());
                
                    switch (EnterChoise)
                {

                    case 1: // 1. Patient Management 
                        bool EnterChoisePa = false;
                        while(EnterChoisePa == false) { 
                        Console.WriteLine("================================");
                        Console.WriteLine(" 1. Add Patient Information");
                        Console.WriteLine(" 2. View  Patients Information");
                        Console.WriteLine(" 3. Edit Patient Information  ");
                        Console.WriteLine(" 4. Delete Patient Information ");
                        Console.WriteLine(" 5. Patient Report Information ");
                        Console.WriteLine(" 0. Back to Main Menu ");
                        Console.Write(" Enter your choice: ");
                        int EnterChoiseP = Convert.ToInt32(Console.ReadLine());
                            switch (EnterChoiseP)
                            {

                                case 1:

                                    //1. Add New Patient
                                    if (p1Active == true)
                                        Console.WriteLine("Clinic is full. Cannot add more patients");

                                    else
                                    {

                                        Console.Write("Enter your name:");
                                        p1Name = Console.ReadLine();
                                        Console.Write("Enter your Age:");
                                        p1Age = int.Parse(Console.ReadLine());
                                        Console.Write("Enter your Phone:");
                                        p1Phone = Console.ReadLine();
                                        p1Active = true;
                                        Console.WriteLine("Patient added successfully.");
                                    }


                                    break;
                                case 2://2. View  Patients
                                    Console.WriteLine("Choose an option to view:");
                                    Console.WriteLine("1. View Single Patient");
                                    Console.WriteLine("2. View All Patients");

                                    int choice = int.Parse(Console.ReadLine());

                                    if (choice == 1)
                                    {
                                        Console.WriteLine("Enter patient name:");
                                        string searchName = Console.ReadLine();

                                        if (p1Active && p1Name == searchName)
                                        {
                                            Console.WriteLine("Patient Name: " + p1Name);
                                            Console.WriteLine("Age : " + p1Age);
                                            Console.WriteLine("Phone : " + p1Phone);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Patient not found.");
                                        }
                                    }

                                    else if (choice == 2)
                                    {
                                        if (p1Active == false)
                                        {
                                            Console.WriteLine("No patients registered.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Patient Name: " + p1Name);
                                            Console.WriteLine("Age : " + p1Age);
                                            Console.WriteLine("Phone : " + p1Phone);
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("Invalid option please try again");
                                    }
                                    break;
                                case 3://3. Edit Patient 
                                  
                                        Console.Write("Enter patient name: ");
                                        string editName = Console.ReadLine();

                                        if (p1Active && p1Name == editName)
                                        {

                                            Console.WriteLine("================================");
                                            Console.WriteLine("1.Edit your Name");
                                            Console.WriteLine("2.Edit your Age");
                                            Console.WriteLine("3.Edit your Phone");
                                            Console.WriteLine("0.Back to Main Menu");
                                            Console.Write("Enter your choice: ");

                                            int EnterChoiseE = Convert.ToInt32(Console.ReadLine());

                                            switch (EnterChoiseE)
                                            {
                                                case 1://1.Edit your Name

                                                Console.Write("Enter new name: ");
                                                    p1Name = Console.ReadLine();

                                                    Console.WriteLine("Name updated successfully.");
                                                    break;

                                                case 2://2.Edit your Age

                                                Console.Write("Enter new age: ");
                                                    p1Age = Convert.ToInt32(Console.ReadLine());

                                                    Console.WriteLine("Age updated successfully.");
                                                    break;

                                                case 3://3.Edit your Phone

                                                Console.Write("Enter new phone: ");
                                                    p1Phone = Console.ReadLine();

                                                    Console.WriteLine("Phone updated successfully.");
                                                    break;

                                                case 0://0.Back to Main Menu
                                                break;

                                                default:
                                                    Console.WriteLine("Invalid choice.");
                                                    break;
                                            }
                                        }

                                        else
                                        {
                                            Console.WriteLine("Patient not found.");
                                        }//End of switch
                                        Console.WriteLine("Press Enter Any Key to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                 
                                    break;


                                case 4://4. Delete Patient
                                    Console.WriteLine("================================");
                                    Console.Write("Enter patient name to delete: ");
                                    string deleteName = Console.ReadLine();

                                    if (p1Active && p1Name == deleteName)
                                    {
                                        p1Name = "";
                                        p1Age = 0;
                                        p1Phone = "";
                                        p1Active = false;

                                        Console.WriteLine("Patient deleted successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Patient not found.");
                                    }

                                    break;
                                case 5: // Patient Report
                                    Console.WriteLine("================================");
                                    Console.WriteLine(" Patient Report");

                                    if (p1Active)
                                    {
                                        Console.WriteLine("Patient Name : " + p1Name);
                                        Console.WriteLine("Age : " + p1Age);
                                        Console.WriteLine("Phone : " + p1Phone);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No patient registered.");
                                    }

                                    break;
                                case 0: // 0. Back to Main Menu
                                    EnterChoisePa = true;
                                    break;

                             
                            }
                            Console.WriteLine("Press Enter Any Key to continue...");
                            Console.ReadLine();
                            Console.Clear();

                        }

                        break;

                    case 2://2. Appointment Management
                        Console.WriteLine("1.Book New Appointment");

                        break;
                    case 3: //3. Exit  
                        backToMainP = true; 
                        break;
                    default:
                        Console.WriteLine("================================");
                        Console.WriteLine("Invalid choice. Please try again.");
                    
                        break;

                }//end of switch
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear(); // clear the console for better user experience
            }//end of while
        }
    }
}
