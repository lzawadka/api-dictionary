using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using MediatR;

namespace api_dictionary.Application.ThematicDictionaries.Queries;
public class GetThematicDictionaryQuery : IRequest<ServiceResult<List<ListOfTranslationByThematicDictionary>>>
{
    public int ThematicDictionaryId { get; set; }
}
