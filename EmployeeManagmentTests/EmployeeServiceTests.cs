using Domain.BL.Services.Implementation;
using Domain.BL.Services.Interfaces;
using Domain.DAL;
using Domain.DAL.GenericRepo;
using Domian.Entities;
using Domian.Entities.Dto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentTests
{
    public class EmployeeServiceTests
    {
        private IEmployeeService employeeService;
        private Mock<IGenericRepository<Employee>> mockRepository;
        public EmployeeServiceTests()
        {
            mockRepository = new Mock<IGenericRepository<Employee>>();
            employeeService = new EmployeeService(mockRepository.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddEmployeeToRepository()
        {
            var Model = new EmployeeDto()
            { 
                Id = 10,
                FirstName = "Ali",
                LastName ="Test",
                MiddleName ="Test",
            };

            var result  =await employeeService.AddAsync(Model);

            mockRepository.Verify(repo => repo.Add(It.IsAny<Employee>()), Times.Once);
        }
    }
}
