using System.Threading.Tasks;
using ProjetoSkylos_API.Models;

namespace ProjetoSkylos_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente> GetAllClientesAsyncById(int Id);
        Task<Cliente> GetClienteByEmailAndSenha(string Email, string Senha);

        Task<Cuidador[]> GetAllCuidadoresAsync();
        Task<Cuidador> GetAllCuidadoresAsyncById(int Id);
        Task<Cuidador> GetCuidadorByEmailAndSenha(string Email, string Senha);

        Task<Cuidador[]> GetCuidadoresByFilter(float Latitude,float Longitude,string AfinidadeComBichos);

        Task<Animal[]> GetAllAnimaisAsync();
        Task<Animal> GetAllAnimaisAsyncById(int id);

        Task<Avaliacao[]> GetAllAvaliacoesAsync();
        Task<Avaliacao> GetAllAvaliacoesAsyncById(int id);

        Task<Servico[]> GetAllServicosAsync();
        Task<Servico> GetAllServicosAsyncById(int id);
    }
}