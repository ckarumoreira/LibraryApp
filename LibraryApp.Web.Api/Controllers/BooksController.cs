using System.Collections.Generic;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Web.Api.Controllers
{
    [Route("book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookAppService _bookService;

        public BooksController(IBookAppService bookService)
        {
            _bookService = bookService;
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookViewModel> Get()
        {
            return _bookService.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookViewModel Get(int id)
        {
            return _bookService.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post(BookViewModel book)
        {
            _bookService.Create(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, BookViewModel book)
        {
            book.Id = id;
            _bookService.Update(book);
        }
    }
}