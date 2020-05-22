using System.Threading.Tasks;
using ProjetoSkylos_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace ProjetoSkylos_API.Data
{

    public class Repository : IRepository
    {
        public SkylosContext Context { get; }

        public Repository(SkylosContext context)
        {
            this.Context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            this.Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.Context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.Context.SaveChangesAsync() > 0);
        }
        public void Update<T>(T entity) where T : class
        {
            this.Context.Update(entity);
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            //throw new System.NotImplementedException();
            IQueryable<Cliente> consultaClientes = this.Context.Cliente;
            consultaClientes = consultaClientes.OrderBy(a => a.Id);

            return await consultaClientes.ToArrayAsync();
        }
        public async Task<Cliente> GetAllClientesAsyncById(int Id)
        {
            //throw new System.NotImplementedException();
            IQueryable<Cliente> consultaClientes = this.Context.Cliente;

            consultaClientes = consultaClientes.OrderBy(a => a.Id)
            .Where(cliente => cliente.Id == Id);

            return await consultaClientes.FirstOrDefaultAsync();
        }

        public async Task<Cuidador[]> GetAllCuidadoresAsync()
        {
            //throw new System.NotImplementedException();
            IQueryable<Cuidador> consultaCuidadores = this.Context.Cuidador;
            consultaCuidadores = consultaCuidadores.OrderBy(a => a.Id);

            return await consultaCuidadores.ToArrayAsync();
        }

        public async Task<Cuidador> GetAllCuidadoresAsyncById(int Id)
        {
            IQueryable<Cuidador> consultaCuidadores = this.Context.Cuidador;
            consultaCuidadores = consultaCuidadores.OrderBy(a => a.Id)
            .Where(cuidador => cuidador.Id == Id);


            return await consultaCuidadores.FirstOrDefaultAsync();
        }
        public async Task<Cuidador[]> GetCuidadoresByFilter(float Latitude, float Longitude, string AfinidadeComBichos)
        {    

          IQueryable<Cuidador> consultaCuidadores = this.Context.Cuidador;
          consultaCuidadores = consultaCuidadores.OrderBy(a => a.Id)
          .Where(cuidador => (cuidador.Latitude > Latitude -0.5 || cuidador.Latitude < Latitude + 0.5) && (cuidador.Longitude > Longitude - 0.5 || cuidador.Longitude < Longitude + 0.5) && (cuidador.AfinidadeComBichos.Contains(AfinidadeComBichos)));


         return await consultaCuidadores.ToArrayAsync();
        }


        public async Task<Animal[]> GetAllAnimaisAsync()
        {
            //throw new System.NotImplementedException();
            IQueryable<Animal> consultaAnimais = this.Context.Animal;
            consultaAnimais = consultaAnimais.OrderBy(a => a.Id);

            return await consultaAnimais.ToArrayAsync();
        }

        public async Task<Animal> GetAllAnimaisAsyncById(int Id)
        {
            IQueryable<Animal> consultaAnimais = this.Context.Animal;
            consultaAnimais = consultaAnimais.OrderBy(a => a.Id)
            .Where(animal => animal.Id == Id);


            return await consultaAnimais.FirstOrDefaultAsync();
        }

        public async Task<Avaliacao[]> GetAllAvaliacoesAsync()
        {
            //throw new System.NotImplementedException();
            IQueryable<Avaliacao> consultaAvaliacoes = this.Context.Avaliacao;
            consultaAvaliacoes = consultaAvaliacoes.OrderBy(a => a.Id);

            return await consultaAvaliacoes.ToArrayAsync();
        }

        public async Task<Avaliacao> GetAllAvaliacoesAsyncById(int Id)
        {
            IQueryable<Avaliacao> consultaAvaliacoes = this.Context.Avaliacao;
            consultaAvaliacoes = consultaAvaliacoes.OrderBy(a => a.Id)
            .Where(Avaliacao => Avaliacao.Id == Id);


            return await consultaAvaliacoes.FirstOrDefaultAsync();
        }

    }
}