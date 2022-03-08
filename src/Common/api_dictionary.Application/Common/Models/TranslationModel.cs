using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_dictionary.Application.Common.Models;
public class TranslationModel
{
    public string OriginLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string OriginLanguageWord { get; set; }
    public string TargetLanguageWord { get; set; }
}
