using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;

namespace RepositoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new DepartmentRepo();
            var ITDepartment = repo.GetDepartmentById(1);
            Console.WriteLine(ITDepartment.ID+" "+ITDepartment.Name+" "+ITDepartment.Instructor);

            var nd = repo.GetDepartmentByName("HR");
            Console.WriteLine("====================");
            Console.WriteLine(nd.Name);

            var all = repo.GetAllDepartments();
            Console.WriteLine("====================");
            Console.WriteLine("All Departments");
            foreach (var item in all)
            {
                Console.WriteLine(item.Name);
            }

            var highest = repo.GetHighestDepartment();
            Console.WriteLine("=====================");
            Console.WriteLine("The highest budget department is: "+highest.Name);
            Console.ReadLine();

        }
    }
}
