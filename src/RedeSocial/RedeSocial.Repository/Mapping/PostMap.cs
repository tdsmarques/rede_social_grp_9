using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedeSocial.Repository.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Domain.Post.Post>
    {
        public void Configure(EntityTypeBuilder<Domain.Post.Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.UserImageUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.userName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasMaxLength(150);
            builder.Property(x => x.PublishDateTime).IsRequired();
        }
    }
}