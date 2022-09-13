using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgramingLanguageCommand : IRequest<CreatedProgramingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateProgramingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(
                    request.Name);

                Domain.Entities.ProgrammingLanguage mappedProgrammingLanguageEntity = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                Domain.Entities.ProgrammingLanguage createdProgrammingLanguageEntity =
                    await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguageEntity);
                CreatedProgramingLanguageDto createdProgramingLanguageDto = _mapper.Map<CreatedProgramingLanguageDto>(createdProgrammingLanguageEntity);
                return createdProgramingLanguageDto;
            }
        }

    }
}
