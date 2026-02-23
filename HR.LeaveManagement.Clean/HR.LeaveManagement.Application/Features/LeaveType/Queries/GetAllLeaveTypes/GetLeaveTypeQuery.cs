using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

//public class GetLeaveTypeQuery: IRequest<List<LeaveTypeDto>>
//{}

public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;
