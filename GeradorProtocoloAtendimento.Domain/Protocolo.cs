namespace GeradorProtocoloAtendimento.Domain
{
    public class Protocolo
    {
        public string EmpresaIdentificador { get; set; } = string.Empty;
        public DateTime DataAtual { get; set; } = DateTime.Now.Date;
        public int NumeroSequencial { get; set; }
    }
}
