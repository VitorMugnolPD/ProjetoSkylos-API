namespace ProjetoSkylos_API.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdCuidador { get; set; }
        public double Nota { get; set; }
    }
}