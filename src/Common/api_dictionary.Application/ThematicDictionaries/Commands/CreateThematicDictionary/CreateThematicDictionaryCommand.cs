using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using MediatR;

namespace api_dictionary.Application.ThematicDictionaries.Commands.CreateThematicDictionary;
public class CreateThematicDictionaryCommand : IRequest<List<int>>
{
    public List<ThematicDictionaryModel> ThematicDictionaries { get; set; }
}