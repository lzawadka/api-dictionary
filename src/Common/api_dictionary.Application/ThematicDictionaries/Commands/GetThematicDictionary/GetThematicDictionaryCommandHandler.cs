using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using api_dictionary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using api_dictionary.Application.ThematicDictionaries.Commands.GetThematicDictionary;
using System.Threading;

namespace dictionary_api.Application.ThematicDictionaries.Commands.GetThematicDictionary;
public class GetThematicDictionaryCommandHandler : IRequestHandler<GetThematicDictionaryCommand, ServiceResult<List<ThematicDictionaryModel>>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetThematicDictionaryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ServiceResult<List<ThematicDictionaryModel>>> Handle(GetThematicDictionaryCommand request, CancellationToken cancellationToken)
    {
        List<ThematicDictionary> listOfThematicDictionary = await _context
            .ThematicDictionaries
            .ToListAsync(cancellationToken);

        List<ThematicDictionaryModel> listThematicDictionary = new List<ThematicDictionaryModel>();
        foreach (var thematicDictionary in listOfThematicDictionary)
        {
            listThematicDictionary.Add(_mapper.Map<ThematicDictionaryModel>(thematicDictionary));
        }

        if(listThematicDictionary.Any())
            return ServiceResult.Success(listThematicDictionary.OrderBy(x => x.ThematicDictionaryName).ToList());

        return ServiceResult.Failed<List<ThematicDictionaryModel>>(ServiceError.NotFound);
    }
}
