
using DanderiTV.Layer.Application.Models.Serie;
using DanderiTV.Layer.DataAccess.Entities;

namespace DanderiTV.Layer.Application.Interfaces.Services
{
	public interface ISerieServices
	{
		Task<IEnumerable<SerieViewModel>> GetAll();
		Task<Serie> CreateAsync(SaveSerieModel model);

		Task<SerieViewModel> GetByID(int ID);

		Task<Serie> Update(SaveSerieModel SerieToAdd, int id);
		Task<SaveSerieModel> GetByIDSaveModel(int ID);


	}
}
