using Microsoft.AspNetCore.Mvc;
using MvcLibraryApp.Models.Entities;
using MvcLibraryApp.Repositories;
using MvcLibraryApp.ViewModels.Books;

namespace MvcLibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BooksController()
        {
            _bookRepository = new BookRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
           var books= _bookRepository.GetList();
            return View(books);
        }

        [HttpGet("[action]")]//Add sayfasını getirir.
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]//Kaydetme işlemini yapar.
        public IActionResult Add([FromForm] AddBookViewModel request)
        {
            Book book = new()
            {
                Name = request.Name,
                Author = request.Author,
                ReleaseDate = request.ReleaseDate
            };
            _bookRepository.Add(book);
            return RedirectToAction("Index");
            
        }
        [Route("delete/{Id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var book = _bookRepository.Get(id);
            _bookRepository.Delete(book);
            return RedirectToAction("Index");
        }

        [HttpGet("[action]/{id}")]
        public ActionResult Update([FromRoute] int id)
        {
            var data = _bookRepository.Get(id);
            UpdateBookViewModel model = new() {
            Id= id,
            Author = data.Author,
            ReleaseDate = data.ReleaseDate,
            Name = data.Name
            };
            return View(model);
        }


        [HttpPost("[action]/{id}")]
        public ActionResult Update([FromForm] UpdateBookViewModel viewModel)
        {
            Book book = new Book()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ReleaseDate = viewModel.ReleaseDate,
                Author = viewModel.Author,
                
            };
            _bookRepository.Update(book);
            return RedirectToAction("Index");
        }
    }
}
