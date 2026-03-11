using HR.LeaveManagement.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //var hasher = new PasswordHasher<ApplicationUser>();

        const string adminId = "8e445865-a24d-4543-a6c6-9443d048cdb9";
        const string userId = "9e224968-33e4-4652-b7b7-8574d048cdb9";
        builder.HasData(
             new ApplicationUser
             {
                 Id = adminId,
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Admin",
                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = "AQAAAAIAAYagAAAAEPX5k14PZ3qf3ULk4Vb0k9k4t2oBqjJm9v+oH3Z3NQX8k2f8XkqT2C1y6+3lJ4b0iQ==", //hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true,
                 SecurityStamp = "c0e9b1b9-3f6f-4f0b-9d5e-3a2f1c0a1b2c",
                 ConcurrencyStamp = "b7d9c3c2-6a1d-4b24-8a34-6a2d9e1f4b77"
             },
             new ApplicationUser
             {
                 Id = userId,
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "User",
                 UserName = "user@localhost.com",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = "AQAAAAIAAYagAAAAEPX5k14PZ3qf3ULk4Vb0k9k4t2oBqjJm9v+oH3Z3NQX8k2f8XkqT2C1y6+3lJ4b0iQ==", //hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true,
                 SecurityStamp = "a1f2e3d4-c5b6-47a8-9c0d-1e2f3a4b5c6d",
                 ConcurrencyStamp = "5f2a1d3c-7b9e-4c3a-8d2f-1a3b5c7d9e0f"
             }
        );
    }
}
