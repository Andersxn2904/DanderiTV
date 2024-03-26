using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using DanderiTV.Layer.DataAccess.Entities;


namespace DanderiTV.Layer.Application.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DapperContext context) : base(context){}
    }
}
