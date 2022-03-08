using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using api_dictionary.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace api_dictionary.Application.ThematicDictionaries.Commands.CreateThematicDictionary;
public class CreateThematicDictionaryCommandHandler : IRequestHandler<CreateThematicDictionaryCommand, List<int>>
{
    private readonly IApplicationDbContext _context;

    public CreateThematicDictionaryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<int>> Handle(CreateThematicDictionaryCommand request, CancellationToken cancellationToken)
    {
        List<int> thematicDictionaryIds = new List<int>();
        foreach (var thematicDictionary in request.ThematicDictionaries)
        {
            ThematicDictionary existingThematicDictionary = _context.ThematicDictionaries.FirstOrDefault(u => u.Id == thematicDictionary.Id);
            if (existingThematicDictionary != null)
            {
                thematicDictionaryIds.Add(existingThematicDictionary.Id);
            }
            else
            {
                var entity = new ThematicDictionary();
                entity.ThematicDictionaryName = thematicDictionary.ThematicDictionaryName;

                _context.ThematicDictionaries.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                thematicDictionaryIds.Add(thematicDictionary.Id);
            }
        }

        return thematicDictionaryIds;
    }
}
