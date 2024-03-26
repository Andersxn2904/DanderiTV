using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using DanderiTV.Layer.DataAccess.Entities;

namespace DanderiTV.Layer.Application.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DapperContext context) : base(context) { }
    }
}
