using System.Collections.Generic;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Web.Api.Controllers
{
    [Route("book/{bookId}/loan")]
    [ApiController]
    public class BookLoansController : ControllerBase
    {
        private IBookLoanAppService _bookLoanService;

        public BookLoansController(IBookLoanAppService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }

        // PUT api/<BookLoansController>/5
        [HttpPost("{user}")]
        public void Borrow(int bookId, string user)
        {
            _bookLoanService.BorrowBook(bookId, user);
        }

        // GET: api/<BookLoansController>
        [HttpGet]
        public IEnumerable<BookLoanViewModel> GetAllLoans(int bookId)
        {
            return _bookLoanService.GetLoans(bookId);
        }

        // POST api/<BookLoansController>
        [HttpPut("{user}")]
        public void Return(int bookId, string user)
        {
            _bookLoanService.ReturnBook(bookId, user);
        }
    }
}