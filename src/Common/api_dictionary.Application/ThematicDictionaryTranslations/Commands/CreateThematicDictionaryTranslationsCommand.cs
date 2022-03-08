using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Domain.Entities;
using MediatR;

namespace api_dictionary.Application.ThematicDictionaryTranslations.Command;
public class CreateThematicDictionaryTranslationsCommand : IRequest
{
    public int ThematicDictionaryId { get; set; }
    public int TranslationId { get; set; }

    public class ThematicDictionaryTranslationsCommandHandler : IRequestHandler<CreateThematicDictionaryTranslationsCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ThematicDictionaryTranslationsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateThematicDictionaryTranslationsCommand request, CancellationToken cancellationToken)
        {
            var entity = new ThematicDictionaryTranslation();
            entity.ThematicDictionaryId = request.ThematicDictionaryId;
            entity.TranslationId = request.TranslationId;

            _context.ThematicDictionaryTranslations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
