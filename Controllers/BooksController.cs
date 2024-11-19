using BookManagementProject.DTOs;
using BookManagementProject.Repo.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo 
            _bookRepo;
        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
            
        }
        [HttpPost]

        public IActionResult AddBook(BookDTO bookDTO) {

            if (ModelState.IsValid)
            {
                _bookRepo.AddBookOnly(bookDTO);
                return Created();
            }
            return BadRequest(); 

        }
        [HttpPost("Add book")]
        public IActionResult PostBookwithAuthorandGenre(BookDTO dto)
        {
            _bookRepo.AddedBook(dto);
            return Created();

        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) {
           var book= _bookRepo.GetBookById(id);
            if(book==null)
            {
                return NotFound("The Book not found");
            }
            return Ok(book);
        }
        [HttpGet]
        public IActionResult GetAllBooks() {
           var book= _bookRepo.GetAllBooks();
            if(book==null)
            {
                return NotFound("No Books");
            }
            return Ok(book);
        }
        [HttpPut]
        public IActionResult UpdateBook(BookDTO bookDTO,int id) {
            _bookRepo.UpdateBook(bookDTO,id);
            return Accepted("Update");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _bookRepo.DeleteBook(id);
            if(id==null)
            {
                return NotFound("Plz Enter Id Or valid Id");
            }
            return NoContent();
        }

    }
}
