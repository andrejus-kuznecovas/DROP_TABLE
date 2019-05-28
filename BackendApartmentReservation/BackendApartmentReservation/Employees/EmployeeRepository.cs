﻿namespace BackendApartmentReservation.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Database;
    using Database.Entities;
    using DataContracts.DataTransferObjects.Requests;
    using Infrastructure.Exceptions;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbEmployee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<DbEmployee> GetEmployeeById(int employeeID)
        {
            return await _context.Employees.FindAsync(employeeID);
        }

        public async Task<DbEmployee> GetEmployeeByEmployeeId(string employeeID)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.ExternalEmployeeId == employeeID);
        }

        public async Task CreateEmployee(DbEmployee dbEmployee)
        {
            if (dbEmployee.FirstName != null && dbEmployee.LastName != null && dbEmployee.Email != null)
            {
                await _context.Employees.AddAsync(dbEmployee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task UpdateEmployee(DbEmployee dbEmployee)
        {
            _context.Employees.Update(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(DbEmployee dbEmployee)
        {
            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DbEmployeePlan>> GetEmployeePlans(IEnumerable<string> employeeIds)
        {
            return await _context.EmployeePlans
                .Include(p => p.Employee)
                .Where(p => employeeIds.Contains(p.Employee.ExternalEmployeeId))
                .ToListAsync();
        }

        public async Task<DbEmployeePlan> CreateEmployeePlan(DbEmployeePlan dbEmployeePlan)
        {
            await _context.EmployeePlans.AddAsync(dbEmployeePlan);
            await _context.SaveChangesAsync();
            return dbEmployeePlan;
        }

        public async Task ChangeUserInfo(string employeeId, ChangeUserInfoRequest changeUserInfoRequest)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.ExternalEmployeeId == employeeId);

            if (employee == null)
            {
                throw new ErrorCodeException(ErrorCodes.EmployeeNotFound);
            }

            employee.FirstName = changeUserInfoRequest.FirstName;
            employee.LastName = changeUserInfoRequest.LastName;
            employee.Email = changeUserInfoRequest.Email;
            employee.Role = changeUserInfoRequest.Role;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}