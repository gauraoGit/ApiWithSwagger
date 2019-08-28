using AutoMapper;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Library.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    { 
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BooksController(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
       
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(
        Guid authorId )
        {
            if (!await _authorRepository.AuthorExistsAsync(authorId))
            {
                return NotFound();
            }

            var booksFromRepo = await _bookRepository.GetBooksAsync(authorId); 
            return Ok(_mapper.Map<IEnumerable<Book>>(booksFromRepo));
        }
        /// <summary>
        /// Get a book  by Id for specific author
        /// </summary>
        /// <param name="authorId">Id of an author</param>
        /// <param name="bookId">Id of a book</param>
        /// <returns>ActionResults of Book</returns>
        /// <response code="200">Returns requested book</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBook(
            Guid authorId,
            Guid bookId)
        {
            if (! await _authorRepository.AuthorExistsAsync(authorId))
            {
                return NotFound();
            }

            var bookFromRepo = await _bookRepository.GetBookAsync(authorId, bookId);
            if (bookFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Book>(bookFromRepo));
        }


       
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPost()]
        public async Task<ActionResult<Book>> CreateBook(
            Guid authorId,
            [FromBody] BookForCreation bookForCreation)
        {
            if (!await _authorRepository.AuthorExistsAsync(authorId))
            {
                return NotFound();
            }

            var bookToAdd = _mapper.Map<Entities.Book>(bookForCreation);
            _bookRepository.AddBook(bookToAdd);
            await _bookRepository.SaveChangesAsync();

            return CreatedAtRoute(
                "GetBook",
                new { authorId, bookId = bookToAdd.Id },
                _mapper.Map<Book>(bookToAdd));
        }
    }
}
