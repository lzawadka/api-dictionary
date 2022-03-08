using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_dictionary.Application.Translations.Queries.GetAllTranslations;
public class GetAllTransLationQueryResponse
{
    public int TranslationId { get; set; }
    public string OriginLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string OriginLanguageWord { get; set; }
    public string TargetLanguageWord { get; set; }
    public DateTime CreatedAt { get; set; }
}
