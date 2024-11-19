using BookManagementProject.Data;
using BookManagementProject.DTOs;
using BookManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementProject.Repo.BookRepo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookOnly(BookDTO bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                Authors = _context.Authors.Where(x => bookDto.AuthorIds.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x => bookDto.GenreIds.Contains(x.Id)).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddedBook(BookDTO bookDto)
        {
            var u = new Book                            
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                Genres = bookDto.Genres.Select(x => new Genre
                {
                    Name = x.Name,

                }).ToList(),
                Authors = bookDto.Authors.Select(x => new Author
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,

                }).ToList()
            };    
            _context.Books.Add(u);
            _context.SaveChanges();
            
        }

        public void DeleteBook(int id)
        {
            var u = _context.Books.FirstOrDefault(x=> x.Id == id);
            _context.Books.Remove(u);
            _context.SaveChanges();
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var u = _context.Books
                .Include(x=>x.Authors)
                .Include(x=>x.Genres)
                .Select(x=>new BookDTO
                {
                    Title=x.Title,
                    PublishedYear=x.PublishedYear,
                    Genres=x.Genres.Select(y=>new GenreDTO
                    {
                        Name = y.Name,


                    }).ToList(),
                    Authors=x.Authors.Select(o=>new AuthorDTO {
                    Email=o.Email,
                    Phone=o.Phone,

                    Name=o.Name,
                    
                    }).ToList(),
                    

                }
                
                ).ToList();

                return u;   
        }

        public BookDTO GetBookById(int id)
        {
            var book=_context.Books.Include(x=>x.Authors)
                .Include(u=>u.Genres)
                .FirstOrDefault(x=>x.Id==id);
            return new BookDTO
            {
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                Genres = book.Genres.Select(x => new GenreDTO
                {
                    Name = x.Name,
                }).ToList(),
                Authors = book.Authors.Select(o =>new AuthorDTO{
                    Name=o.Name,
                    Phone=o.Phone,
                    Email=o.Email,
                }).ToList(),
            };
           
        }

        public void UpdateBook(BookDTO bookDto, int id)
        {
            var book = _context.Books.Include(x => x.Authors)
                .Include(u => u.Genres)
                .FirstOrDefault(x => x.Id == id);
            book.Title = bookDto.Title;
            book.PublishedYear = bookDto.PublishedYear;
            book.Authors = bookDto.Authors.Select(o => new Author
            {
                Email=o.Email,
                Name=o.Name,
                Phone=o.Phone,
            }).ToList();
            book.Genres = bookDto.Genres.Select(o => new Genre
            {
                Name = o.Name,
            }).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
