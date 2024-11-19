using BookManagementProject.DTOs;
using System.Reflection.Emit;

namespace BookManagementProject.Repo.GenreRepo
{
    public interface IGenreRepo
    {
        GenreDTO GetById(int id);
        void Update(GenreDTO generDto, int id);
        void Delete(int id);
        IEnumerable<GenreDTO> GetAllGenres();
        void Add(GenreDTO generDto);
    }
}
