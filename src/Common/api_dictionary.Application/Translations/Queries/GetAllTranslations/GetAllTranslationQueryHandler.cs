using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using MediatR;
using System.Threading;

namespace api_dictionary.Application.Translations.Queries.GetAllTranslations;
public class GetAllTranslationQueryHandler : IRequestHandler<GetAllTranslationQuery, ServiceResult<List<GetAllTransLationQueryResponse>>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTranslationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<List<GetAllTransLationQueryResponse>>> Handle(GetAllTranslationQuery request, CancellationToken cancellationToken)
    {
        List<GetAllTransLationQueryResponse> allTranslationsList = new List<GetAllTransLationQueryResponse>();
        foreach(var translation in _context.Translations.ToList())
        {
            allTranslationsList.Add(_mapper.Map<GetAllTransLationQueryResponse>(translation));
        }
        return ServiceResult.Success(allTranslationsList);
    }
}
