using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dat154Entities dbContext = new dat154Entities();

            DbSet<student> students = dbContext.student;

            foreach (student student in students.Where(student => student.studentname.Contains("k")))
            {
                Console.WriteLine(student.studentname); 
            }
            Console.WriteLine("\n\nPress a key to end...");
            Console.ReadLine();
        }
    }
}
