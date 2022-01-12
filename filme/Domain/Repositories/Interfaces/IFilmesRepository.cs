using Domain.Models;
namespace Domain.Repositories.Interfaces
{
    public interface IFilmesRepository
    {
        void add(Filmes filme);

        Filmes getById(int id);

        Filmes update(Filmes filmes);

        bool delete(int id);   

    }
}
