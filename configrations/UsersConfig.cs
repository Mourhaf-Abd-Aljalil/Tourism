
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTourism.Entities;

namespace DataAccessLayer.configrations
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

                builder.HasKey(e => e.UserId).HasName("PK__Users");
                
                builder.Property(e => e.UserId).HasColumnName("User_Id");
                builder.Property(e => e.Email).HasMaxLength(100);
                builder.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");
                builder.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");
                builder.Property(e => e.Password).HasMaxLength(100);
                builder.Property(e => e.Phone).HasMaxLength(20);
                builder.Property(e => e.UserType).HasColumnName("User_Type");
           

        }
    }
}
