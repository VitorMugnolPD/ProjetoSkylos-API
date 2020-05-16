using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSkylos_API.Data;
using ProjetoSkylos_API.Models;

namespace ProjetoSkylos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadorController : Controller
    {

        public IRepository Repo { get; }
        public CuidadorController(IRepository repo)
        {
            this.Repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllCuidadoresAsync();
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 "Falha no acesso ao banco de dados.");
            }
        }
        [HttpGet("{IdCuidador}")]
        public async Task<IActionResult> Get(int IdCuidador)
        {
            try
            {
                var result = await this.Repo.GetAllCuidadoresAsyncById(IdCuidador);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("{Longitude}/{Latitude}/{AfinidadeComBichos}")]
        public async Task<IActionResult> Get(float Latitude, float Longitude, string AfinidadeComBichos)
        {
            try
            {
                var result = await this.Repo.GetCuidadoresByFilter(Latitude,Longitude,AfinidadeComBichos);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Cuidador model)
        {
            try
            {
                this.Repo.Add(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/api/cuidador/{model.Id}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "oof.");
            }
            return BadRequest();
        }
        [HttpPut("{CodCuidador}")]
        public async Task<IActionResult> put(int IdCuidador, Cuidador model)
        {
            try
            {
                var cuidador = await this.Repo.GetAllCuidadoresAsyncById(IdCuidador);
                if (cuidador == null) return NotFound(); //método do EF


                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar o aluno novamente, agora alterado para devolver pela rota abaixo
                    cuidador = await this.Repo.GetAllCuidadoresAsyncById(IdCuidador);
                    return Created($"/api/Cuidador/{model.Id}", cuidador);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
        [HttpDelete("{CodCuidador}")]
        public async Task<IActionResult> delete(int IdCuidador)
        {
            try
            {
                var cuidador = await this.Repo.GetAllCuidadoresAsyncById(IdCuidador);
                if (cuidador == null) return NotFound(); //método do EF
                this.Repo.Delete(cuidador);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
    }
}