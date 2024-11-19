namespace BookManagementProject.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Book> Books { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public Nationality Nationality { get; set; }
       public int NationalityId { get; set; }
    }
}
