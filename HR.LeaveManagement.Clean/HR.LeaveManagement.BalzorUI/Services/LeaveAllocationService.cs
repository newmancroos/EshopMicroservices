using HR.LeaveManagement.BalzorUI.Contracts;
using HR.LeaveManagement.BalzorUI.Services.Base;

namespace HR.LeaveManagement.BalzorUI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(IClient client) : base(client)
    {

    }
}
