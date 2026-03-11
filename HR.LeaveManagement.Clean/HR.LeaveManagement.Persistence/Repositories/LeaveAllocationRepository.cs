using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext hrDatabaseContext) : base(hrDatabaseContext)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _hrDatabaseContext.AddRangeAsync(allocations);
        await _hrDatabaseContext.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _hrDatabaseContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId 
                                        && q.LeaveTypeId == leaveTypeId && q.Period==period);
    }

    public async Task<LeaveAllocation> GetLeaveAllocationsWithDetails(int id)
    {
        return await _hrDatabaseContext.LeaveAllocations.Where(q => q.Id == id)
                            .Include(q => q.LeaveType)
                            .FirstOrDefaultAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _hrDatabaseContext.LeaveAllocations
                    .Include(q => q.LeaveType)
                    .ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        return await _hrDatabaseContext.LeaveAllocations.Where(q => q.EmployeeId == userId)
             .Include(q => q.LeaveType)
             .ToListAsync();
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int LeaveTypeId)
    {
        return await _hrDatabaseContext.LeaveAllocations
            .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == LeaveTypeId);
    }
}