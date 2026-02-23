using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);


        builder.HasData(
            new LeaveType 
            { 
                Id=1,
                Name="Vacation",
                DefaultDays = 10,
                DateCreated = DateTime.Parse("02/20/2026"),   //This may be a problem in database migration. In that case use hardcoded date
                DateModified = DateTime.Parse("02/20/2026")
            }
        );

    }
}
