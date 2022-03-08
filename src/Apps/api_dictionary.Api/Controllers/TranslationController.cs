using api_dictionary.Application.Common.Models;
using api_dictionary.Application.ThematicDictionaries.Commands.CreateThematicDictionary;
using api_dictionary.Application.ThematicDictionaryTranslations.Command;
using api_dictionary.Application.ThematicDictionaryTranslations.Commands;
using api_dictionary.Application.Translations.Commands;
using api_dictionary.Application.Translations.Queries.GetAllTranslations;
using api_dictionary.Application.Translations.Queries.GetTranslationById;
using Microsoft.AspNetCore.Mvc;
using api_dictionary.Api.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace api_dictionary.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TranslationController : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<ServiceResult<CreateThematricDictionaryTranslationResponse>>> Create(ThematicDictionaryTranslationModel request)
    {
        List<int> thematicDictionaryIds = await Mediator.Send(new CreateThematicDictionaryCommand { ThematicDictionaries = request.ThematicDictionaries });
        int translationId = await Mediator.Send(new CreateTranslationCommand { Translation = request.Translation});
        foreach(var thematicDictionaryId in thematicDictionaryIds)
        {
            await Mediator.Send(new CreateThematicDictionaryTranslationsCommand { ThematicDictionaryId = thematicDictionaryId, TranslationId = translationId });
        }

        return Ok(ServiceResult.Success(new CreateThematricDictionaryTranslationResponse
        {
            ThematicDictionaryId = thematicDictionaryIds,
            TranslationId = translationId
        }));
    }

    [HttpGet]
    public async Task<ServiceResult<List<GetAllTransLationQueryResponse>>> Get()
    {
        return await Mediator.Send(new GetAllTranslationQuery());
    }

    [HttpGet("{id}")]
    public async Task<ServiceResult<GetTranslationByIdQueryResponse>> Get(int translationId)
    {
        return await Mediator.Send(new GetTranslationByIdQuery { TranslationId = translationId });
    }
}
