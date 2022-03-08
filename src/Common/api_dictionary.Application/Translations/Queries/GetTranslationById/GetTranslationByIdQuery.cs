using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using MediatR;

namespace api_dictionary.Application.Translations.Queries.GetTranslationById;
public class GetTranslationByIdQuery : IRequest<ServiceResult<GetTranslationByIdQueryResponse>>
{
    public int TranslationId { get; set; }
}
