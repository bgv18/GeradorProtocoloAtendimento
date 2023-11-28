namespace GeradorProtocoloAtendimento.Services
{
    public interface IGerarProtocolo
    {
        string GerarProtocolo(string empresaId, DateTime data, out string erro);
    }
}
