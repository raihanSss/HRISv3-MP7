using HRIS.Domain.Interfaces;
using HRIS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Repository
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly hrisDbContext _context;

        public ProcessRepository(hrisDbContext context)
        {
            _context = context;
        }

        public async Task<Process> GetProcessByLeaveRequestIdAsync(int leaveRequestId)
        {
            return await _context.Processes
        .Include(p => p.LeaveRequest)  // Pastikan LeaveRequest di-include jika diperlukan
        .FirstOrDefaultAsync(p => p.LeaveRequestId == leaveRequestId);
        }

        public async Task AddProcessAsync(Process process)
        {
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();
        }

        public async Task AddWorkflowActionAsync(WorkflowActions action)
        {
            _context.WorkflowActions.Add(action);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<WorkflowSequences?> GetNextStepAsync(int currentStepId, string conditionType)
        {
            return await _context.NextStepRules
            .Where(nsr => nsr.CurrentStepId == currentStepId && nsr.ConditionType == conditionType)
            .Select(nsr => nsr.NextStep) 
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WorkflowActions>> GetWorkflowActionsByLeaveRequestIdAsync(int leaveRequestId)
        {
            return await _context.WorkflowActions
                .Where(wa => wa.Process.LeaveRequestId == leaveRequestId)
                .ToListAsync();
        }
    }
}
