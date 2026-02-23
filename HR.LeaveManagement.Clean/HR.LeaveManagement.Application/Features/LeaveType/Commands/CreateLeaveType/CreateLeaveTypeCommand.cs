using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;


public class CreateLeaveTypeCommand:IRequest<int>
{
    public string Name { get; set; } = null!;
    public int DefaultDays { get; set; }
}
