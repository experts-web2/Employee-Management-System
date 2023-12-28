using AutoMapper;
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
        public async Task<EmployeeDto> AddAsync(EmployeeDto employeeDto)
        {
            var entity = setEntity(employeeDto);
            await _repository.Add(entity);
            _repository.SaveChange();
            return employeeDto;
        }

        public async Task<string> Delete(int id)
        {
            var employee = await _repository.GetByID(id);
            if (employee == null)
            {
                return "No Record found";
            }
            _repository.Delete(id);
            _repository.SaveChange();
            return "Deleted Record";
        }

        public List<EmployeeDto> GetAll()
        {
            var employeeList = _repository.GetAll().ToList();
            if (employeeList != null)
            {
                return employeeList.Select(setDto).ToList();

            }
            return new List<EmployeeDto>();
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByID(id);
            if (employee != null)
            {
                return setDto(employee);
            }
            return new();
        }

        public async Task<EmployeeDto> Update(int Id, EmployeeDto employeeDto)
        {
            var employee = await _repository.GetByID(Id);
            if (employee != null)
            {
                
                employee = UpdateEmployee(employeeDto, employee);
                var updatedEmployee = _repository.update(employee);
                _repository.SaveChange();
                return setDto(updatedEmployee);
            }
            return new();
        }



        private Employee UpdateEmployee(EmployeeDto dto, Employee entity)
        {
            
            entity.FirstName = dto.FirstName;
            entity.MiddleName = dto.MiddleName;
            entity.LastName = dto.LastName;
            return entity;
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
