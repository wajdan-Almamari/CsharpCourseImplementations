namespace BuiltinFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // double w = Math.Max(5, 10);
           // int e = Math.Min(5, 10);
            //double result = Math.Abs(-5);
           // Console.WriteLine("Max number is :" +w);
           // Console.WriteLine("Min number is :" +e);
            //Console.WriteLine("Min number is :" +result);

           
            string text = "Clinic Management System";
           
            Console.WriteLine("Enter your search : ");
            string search = Console.ReadLine();

            if (text.Contains(search) ){ 
                Console.WriteLine("your search about :" + text);

            }
            else
            {
                Console.WriteLine(" Can not found"); 
            }


             


        }
    }
}
