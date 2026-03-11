using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTest
{
    private readonly HrDatabaseContext _hrDatabaseContext;
    public HrDatabaseContextTest()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _hrDatabaseContext = new HrDatabaseContext(dbOptions);
    }

    [Fact]
    public async Task Save_SetDateCreatedValue()
    {
        //Arrange
        var leaveType = new Domain.LeaveType
        {
            Id = 1,
            Name = "Test Leave Type",
            DefaultDays = 10
        };

        //Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        //Assert

         leaveType.DateCreated.ShouldNotBeNull();
    }

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        var leaveType = new Domain.LeaveType
        {
            Id = 1,
            Name = "Test Leave Type",
            DefaultDays = 10
        };

        //Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        //Assert

        leaveType.DateModified.ShouldNotBeNull();
    }
}
