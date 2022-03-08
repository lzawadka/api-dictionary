using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using MediatR;

namespace api_dictionary.Application.ThematicDictionaries.Queries;
public class GetThematicDictionaryQueryHandler : IRequestHandler<GetThematicDictionaryQuery, ServiceResult<List<ListOfTranslationByThematicDictionary>>>
{
    private readonly IApplicationDbContext _context;

    public GetThematicDictionaryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ServiceResult<List<ListOfTranslationByThematicDictionary>>> Handle(GetThematicDictionaryQuery request, CancellationToken cancellationToken)
    {
        List<ListOfTranslationByThematicDictionary> listOfTranslationByDictionaryThematic = _context
            .ThematicDictionaryTranslations
            .Where(o => o.ThematicDictionaryId == request.ThematicDictionaryId)
            .Select(o => new ListOfTranslationByThematicDictionary
            {
                    ThematicDictionaryId = o.ThematicDictionaryId,
                    ThematicDictionaryName = o.ThematicDictionary.ThematicDictionaryName,
                    TranslationId = o.TranslationId,
                    TargetLanguage = o.Translation.TargetLanguage,
                    OriginLanguage = o.Translation.OriginLanguage,
                    TargetLanguageWord = o.Translation.TargetLanguageWord,
                    OriginLanguageWord = o.Translation.OriginLanguageWord,
                    CreatedAt = o.Translation.CreateDate
            })
            .ToList();

        return Task.FromResult(ServiceResult.Success(listOfTranslationByDictionaryThematic));
    }
}
