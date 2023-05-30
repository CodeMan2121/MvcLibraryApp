using MvcLibraryApp.Contexts;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Repositories
{
    public class CourseRepository
    {
        public void Add(Course course)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Course course)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Updated(Course course)
        {
            using (var context = new LibraryDbContext())
            {
                context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Course Get(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Course>().SingleOrDefault(c => c.Id == id);
            }
        }
        public List<Course> GetList()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Set<Course>().ToList();
            }
        }
    }
}
