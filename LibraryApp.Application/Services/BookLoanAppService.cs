using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.ViewModels;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class BookLoanAppService : IBookLoanAppService
    {
        private IBookRepository _bookRepository;
        private IMapper _mapper;

        public BookLoanAppService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void BorrowBook(int bookId, string user)
        {
            _bookRepository.Borrow(bookId, user);
        }

        public IEnumerable<BookLoanViewModel> GetLoans(int bookId)
        {
            var result = _bookRepository.Get(b => b.Id == bookId).SingleOrDefault();
            return _mapper.Map<BookLoanViewModel[]>(result.Loans);
        }

        public void ReturnBook(int bookId, string user)
        {
            _bookRepository.Return(bookId, user);
        }
    }
}