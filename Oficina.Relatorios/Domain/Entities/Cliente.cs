namespace Domain.Entities
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string CpfFormatado => Utils.Utils.FormatarCpf(Cpf);
        public string NomeFormatado => $"{Nome} - {CpfFormatado}";
    }
}
