using api_dictionary.Domain.Common;

namespace api_dictionary.Domain.Entities
{
    public class ThematicDictionaryTranslation
    {
        public int ThematicDictionaryId { get; set; }
        public ThematicDictionary ThematicDictionary { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }

    }
};

