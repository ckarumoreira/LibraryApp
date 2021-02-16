using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.ViewModels;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;

namespace LibraryApp.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private IBookRepository _bookRepository;
        private IMapper _mapper;

        public BookAppService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void Create(BookViewModel book)
        {
            var entity = _mapper.Map<Book>(book);
            _bookRepository.Create(entity);
        }

        public void Delete(int bookId)
        {
            _bookRepository.Delete(bookId);
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            var result = _mapper.Map<BookViewModel[]>(_bookRepository.Get());
            return result;
        }

        public BookViewModel GetById(int bookId)
        {
            return _mapper.Map<BookViewModel>(_bookRepository.Get(b => b.Id == bookId).SingleOrDefault());
        }

        public void Update(BookViewModel book)
        {
            var entity = _mapper.Map<Book>(book);
            _bookRepository.Update(entity);
        }
    }
}