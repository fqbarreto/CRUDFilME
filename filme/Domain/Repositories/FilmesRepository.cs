using Domain.Repositories.Interfaces;
using Domain.Models;
namespace Domain.Repositories
{
    public class FilmesRepository : IFilmesRepository

    {
        filmin_dbContext dbcontext = new filmin_dbContext();
        public void add(Filmes filme)
        {
            dbcontext.Filmes.Add(filme);
            dbcontext.SaveChanges();
        }

        public bool delete(int id)
        {
            Filmes filme = getById(id);
            if (filme.FilmeId > 0)
            {
                dbcontext.Filmes.Remove(filme);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Filmes getById(int id)
        {
            return dbcontext.Filmes.Find(id);
        }

        public Filmes update(Filmes filme)
        {
            Filmes filmeN = getById(filme.FilmeId);
            dbcontext.Entry(filmeN).CurrentValues.SetValues(filme);
            dbcontext.SaveChanges();
            return filmeN;
        }

        public IEnumerable<Filmes> getAll()
        {
            return dbcontext.Filmes.ToList();
        }
    }
}
