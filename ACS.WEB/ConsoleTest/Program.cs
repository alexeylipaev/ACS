using ACS.DAL;
using ACS.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
     static void  TestEntities()
        {
            using (ACSContext db = new ACSContext(Сonnection.@string))
            {
                db.RunSeed();
                Console.WriteLine();
                foreach (var empl in db.Employees)
                {
                    Console.WriteLine(empl.FullName);
                }
            }
        }

        static void Main(string[] args)
        {
            TestEntities();
        }
    }
}
