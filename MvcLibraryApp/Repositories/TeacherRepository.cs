using MvcLibraryApp.Contexts;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Repositories
{
    public class TeacherRepository
    {
        public void Add(Teacher teacher)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Teacher teacher)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Teacher teacher)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Teacher Get(int id)
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Teacher>().SingleOrDefault(s => s.Id == id);
            }
        }
        public List<Teacher> GetList()
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Teacher>().ToList();
            }
        }
    }
}
