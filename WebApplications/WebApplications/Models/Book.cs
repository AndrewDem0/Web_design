namespace WebApplications.Models
{
    public class Book
    {
        public int Id { get; set; }
        //назва книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // ціна
        public int Price { get; set; }
    }
}
