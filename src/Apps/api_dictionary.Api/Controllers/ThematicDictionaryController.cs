using api_dictionary.Api.Controllers;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.ThematicDictionaries.Commands.GetThematicDictionary;
using api_dictionary.Application.ThematicDictionaries.Queries;
using api_dictionary.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dictionary_api.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThematicDictionaryController : BaseApiController
{
    [HttpGet]
    public async Task<ServiceResult<List<ThematicDictionaryModel>>> Get()
    {
        return await Mediator.Send(new GetThematicDictionaryCommand());
    }

    /// <summary>
    /// Get List of Translations by ThematicDictionaryId 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ServiceResult<List<ListOfTranslationByThematicDictionary>>> Get(int thematicDictionaryId)
    {
        return await Mediator.Send(new GetThematicDictionaryQuery { ThematicDictionaryId = thematicDictionaryId });
    }
}
