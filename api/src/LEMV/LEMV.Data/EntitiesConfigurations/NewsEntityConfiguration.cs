using LEMV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LEMV.Data.EntitiesConfigurations
{
    public class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(News));
        }
    }
}
