
using DanderiTV.Layer.Application.Models.Producers;


namespace DanderiTV.Layer.Application.Interfaces.Services
{
    public interface IProducersServices
    {
        Task<IEnumerable<ProducerViewModel>> GetAll();

        //Task<Serie> CreateAsync(SaveSerieModel model);
    }
}
