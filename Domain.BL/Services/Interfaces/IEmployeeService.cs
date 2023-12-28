using Domian.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetByIdAsync(int id);
        List<EmployeeDto> GetAll();
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
        EmployeeDto Update(EmployeeDto entity);
        void Delete(int id);
    }
}
