using BookManagementProject.DTOs;
using BookManagementProject.Models;

namespace BookManagementProject.Repo.BookRepo
{
    public interface IBookRepo
    {
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);

        void AddedBook(BookDTO bookDto);
        void AddBookOnly(BookDTO bookDto);

        void  UpdateBook(BookDTO bookDto,int id);

        void DeleteBook(int id);

         



    }
}
