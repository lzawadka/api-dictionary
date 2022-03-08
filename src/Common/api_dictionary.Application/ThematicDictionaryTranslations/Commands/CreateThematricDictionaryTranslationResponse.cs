using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_dictionary.Application.ThematicDictionaryTranslations.Commands;
public class CreateThematricDictionaryTranslationResponse
{
    public List<int> ThematicDictionaryId { get; set; }
    public int TranslationId { get; set; }

}
