namespace BookManagementProject.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int number { get; set; }
        public DateTime endOfthecard { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
