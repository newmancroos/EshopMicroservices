using AutoMapper;
using HR.LeaveManagement.BalzorUI.Models.LeaveTypes;
using HR.LeaveManagement.BalzorUI.Services.Base;

namespace HR.LeaveManagement.BalzorUI.MappingProfile;

public class MappingConfig:Profile
{
    public MappingConfig()
    {
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
    }
}
