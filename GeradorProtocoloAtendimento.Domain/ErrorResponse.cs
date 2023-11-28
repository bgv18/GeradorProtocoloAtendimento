using System.Net;

namespace GeradorProtocoloAtendimento.Domain
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Mensagem { get; set; }
    }
}
