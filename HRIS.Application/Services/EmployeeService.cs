using HRIS.Domain;
using HRIS.Domain.Dtos;
using HRIS.Domain.Interfaces;
using HRIS.Domain.Models;
using HRIS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProcessRepository _processRepository;
        private readonly IEmailService _emailService;

        public EmployeeService(IEmployeeRepository employeeRepository, IProcessRepository processRepository, IEmailService emailService)
        {
            _employeeRepository = employeeRepository;
            _processRepository = processRepository;
            _emailService = emailService;
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<object>> GetAllEmployeesAsync(
        int pageNumber = 1,
        int pageSize = 10,
        string sortBy = "NameEmp",
        bool sortDesc = false,
        string filterBy = "",
        string filterValue = "")
        {
            return await _employeeRepository.GetAllEmployeesAsync(pageNumber, pageSize, sortBy, sortDesc, filterBy, filterValue);
        }

        public async Task<string> AddEmployeeAsync(Employees employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
                return "Data employee berhasil dtambah";
        }

        public async Task<bool> CreateLeaveRequestAsync(LeaveReqDto leaveRequestDto)
        {
            // Membuat leave request berdasarkan data yang diterima
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = leaveRequestDto.EmployeeId,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                LeaveType = leaveRequestDto.LeaveType,
                Reason = leaveRequestDto.Reason
            };


            var leaveRequestAdded = await _employeeRepository.AddLeaveRequestAsync(leaveRequest);

            if (!leaveRequestAdded)
            {
                return false;
            }


            var process = new Process
            {
                WorkflowId = 1,
                LeaveRequestId = leaveRequest.EmployeeId,
                RequestType = leaveRequest.LeaveType,
                Status = "Pending",
                CurrentStepId = 1,
                RequestDate = DateTime.UtcNow
            };


            await _processRepository.AddProcessAsync(process);


            var initialAction = new WorkflowActions
            {
                ProcessId = process.ProcessId,
                StepId = 1,
                ActorId = leaveRequestDto.EmployeeId.ToString(),
                Action = "Created",
                ActionDate = DateTime.UtcNow,
                Comments = "Initial request created."
            };


            await _processRepository.AddWorkflowActionAsync(initialAction);
            await _processRepository.SaveChangesAsync();

            var requesterEmail = "raihansss34@gmail.com";
            var supervisorEmail = "vanquish00vip@gmail.com";
            var mailData = new MailData
            {
                EmailToId = requesterEmail,
                EmailToName = "Raihan",
                EmailSubject = "Leave Request Submitted",
                EmailBody = $"Your leave request has been submitted and is awaiting approval."
            };
            await _emailService.SendMail(mailData);

            var mailDataSupervisor = new MailData
            {
                EmailToId = supervisorEmail,
                EmailToName = "Supervisor Name",
                EmailSubject = "New Leave Request for Approval",
                EmailBody = $"A new leave request has been submitted by {leaveRequestDto.EmployeeId}. Please review and approve."
            };
            await _emailService.SendMail(mailDataSupervisor);

            return true;

        }

        public async Task<IEnumerable<LeaveReqDto>> GetLeaveRequestsByEmployeeIdAsync(int employeeId)
        {
            var leaveRequests = await _employeeRepository.GetLeaveRequestsByEmployeeIdAsync(employeeId);

            return leaveRequests.Select(lr => new LeaveReqDto
            {
                EmployeeId = lr.EmployeeId,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType,
                Reason = lr.Reason
            }).ToList();
        }


        public async Task<string> UpdateEmployeeAsync(Employees employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return "Data employee berhasil di update";
        }

        
        public async Task<string> DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return "Data employee berhasil di hapus";
        }

        public async Task<string> DeactivateEmployeeAsync(int id, string reason)
        {
            try
            {
                await _employeeRepository.DeactivateEmployeeAsync(id, reason);
                return "Employee deactivated successfully";
            }
            catch (KeyNotFoundException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
