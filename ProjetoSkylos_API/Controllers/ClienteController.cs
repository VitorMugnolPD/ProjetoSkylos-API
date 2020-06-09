using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSkylos_API.Data;
using ProjetoSkylos_API.Models;


namespace ProjetoSkylos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        public IRepository Repo { get; }
        public ClienteController(IRepository repo)
        {
            this.Repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllClientesAsync();
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 "Falha no acesso ao banco de dados.");
            }
        }
        [HttpGet("{IdCliente}")]
        public async Task<IActionResult> Get(int IdCliente)
        {
            try
            {
                var result = await this.Repo.GetAllClientesAsyncById(IdCliente);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Cliente model)
        {
            try
            {
                this.Repo.Add(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/api/cliente/{model.Id}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
        [HttpPut("{IdCliente}")]
        public async Task<IActionResult> put(int IdCliente, Cliente model)
        {
            try
            {
                var cliente = await this.Repo.GetAllClientesAsyncById(IdCliente);
                if (cliente == null) return NotFound(); //método do EF


                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar o aluno novamente, agora alterado para devolver pela rota abaixo
                    cliente = await this.Repo.GetAllClientesAsyncById(IdCliente);
                    return Created($"/api/cliente/{model.Id}", cliente);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
        [HttpDelete("{IdCliente}")]
        public async Task<IActionResult> delete(int IdCliente)
        {
            try
            {
                var cliente = await this.Repo.GetAllClientesAsyncById(IdCliente);
                if (cliente == null) return NotFound(); //método do EF
                this.Repo.Delete(cliente);
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
        [HttpGet("{Email}/{Senha}")]
        public async Task<IActionResult> Get(string Email, string Senha)
        {
            try
            {
                var result = await this.Repo.GetClienteByEmailAndSenha(Email,Senha);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
        }
    }
}