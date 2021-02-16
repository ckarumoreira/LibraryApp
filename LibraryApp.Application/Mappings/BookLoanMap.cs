using AutoMapper;
using LibraryApp.Application.ViewModels;
using LibraryApp.Domain.Models;

namespace LibraryApp.Application.Mappings
{
    public class BookLoanMap : Profile
    {
        public BookLoanMap()
        {
            CreateMap<BookLoan, BookLoanViewModel>().ReverseMap();
        }
    }
}