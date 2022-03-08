namespace api_dictionary.Application.Dto
{
    public class ExportDto
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}
