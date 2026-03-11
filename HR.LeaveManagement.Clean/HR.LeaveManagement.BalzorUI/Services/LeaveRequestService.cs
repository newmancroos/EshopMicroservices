using HR.LeaveManagement.BalzorUI.Contracts;
using HR.LeaveManagement.BalzorUI.Services.Base;

namespace HR.LeaveManagement.BalzorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client) : base(client)
    {

    }
}