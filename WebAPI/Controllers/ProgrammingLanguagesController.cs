using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(programmingLanguageGetByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }
    }
}
