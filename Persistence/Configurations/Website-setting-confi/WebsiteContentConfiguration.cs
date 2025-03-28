using Domain.Entities.Website;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Website_setting_confi;

public class WebsiteContentConfiguration : IEntityTypeConfiguration<WebsiteContent>
{
    public void Configure(EntityTypeBuilder<WebsiteContent> builder)
    {
        builder.ToTable("WebsiteContents");

        builder.HasKey(wc => wc.Id);

        builder.Property(wc => wc.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(wc => wc.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(wc => wc.Content)
            .IsRequired();

        builder.Property(wc => wc.MetaDescription)
            .HasMaxLength(300);

        builder.Property(wc => wc.MetaKeywords)
            .HasMaxLength(500);

        builder.Property(wc => wc.PageType)
            .IsRequired()
            .HasMaxLength(50);
    }
}