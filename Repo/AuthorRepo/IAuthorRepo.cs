using BookManagementProject.DTOs;

namespace BookManagementProject.Repo.AuthorRepo
{
    public interface IAuthorRepo
    {
        AuthorDTO GetById(int id);
        void UpdateAuthor(AuthorDTO authorDto,int id );
        void DeleteAuthor(int id);
        IEnumerable<AuthorDTO> gettall();
        void AddAllAuthor (AuthorDTO authorDto);

    }
}
