namespace Application.Api.DTO
{
    public class ResponseApiDTO
    {
        public int status { get; set; }
        public string message { get; set; }
        public string? details { get; set; }
    }
}