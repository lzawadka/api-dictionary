using api_dictionary.Domain.Common;
using api_dictionary.Domain.Entities;
using System.Collections.Generic;

public class Translation : AuditableEntity
{
    public int Id { get; set; }
    public string OriginLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string OriginLanguageWord { get; set; }
    public string TargetLanguageWord { get; set; }
    public ICollection<ThematicDictionaryTranslation> ThematicDictionaryTranslation { get; set; }

}
