namespace OnlineMenu.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using OnlineMenu.Data.Models;

	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(p => p.FirstName)
				.HasDefaultValue("FirstName");

			builder.Property(p => p.LastName)
				.HasDefaultValue("LastName");
		}
	}
}
