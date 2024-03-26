
using DanderiTV.Layer.Application.Models.Serie;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
	public interface ISerieServices
	{
		Task<IEnumerable<SerieViewModel>> GetAll();
	}
}
