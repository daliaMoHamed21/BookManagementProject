using System.ComponentModel.DataAnnotations;

namespace BookManagementProject.DTOs
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }


        public DateTime PublishedYear { get; set; }

        //ADD ,Update
        public List<int> GenreIds { get; set; }

        public List<int> AuthorIds { get; set; }
       


        //GET ALL
        //public List<string>? Genres { get; set; } 
        //public List<string>?Authors { get; set; }
        public List<GenreDTO>? Genres { get; set; } 
        public List<AuthorDTO>?Authors { get; set; }

       




    }
   

    }


