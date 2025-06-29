using EFCoreSimpleExample.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSimpleExample.Application.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("BookID");
        builder.HasMany(i => i.Pages)
            .WithOne(i => i.Book);
    }
}
