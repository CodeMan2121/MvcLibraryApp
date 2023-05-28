using MvcLibraryApp.Contexts;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Repositories
{
    public class BookRepository
    {
        public void Add(Book book)
        {
            using (var context = new LibraryDbContext() )
            {
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Book> GetList()
        {
            using(var context = new LibraryDbContext())
            {
                return context.Set<Book>().ToList();
            }
        }
        public Book Get(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Book>().SingleOrDefault(b => b.Id == id);
            }
        }
    }
}
