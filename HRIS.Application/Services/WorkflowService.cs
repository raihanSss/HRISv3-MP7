using HRIS.Domain;
using HRIS.Domain.Interfaces;
using HRIS.Domain.Models;
using HRIS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IEmailService _emailService;
        public WorkflowService(IProcessRepository processRepository, IEmailService emailService)
        {
            _processRepository = processRepository;
            _emailService = emailService;
        }

        public async Task<bool> ProcessLeaveRequestAsync(int leaveRequestId, string userId, string comments, string status)
        {
            
            var process = await _processRepository.GetProcessByLeaveRequestIdAsync(leaveRequestId);

            if (process == null)
            {
                return false; 
            }

            var action = new WorkflowActions
            {
                ProcessId = process.ProcessId,
                StepId = process.CurrentStepId,
                ActorId = userId,
                Action = status.Equals("approve", StringComparison.OrdinalIgnoreCase) ? "Approve" : "Reject",
                ActionDate = DateTime.UtcNow,
                Comments = comments
            };

            await _processRepository.AddWorkflowActionAsync(action);

            string nextRoleEmail = "vanquish00vip@gmail.com";

            if (status.Equals("approve", StringComparison.OrdinalIgnoreCase))
            {
                var nextStep = await _processRepository.GetNextStepAsync(process.CurrentStepId, "Approve");

                if (nextStep != null)
                {
                    process.CurrentStepId = nextStep.StepId;
                    process.Status = "In Progress";
                }
                else
                {
                    process.CurrentStepId = 4;
                    process.Status = "Approved";
                }
            
            var requesterEmail = "raihansss34@gmail.com";
            var mailData = new MailData
            {
                EmailToId = requesterEmail,
                EmailToName = "Raihan",
                EmailSubject = "Leave Request Approved",
                EmailBody = "Your leave request has been approved."
            };
            await _emailService.SendMail(mailData);

            if (!string.IsNullOrEmpty(nextRoleEmail))
            {
                var mailDataNextRole = new MailData
                {
                    EmailToId = nextRoleEmail,
                    EmailToName = "HR Manager",
                    EmailSubject = "New Leave Request Approval Required",
                    EmailBody = "A leave request has been approved and now requires your action."
                };
                await _emailService.SendMail(mailDataNextRole);
            }
        }
            else if (status.Equals("reject", StringComparison.OrdinalIgnoreCase))
            {
                process.CurrentStepId = 5;
                process.Status = "Rejected";

                
                var requesterEmail = "raihansss34@gmail.com"; 
                var mailData = new MailData
                {
                    EmailToId = requesterEmail,
                    EmailToName = "Raihan",
                    EmailSubject = "Leave Request Rejected",
                    EmailBody = "Your leave request has been rejected."
                };
                await _emailService.SendMail(mailData);
            }
            await _processRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WorkflowActions>> GetWorkflowActionsAsync(int leaveRequestId)
        {
            return await _processRepository.GetWorkflowActionsByLeaveRequestIdAsync(leaveRequestId);
        }
    }
}
