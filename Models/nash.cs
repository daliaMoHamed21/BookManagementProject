namespace BookManagementProject.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Author> Author { get; set; }


    }
}
 