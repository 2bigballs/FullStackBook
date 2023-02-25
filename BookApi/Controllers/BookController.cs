using Application.Configuration;
using Application.Helpers.Paths;
using Application.Helpers.Url;
using Application.Interfaces;
using Contract.BookDTOs;
using Contract.RatingDTOs;
using Contract.ReviewDTOs;
using Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookApi.Controllers
{
    [Route("api/books")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IRatingService _ratingService;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
      

        public BookController(
            IBookService bookService, 
            IRatingService ratingService, 
            IReviewService reviewService,
            IMapper mapper)
        {
            _bookService = bookService;
            _ratingService = ratingService;
            _reviewService = reviewService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? orderBy)
        {
            List<Book> books = await _bookService.GetBooks(orderBy);
            var booksDTO = _mapper.Map<IEnumerable<GetBooksDTO>>(books);
            return Ok(booksDTO);
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommended(string? genre)
        {
            List<Book> books = await _bookService.GetRecommendedBook(genre);
            var recommendedBooks = _mapper.Map<IEnumerable<GetBooksDTO>>(books);
            return Ok(recommendedBooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksDetails(int id)
        {
            var response = await _bookService.GetBookDetails(id);
            var bookDetails = _mapper.Map<GetBookDetailsDTO>(response.Value);
            var bookDetailsResponse = response.ConvertToNewType(bookDetails);
            return Response(bookDetailsResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBookDTO createBookDTO)
        {
            var book = _mapper.Map<Book>(createBookDTO);
            var response = await _bookService.Create(book, createBookDTO.Cover);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id, string key)
        {
            var response = await _bookService.Remove(id, key);
            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBookDTO updateBookDTO)
        {

            var updateBook = _mapper.Map<Book>(updateBookDTO);
            var response = await _bookService.Update(updateBook, updateBookDTO.Cover);
            return Response(response);
        }

        [HttpPost("{id}/rating")]
        public async Task<IActionResult> CreateRating(int id, CreateRateDTO createRateDto)
        {
            var rating = _mapper.From(createRateDto).AddParameters("bookId", id).AdaptToType<Rating>();
            var response = await _ratingService.Create(rating);
            return Response(response);
        }

        [HttpPost("{id}/review")]
        public async Task<IActionResult> CreateReview(int id, CreateReviewDTO createReviewDto)
        {
            var review = _mapper.From(createReviewDto).AddParameters("bookId", id).AdaptToType<Review>();
            var response = await _reviewService.Create(review);
            return Response(response);
        }
    }



}
