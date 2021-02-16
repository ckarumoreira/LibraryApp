using System.Linq;
using AutoMapper;
using LibraryApp.Application.ViewModels;
using LibraryApp.Domain.Models;

namespace LibraryApp.Application.Mappings
{
    public class BookMap : Profile
    {
        public BookMap()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.IsAvailable, x => x.MapFrom(b => !b.Loans.Any(l => l.Returned == null)))
            .ReverseMap()
                .ForMember(x => x.Loans, x => x.Ignore());
        }
    }
}