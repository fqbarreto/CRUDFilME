using Domain.Repositories;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Application.Services
{
    public class FilmesService
    {
        FilmesRepository repository = new FilmesRepository();
        public Filmes update(Filmes filme)
        {
            return repository.update(filme);    
        }
        public void add(Filmes filme)
        {
            repository.add(filme);
        }
        public bool delete(int id)
        {
            return repository.delete(id);
        }
        public Filmes getById(int id)
        {
            return repository.getById(id);
        }
        public IEnumerable<Filmes> listAll()
        {
            return repository.getAll();
        }
    }
}
