using Microsoft.AspNetCore.Mvc;
using MvcLibraryApp.Models.Entities;
using MvcLibraryApp.Repositories;
using MvcLibraryApp.ViewModels.Employees;

namespace MvcLibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeesController()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetList();
            return View(employees);
        }

        [HttpGet("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromForm] AddEmployeeViewModel request)
        {
            Employee employee = new()
            {
                Name = request.Name,
                LastName = request.LastName,
                Age = request.Age
            };
            _employeeRepository.Add(employee);
            return RedirectToAction("Index");
        }


        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var employee = _employeeRepository.Get(id);
            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }


        [HttpGet("[action]/{id}")]//Güncelleme sayfasını getirir.
        public ActionResult Update([FromRoute] int id)
        {
            var data = _employeeRepository.Get(id);
            UpdateEmployeeViewModel model = new()
            {
                Id = id,
                Name = data.Name,
                LastName = data.LastName,
                Age = data.Age
            };
            return View(model);
        }

        [HttpPost("[action]/{id}")]//Güncelleme işlemini yapar.
        public ActionResult Update([FromForm]  UpdateEmployeeViewModel request)
        {
            Employee employee = new()
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Age = request.Age
            };
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }
    }
}
