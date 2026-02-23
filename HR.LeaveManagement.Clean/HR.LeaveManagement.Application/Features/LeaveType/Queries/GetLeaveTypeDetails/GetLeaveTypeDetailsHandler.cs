using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        ArgumentNullException.ThrowIfNull(leaveTypeRepository, nameof(leaveTypeRepository));
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    

    public async Task<GetLeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(LeaveType), request.Id);

        //if (leaveTypeDetails == null)
        //{
        //    throw new NotFoundException(nameof(LeaveType), request.Id);
        //}
        var data = _mapper.Map<GetLeaveTypeDetailsDto>(leaveTypeDetails);

        return data;
    }
}
