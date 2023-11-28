
using GeradorProtocoloAtendimento.Domain;
using GeradorProtocoloAtendimento.EF;

namespace GeradorProtocoloAtendimento.Services
{
    public class GerarProtocolo : IGerarProtocolo
    {
        private readonly Contexto _db;
        public GerarProtocolo(Contexto db)
        {
            _db = db;
        }
        string IGerarProtocolo.GerarProtocolo(string empresaId, DateTime data, out string erro)
        {
            erro = "";
            var protocolo = new Protocolo()
            {
                EmpresaIdentificador = empresaId,
                DataAtual = data.ToUniversalTime()
            };
            protocolo.NumeroSequencial = RetornaSequencialData(protocolo);

            return $"{protocolo.EmpresaIdentificador}{protocolo.DataAtual.ToString("yyyyMMdd")}{protocolo.NumeroSequencial.ToString("D6")}";
        }

        private int RetornaSequencialData(Protocolo protocolo)
        {
            var ultimaSequencia = _db.Protocolo.Where(p => p.DataAtual == protocolo.DataAtual)
                                               .OrderByDescending(p => p.NumeroSequencial)
                                               .FirstOrDefault();

            protocolo.NumeroSequencial = ultimaSequencia is null ? protocolo.NumeroSequencial = 1 : ultimaSequencia.NumeroSequencial + 1;

            _db.Add(protocolo);
            _db.SaveChanges();
            return protocolo.NumeroSequencial;

        }
    }
}
