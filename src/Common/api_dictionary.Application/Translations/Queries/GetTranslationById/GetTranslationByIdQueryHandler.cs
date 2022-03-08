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

namespace api_dictionary.Application.Translations.Queries.GetTranslationById;
public class GetTranslationByIdQueryHandler : IRequestHandler<GetTranslationByIdQuery, ServiceResult<GetTranslationByIdQueryResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTranslationByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<GetTranslationByIdQueryResponse>> Handle(GetTranslationByIdQuery request, CancellationToken cancellationToken)
    {
        var translationById = _mapper
            .Map<GetTranslationByIdQueryResponse>(_context
                .Translations
                .Where(x => x.Id == request.TranslationId)
                .FirstOrDefault(o => o.Id == request.TranslationId)
            );

        return ServiceResult.Success(translationById);
    }
}
