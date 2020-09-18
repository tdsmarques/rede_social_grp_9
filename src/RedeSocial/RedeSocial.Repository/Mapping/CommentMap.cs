using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial.Domain.Post;

namespace RedeSocial.Repository.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserImageUrl).IsRequired();
            builder.Property(x => x.userName).IsRequired();
            builder.Property(x => x.Message).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PublishDateTime).IsRequired();
        }
    }
}