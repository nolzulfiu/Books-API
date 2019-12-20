using System.Data.Entity;

namespace Books.Models
{
    public class BooksContext : DbContext
    {
    
        public BooksContext() : base("name=BooksContext")
        {
        }

        public System.Data.Entity.DbSet<Books.Models.Book> Books { get; set; }
    }
}
