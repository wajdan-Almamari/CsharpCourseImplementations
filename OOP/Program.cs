using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
namespace OOP
{
    public class Student
    {
        public string studentName;
        public int studentId;
        public List <string> coursName;
        public string university{ get; }

        public Student(int id ,string name , List <string> couName) //parametrized Constructor
        {
            studentName = name;
            studentId = id;
            coursName = couName;
        }

        public Student()
        {
            university = "Ibri College Of Applied science";
        }
       public void DelSubject(string subject)
        {
            coursName.Remove(subject);
        }
       public void AddSubject(string subject)
        {
            coursName.Add(subject);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //List <string> cources = new List<string> () { "comp01", "Math01" };
            //Student W = new Student(222, "wajdan",);
           Student s = new Student();
            s.studentId = 1;
            s.studentName = "Wajdan";
           //
           //
           s.coursName = new List<string>() { "comp01", "Math01" };
            //Console.WriteLine(W.coursName);
            //
            //Console.WriteLine(s.coursName);
            foreach (string course in s.coursName)
            {
                Console.WriteLine(course);
            }
        }
    }
}
