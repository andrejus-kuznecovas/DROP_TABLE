﻿namespace BackendApartmentReservation.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BackendApartmentReservation.Offices.Interfaces;
    using Database.Entities;
    using DataContracts.DataTransferObjects.Requests;
    using DataContracts.DataTransferObjects.Responses;
    using Infrastructure.Exceptions;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IOfficeManager _officeManager;

        public EmployeesController(IEmployeeManager employeeManager, IOfficeManager officeManager)
        {
            _employeeManager = employeeManager;
            _officeManager = officeManager;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
        {
            return await _employeeManager.GetAllEmployees();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("employees")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            DbEmployee dbEmployee = new DbEmployee();
            dbEmployee.FirstName = model.FirstName;
            dbEmployee.LastName = model.LastName;
            dbEmployee.Email = model.Email;
            dbEmployee.Office = await _officeManager.GetOfficeById(model.Office);

            var employeeId = await _employeeManager.CreateEmployee(dbEmployee);

            var response = new RegisterResponse
            {
                Id = employeeId
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("employees/{userId}")]
        public async Task<IActionResult> GetEmployeeById(string employeeID)
        {
            var employee = await _employeeManager.GetEmployeeByEmployeeId(employeeID);

            if (employee == null)
            {
                return BadRequest(ErrorCodes.EmployeeNotFound);
            }

            return Ok(employee);
        }
    }
}