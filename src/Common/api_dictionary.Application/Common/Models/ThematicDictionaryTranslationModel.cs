using MediatR;
using System.Collections.Generic;

namespace api_dictionary.Application.Common.Models;
public class ThematicDictionaryTranslationModel : IRequest
{
    public List<ThematicDictionaryModel> ThematicDictionaries { get; set; }
    public TranslationModel Translation { get; set; }  
}
