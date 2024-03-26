
using DanderiTV.Layer.Application.Models.Serie;
using DanderiTV.Layer.DataAccess.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Repositories
{
    public interface ISerieRepository : IGenericRepository<Serie>
    {
		Task<IEnumerable<SerieViewModel>> GetAllWithInclude();


	}
}
