using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using DanderiTV.Layer.DataAccess.Entities;


namespace DanderiTV.Layer.Application.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        public SerieRepository(DapperContext context) : base(context) { }
    }
}
