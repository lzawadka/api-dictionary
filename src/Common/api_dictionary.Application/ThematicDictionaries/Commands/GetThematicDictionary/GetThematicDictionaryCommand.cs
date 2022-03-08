using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using api_dictionary.Domain.Entities;
using MediatR;

namespace api_dictionary.Application.ThematicDictionaries.Commands.GetThematicDictionary;
public class GetThematicDictionaryCommand : IRequest<ServiceResult<List<ThematicDictionaryModel>>>
{
}
