using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Dto;
using api_dictionary.Infrastructure.Files.Maps;
using CsvHelper;

namespace api_dictionary.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<DistrictMap>();
                csvWriter.WriteRecords(cities);
            }

            return memoryStream.ToArray();
        }
    }
}
