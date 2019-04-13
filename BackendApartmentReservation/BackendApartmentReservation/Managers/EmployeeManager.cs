﻿using System;
using System.Threading.Tasks;
using BackendApartmentReservation.Database.Entities;
using BackendApartmentReservation.Repositories;

namespace BackendApartmentReservation.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using DataContracts.DataTransferObjects.Responses;

    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> CreateEmployee(DbEmployee dbEmployee)
        {
            var employeeId = Guid.NewGuid().ToString() ;
            dbEmployee.ExternalEmployeeId = employeeId;

            await _employeeRepository.CreateEmployee(dbEmployee);
            return employeeId;
        }

        public async Task<IEnumerable<GetUserResponse>> GetAllEmployees()
        {
            var employees = await  _employeeRepository.GetAllEmployees();
            return employees.Select(e => new GetUserResponse
            {
                Id = e.ExternalEmployeeId,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName
            });
        }
    }
}
