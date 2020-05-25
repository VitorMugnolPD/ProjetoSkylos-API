namespace ProjetoSkylos_API.Models
{   
    public class Cuidador
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Senha {get; set;}
        public string Email {get; set;}
        public double Latitude{get; set;}
        public double Longitude {get; set;} 
        public string AfinidadeComBichos{get;set;}
    }
}