using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class InstructorRepository:Repository<Instructor>,IInstructorRepository
    {
        public InstructorRepository(ContosoDbContext context):base(context)
        {

        }
    }

    public interface IInstructorRepository : IRepository<Instructor>
    {

    }
}
