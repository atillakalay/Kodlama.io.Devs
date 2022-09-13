using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class
            GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery,
                ProgrammingLanguageGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository,
                IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request,
                CancellationToken cancellationToken)
            {
                Domain.Entities.ProgrammingLanguage? programmingLanguage =
                    await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto =
                    _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
                return programmingLanguageGetByIdDto;

            }
        }
    }
}
