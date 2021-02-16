using AutoMapper;
using LibraryApp.Application.ViewModels;
using LibraryApp.Domain.Models;

namespace LibraryApp.Application.Mappings
{
    public class BookMap : Profile
    {
        public BookMap()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}