namespace Contract.BookDTOs
{
    public class GetBooksDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Genre { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public int ReviewsNumber { get; set; }
    }
}
