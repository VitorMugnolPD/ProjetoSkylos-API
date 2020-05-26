using System;

namespace ProjetoSkylos_API.Models 
{
    public class Servico 
    {
        public int Id { get; set; }
        public int IdCuidador { get; set;}
        public int IdCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public int Periodo { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Preco { get; set; }
    }
}