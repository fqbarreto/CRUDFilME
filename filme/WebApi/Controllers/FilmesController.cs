using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : Controller
    {
        [HttpGet]
        public IEnumerable<Filmes> getFilmes()
        {
            FilmesService service = new FilmesService();
            return service.listAll();
        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            FilmesService service = new FilmesService();
            return Ok(service.getById(id));
        }
        [HttpPost]
        public IActionResult addOrUpdateFilme(FilmesInputModel filmeInput)
        {
            FilmesService service = new FilmesService();
            Filmes filmeN = new Filmes();
            filmeN.FilmeId = filmeInput.FilmeId;
            filmeN.Nome = filmeInput.Nome;
            Filmes filmes = service.getById(filmeInput.FilmeId);
            if(filmes != null)
            {
                service.update(filmeN);
                return Ok();
            }
            else
            {
                service.add(filmeN);
                return Ok();
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult deleteFilme(int id)
        {
            FilmesService service = new FilmesService();
            return Ok(service.delete(id));
        }
    }
}
