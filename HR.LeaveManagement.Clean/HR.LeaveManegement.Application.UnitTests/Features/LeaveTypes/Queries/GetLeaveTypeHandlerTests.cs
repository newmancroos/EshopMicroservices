using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManegement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManegement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypeHandlerTests
{

    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveTypeHandler>> _mockAppLogger;
    public GetLeaveTypeHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetLeaveTypeHandler>>();

    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
        var result = await handler.Handle(new GetLeaveTypeQuery(), CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
        //Assert.IsType<List<LeaveTypeDto>>(result);
        //Assert.Equal(3, result.Count);
    }

}