
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.Application.Models.Producers;
using DanderiTV.Layer.DataAccess.Entities;


namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IProducersServices
    {
        Task<IEnumerable<ProducerViewModel>> GetAll();

        Task<Producer> CreateAsync(SaveProducerModel model);
        Task<ProducerViewModel> FindByIdModel(int id);

        Task<Producer> Update(SaveProducerModel model, int id);
        Task Delete(int id);
    }
}
