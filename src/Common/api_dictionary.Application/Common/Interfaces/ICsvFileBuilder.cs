using System.Collections.Generic;
using api_dictionary.Application.Dto;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}
