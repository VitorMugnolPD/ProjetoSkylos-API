namespace ProjetoSkylos_API.Models
{   
    public class Cuidador
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Senha {get; set;}
        public float Latitude{get; set;}

        public float Longitude {get; set;} 

        public string AfinidadeComBichos{get;set;}
    }
}