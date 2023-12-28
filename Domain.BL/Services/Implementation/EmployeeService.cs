using Domain.BL.Services.Interfaces;
using Domain.DAL.GenericRepo;
using Domian.Entities;
using Domian.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
        {
            var entity = setEntity(employeeDto);
            await _repository.Add(entity);
            _repository.SaveChange();
            return employeeDto;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChange();
        }

        public List<EmployeeDto> GetAll()
        {
            var employeeList = _repository.GetAll().ToList();
            return employeeList.Select(setDto).ToList();
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByID(id);
            return setDto(employee);

        }

        public EmployeeDto Update(EmployeeDto employeeDto)
        {
            var updatedEmployee = _repository.update(setEntity(employeeDto));
            _repository.SaveChange();
            return setDto(updatedEmployee);
        }

        private EmployeeDto setDto(Employee employee)
        {
            return new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
            };
        }
        private Employee setEntity(EmployeeDto employeeDto)
        {
            return new()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
            };
        }
    }
}
