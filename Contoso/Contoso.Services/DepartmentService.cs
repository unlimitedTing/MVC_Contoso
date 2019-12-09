using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;

namespace Contoso.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
            //any class that implement this interface can be passed in as parameter
        {
            _departmentRepository = departmentRepository;
        }
        public void CreateDepartment(Department department)
        {
            _departmentRepository.Add(department);
            _departmentRepository.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public Department GetDepartmentByName(string name)
        {
            return _departmentRepository.GetDepartmentByName(name);
        }

        public int GetTotalDepartmentCount()
        {
            return _departmentRepository.GetCount();
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }

    public interface IDepartmentService
    {

        IEnumerable<Department> GetAllDepartments();

        int GetTotalDepartmentCount();

        Department GetDepartmentById(int id);

        Department GetDepartmentByName(string name);

        void CreateDepartment(Department department);

        void Update(Department department);

    }

    //public class DepartmentService2 : IDepartmentService
    //{
    //    private readonly IDepartmentRepository _departmentRepository;
    //    public DepartmentService2(IDepartmentRepository departmentRepository)
    //    //any class that implement this interface can be passed in as parameter
    //    {
    //        _departmentRepository = departmentRepository;
    //    }
    //    public void CreateDepartment(Department department)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Department> GetAllDepartments()
    //    {
    //        return _departmentRepository.GetAll();
    //    }

    //    public Department GetDepartmentById(int id)
    //    {
    //        return _departmentRepository.GetById(id);
    //    }

    //    public Department GetDepartmentByName(string name)
    //    {
    //        return _departmentRepository.GetDepartmentByName(name);
    //    }

    //    public int GetTotalDepartmentCount()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
