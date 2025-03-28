using Domain.Entities.Website;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Website_setting_confi;

public class WebsiteSettingsConfiguration : IEntityTypeConfiguration<WebsiteSettings>
{
    public void Configure(EntityTypeBuilder<WebsiteSettings> builder)
    {
        builder.ToTable("WebsiteSettings");

        builder.HasKey(ws => ws.Id);

        builder.Property(ws => ws.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ws => ws.Value)
            .IsRequired();

        builder.Property(ws => ws.Description)
            .HasMaxLength(500);
    }
}