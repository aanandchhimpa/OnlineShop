using Domain.Entities.DynamicFilters;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Filters_confi
{

    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
        {

            builder.HasKey(f => f.UserId); 

        
        }
    }
}
