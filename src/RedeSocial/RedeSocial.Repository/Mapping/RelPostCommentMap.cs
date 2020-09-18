using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial.Domain.Post;

namespace RedeSocial.Repository.Mapping
{
    public class RelPostCommentMap : IEntityTypeConfiguration<RelPostComment>
    {
        public void Configure(EntityTypeBuilder<RelPostComment> builder)
        {
            builder.ToTable("RelPostComment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IdPost).IsRequired();
            builder.Property(x => x.IdComment).IsRequired();
        }
    }
}