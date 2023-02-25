namespace Contract.BookDTOs
{
    public class GetBookDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public IEnumerable<BookDetailsReviewDTO> Reviews { get; set; }
    }
    public class BookDetailsReviewDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
    }
}
