namespace Domain.Utils
{
    public static class Utils
    {
        public static string FormatarCpf(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}
