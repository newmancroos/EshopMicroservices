using AutoMapper;
using HR.LeaveManagement.BalzorUI.Contracts;
using HR.LeaveManagement.BalzorUI.Models.LeaveTypes;
using HR.LeaveManagement.BalzorUI.Services.Base;

namespace HR.LeaveManagement.BalzorUI.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper   _mapper;
    public LeaveTypeService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
    {
        
        try
        {
            var leaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
            var response = _client.LeaveTypesPOSTAsync(leaveTypeCommand);

            return new Response<Guid>()
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {

            return CovertApiException<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteLeaveType(int id)
    {
        try
        { 
            await _client.LeaveRequestsDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {

            return CovertApiException<Guid>(ex);
        }
    }

    public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
    {
        var leaveType = await _client.LeaveTypesGETAsync(id);
        return _mapper.Map<LeaveTypeVM>(leaveType);

    }

    public async Task<List<LeaveTypeVM>> GetLeaveTypes()
    {
        var leaveTypes = await _client.LeaveTypesAllAsync();
        return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
    }

    public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
    {
        try
        {
            var updateLeaveTypeCommond = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
            await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommond);

            return new Response<Guid>()
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {

            return CovertApiException<Guid>(ex);
        }
    }
}
