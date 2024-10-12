using AutoMapper;
using Lms.BusinessLogic.Dtos;
using Lms.Entity.Accounts;
using Lms.Entity.Books;
using Lms.Entity.Commons;

namespace Lms.BusinessLogic.Mappers;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreatUserDto, User>();
        CreateMap<CreatUserDto, UserDetail>();
        CreateMap<AddAuthorDto, Author>();
        CreateMap<AddBookDto, Book>();
        CreateMap<UploadedFileDto, UploadedFile>();

        CreateMap<Book, GetBookViewDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => string.Join(",", src.BookAuthors.Select(ba => ba.Author.FullName)))
            )
            .ForMember(
                dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.Value)
            )
            .ForMember(
                dest => dest.Url,
                opt => opt.MapFrom(x => x.UploadedFiles.FirstOrDefault().FileName)
            );
    }
}
