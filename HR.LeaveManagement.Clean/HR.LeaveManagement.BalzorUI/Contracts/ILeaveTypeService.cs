using HR.LeaveManagement.BalzorUI.Models.LeaveTypes;
using HR.LeaveManagement.BalzorUI.Services.Base;
namespace HR.LeaveManagement.BalzorUI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypes();
    Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
    Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
    Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
    Task<Response<Guid>> DeleteLeaveType(int id);
}
