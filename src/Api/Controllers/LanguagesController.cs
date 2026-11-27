using Api.Dtos;
using Application.Common.Interfaces.Queries.Languages;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("languages")]
[ApiController]
public class LanguagesController(ILanguageQueries languageQueries) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LanguageDto>>> GetLanguages(CancellationToken cancellationToken)
    {
        var languages = await languageQueries.GetAll(cancellationToken);
        return Ok(languages.Select(LanguageDto.FromDomainModel));
    }
}