using System.Net;

namespace swp391_debo_be.Constants
{
    public class ApiRespone
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
