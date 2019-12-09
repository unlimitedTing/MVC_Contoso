using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ContosoDbContext context) : base(context)// access base class constructor
        {
        }

        public Department GetDepartmentByName(string name)
        {
            var department = _dbContext.Departments.FirstOrDefault(d => d.Name == name);
            return department;
        }
    }
    public interface IDepartmentRepository:IRepository<Department>
    {
        Department GetDepartmentByName(string name);
    }
}
