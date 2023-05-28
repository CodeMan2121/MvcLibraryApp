using MvcLibraryApp.Contexts;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Repositories
{
    public class EmployeeRepository
    {
        public void Add(Employee employee)
        {
            using (LibraryDbContext context = new())
            {
                context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Employee employee)
        {
            using (LibraryDbContext context = new())
            {
                context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Employee employee)
        {
            using (LibraryDbContext context = new())
            {
                context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Employee> GetList()
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Employee>().ToList();
            }
        }
        public Employee Get(int id)
        {
            using (LibraryDbContext context = new())
            {
                return context.Set<Employee>().SingleOrDefault(e => e.Id == id);
            }
        }
    }
}
