namespace ProjetoSkylos_API.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public int IdCliente{ get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Temperamento{ get; set; }
    }
}