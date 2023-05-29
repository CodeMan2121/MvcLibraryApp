using MvcLibraryApp.Contexts;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Repositories
{
    public class StudentRepository
    {
        public void Add(Student student)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Student student)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Student Get(int id)
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Student>().SingleOrDefault(s => s.Id == id);
            }
        }
        public List<Student> GetList()
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Student>().ToList();
            }
        }
    }
}
