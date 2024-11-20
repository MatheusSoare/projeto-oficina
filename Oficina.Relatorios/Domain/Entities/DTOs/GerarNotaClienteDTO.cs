using Domain.Entities.Command;

namespace Domain.Entities.DTOs
{
    public class GerarNotaClienteDTO
    {
        public GerarNotaClienteDTO() { }

        public GerarNotaClienteDTO(GerarNotaClienteCmd cmd)
        {
            Cliente = new Cliente()
            {
                Nome = cmd.Nome,
                Cpf = cmd.Cpf
            };

            Carro = new Carro()
            {
                Marca = cmd.MarcaCarro,
                Modelo = cmd.ModeloCarro,
                Ano = cmd.AnoCarro,
                Placa = cmd.ModeloCarro
            };

            Servicos = cmd.Servicos;

            ValorTotal = cmd.Servicos.Sum(x => x.Valor);
        }

        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public List<Servico> Servicos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
