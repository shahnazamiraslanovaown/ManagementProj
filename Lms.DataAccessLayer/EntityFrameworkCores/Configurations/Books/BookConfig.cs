using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Books;

public class BookConfig : EditedBaseEntityConfig<Book>
{
    
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(24);

        builder.Property(x => x.Price)
            .HasColumnName("Price");

        builder.Property(x => x.Description)
            .HasColumnType("nText")
            .IsRequired(false);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.BookAuthors)
            .WithOne(x => x.Book)
            .HasForeignKey(x => x.BookId);


        builder.HasMany(x => x.UploadedFiles)
            .WithOne()
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Books", "app",x => x.HasCheckConstraint("CK_Book_Price", "[Price] >= 0"));
    }
}
