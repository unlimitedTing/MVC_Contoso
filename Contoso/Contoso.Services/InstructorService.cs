using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;
using Contoso.Data;

namespace Contoso.Services
{
    
    public class InstructorService: IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void CreateInstructor(Instructor instructor)
        {
            _instructorRepository.Add(instructor);
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _instructorRepository.GetAll();
        }

        public Instructor GetInstructorByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public Instructor GetInstructorById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instructor> GetInstructorsByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetInstructorsByName(string name);
        Instructor GetInstructorByCode(string employeeCode);
        void CreateInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);

    }
}
