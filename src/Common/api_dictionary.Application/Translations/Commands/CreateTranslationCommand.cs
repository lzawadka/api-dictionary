using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.ThematicDictionaryTranslations.Command;
using api_dictionary.Domain.Entities;
using MediatR;

namespace api_dictionary.Application.Translations.Commands;
public class CreateTranslationCommand : IRequest<int>
{
    public List<int> ThematicDictionaryList { get; set; }
    public TranslationModel Translation { get; set; }

    public class CreateTranslationCommandHandler : IRequestHandler<CreateTranslationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTranslationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTranslationCommand request, CancellationToken cancellationToken)
        {
            var entityTranslation = new Translation();
            entityTranslation.OriginLanguage = request.Translation.OriginLanguage;
            entityTranslation.TargetLanguage = request.Translation.TargetLanguage;
            entityTranslation.TargetLanguageWord = request.Translation.TargetLanguageWord;
            entityTranslation.OriginLanguageWord = request.Translation.OriginLanguageWord;

            _context.Translations.Add(entityTranslation);

            await _context.SaveChangesAsync(cancellationToken);

            return entityTranslation.Id;
        }
    }
}
