using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;//MS Test for unit test
using Contoso.Models;
using Contoso.Services;
using Contoso.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Moq;

namespace Contoso.MVC.Tests.Services
{
    [TestClass]
    public class DepartmentServiceTest
    {
        private IDepartmentService _departmentService;
        // initilize the instance of mock data
        private Mock<IDepartmentRepository> _mockDepartmentRepository; 
        
        private List<Department> _departments;


        // if not use moq, we should implement all the repository methods with our test database, while by using
        // moq, it helps us to automatically create all these implementation and then set up them with the specified
        // test database as returns, so we only need to create the test base and then set up them with the method we 
        // want to test, which come from the service layer, derived from the mock repository that created by moq.

        [TestInitialize]
        public void Initilize()
        {
            // automatically create the MockDepartmentRepository class by moq in the runtime
            _mockDepartmentRepository = new Mock<IDepartmentRepository>();


            // we initilize the instance of service here instead of in the test method
            _departmentService = new DepartmentService(_mockDepartmentRepository.Object);

            // initilize the mock data field we created before
             _departments = new List<Department>
            {
                new Department
                {
                    ID=1,
                    Name="CS",
                    Budget=300,
                    StartDate=DateTime.Now
                },
                new Department
                {
                    ID=2,
                    Name="DA",
                    Budget=400,
                    StartDate=DateTime.Now
                },
                new Department
                {
                    ID=3,
                    Name="MATH",
                    Budget=500,
                    StartDate=DateTime.Now
                },
                new Department
                {
                    ID=4,
                    Name="ART",
                    Budget=600,
                    StartDate=DateTime.Now
                },

            };
            // setup method bind the getall method with sepcific return variables result to test if they are equal
            _mockDepartmentRepository.Setup(d => d.GetCount(null)).Returns(_departments.Count());
            _mockDepartmentRepository.Setup(d => d.GetAll()).Returns(_departments);
            // set up the method getbyid and return the firstordefault of the list _departments
            _mockDepartmentRepository.Setup(d => d.GetById(It.IsAny<int>())).Returns((int s) => _departments.First(x => x.ID == s));
        }
        [TestMethod]
        public void CheckDepartmentCountFromFakeData()
            //use data from in-memory to check the method
        {
            //_departmentService = new DepartmentService(new MockDepartmentRepository());
            

            var departments = _departmentService.GetAllDepartments();
            //AAA
            // Arrange: initilize object, create mock objects, or instances
            // Act: invoking the methods or properties
            // Assert: varify the action of method, make sure it behaves as expected

            // Assert come from MS Test (Unit test libraries)
            
            Assert.AreEqual(4, departments.Count());

        }

        [TestMethod]
        public void CheckDepartmentIDFromFakeData()
        {
            var department = _departmentService.GetDepartmentById(3);
            Assert.AreEqual("MATH", department.Name);
        }

        [TestMethod]
        public void CheckDepartmentNullFromFakeData()
        {
            var departments = _departmentService.GetAllDepartments();
            Assert.IsNotNull(departments);
        }
    }

    
    //public class MockDepartmentRepository : IDepartmentRepository
    //{
    //    public void Add(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department Get(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Department> GetAll()
    //    {
    //        var departments = new List<Department>
    //        {
    //            new Department
    //            {
    //                ID=1,
    //                Name="CS",
    //                Budget=300,
    //                StartDate=DateTime.Now
    //            },
    //            new Department
    //            {
    //                ID=2,
    //                Name="DA",
    //                Budget=400,
    //                StartDate=DateTime.Now
    //            },
    //            new Department
    //            {
    //                ID=3,
    //                Name="MATH",
    //                Budget=500,
    //                StartDate=DateTime.Now
    //            },
    //            new Department
    //            {
    //                ID=4,
    //                Name="ART",
    //                Budget=600,
    //                StartDate=DateTime.Now
    //            },

    //        };
    //        return departments;
    //    }

    //    public Department GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int GetCount(Expression<Func<Department, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department GetDepartmentByName(string name)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Department> GetMany(Expression<Func<Department, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void SaveChanges()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Department entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
