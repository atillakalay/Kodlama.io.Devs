using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Domain.Entities.ProgrammingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgramingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}
