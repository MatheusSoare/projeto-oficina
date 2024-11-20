namespace Domain.Entities.Command
{
    public class GerarNotaClienteCmd
    {
        public string Nome {  get; set; }
        public string Cpf { get; set; }
        public string MarcaCarro { get; set; }
        public string ModeloCarro { get; set; }
        public int AnoCarro { get; set; }
        public string Placacarro { get; set; }
        public List<Servico> Servicos { get; set; }
    }
}
