using api_dictionary.Domain.Common;
using api_dictionary.Domain.Entities;
using System.Collections.Generic;

namespace api_dictionary.Domain.Entities
{
    public class ThematicDictionary : AuditableEntity
    {
        public int Id { get; set; }
        public string ThematicDictionaryName { get; set; }
        public ICollection<ThematicDictionaryTranslation> ThematicDictionaryTranslation { get; set; }
    }
}

