using Microsoft.AspNetCore.Http;

namespace Contract.BookDTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Cover { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
