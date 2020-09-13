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
            builder.HasOne(x => x.Post);
            builder.HasOne(x => x.User);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PublishDateTime).IsRequired();
        }
    }
}