using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile:Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<Domain.LeaveType, GetLeaveTypeDetailsDto>().ReverseMap();
        CreateMap<Domain.LeaveType, CreateLeaveTypeCommand>().ReverseMap();
        CreateMap<Domain.LeaveType, UpdateLeaveTypeCommand>().ReverseMap();

    }
}