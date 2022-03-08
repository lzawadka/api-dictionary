using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_dictionary.Domain.Entities;

namespace api_dictionary.Application.ThematicDictionaries.Queries;
public class ListOfTranslationByThematicDictionary
{
    public int ThematicDictionaryId { get; set; }
    public string ThematicDictionaryName { get; set; }
    public int TranslationId { get; set; }
    public string OriginLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string OriginLanguageWord { get; set; }
    public string TargetLanguageWord { get; set; }
    public DateTime CreatedAt { get; set; }
}
