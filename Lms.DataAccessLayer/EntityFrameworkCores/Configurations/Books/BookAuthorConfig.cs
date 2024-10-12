using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Books
{
    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => new { x.BookId, x.AuthorId });

            builder.ToTable("BookAuthors", "app");
        }
    }
}
