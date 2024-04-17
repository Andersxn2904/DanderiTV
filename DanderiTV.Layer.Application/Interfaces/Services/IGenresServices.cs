
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.DataAccess.Entities;


namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IGenresServices
    {
        Task<IEnumerable<GenresViewModel>> GetAll();

        Task<Genre> CreateAsync(SaveGenreModel model);

        Task<GenresViewModel> FindByIdModel(int id);

        Task Delete(int id);

        Task<Genre> Update(SaveGenreModel model, int id);
    }
}
