using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSkylos_API.Data;
using ProjetoSkylos_API.Models;
using System;

namespace ProjetoSkylos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        public IRepository Repo { get; }
        public AnimalController(IRepository repo)
        {
            this.Repo = repo;
            //construtor
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllAnimaisAsync();
                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var result = await this.Repo.GetAllAnimaisAsyncById(Id);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Animal model)
        {
            try
            {
                this.Repo.Add(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/api/animal/{model.Id}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> put(int Id, Animal model)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var animal = await this.Repo.GetAllAnimaisAsyncById(Id);
                if (animal == null) return NotFound(); //método do EF
                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar o aluno novamente, agora alterado para devolver pela rota abaixo
                    animal = await this.Repo.GetAllAnimaisAsyncById(Id);
                    return Created($"/api/animal/{model.Id}", animal);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu alterar
            return BadRequest();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var animal = await this.Repo.GetAllAnimaisAsyncById(Id);
                if (animal == null) return NotFound(); //método do EF
                this.Repo.Delete(animal);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch(Exception erro)
            {
                Console.WriteLine(erro.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu deletar
            return BadRequest();
        }
    }
}