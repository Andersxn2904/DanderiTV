
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.Application.Models.Producers;

namespace DanderiTV.Layer.Application.Services
{
    public class ProducerService : IProducersServices
    {
        private readonly IProducerRepository _Producersrespository;
        public ProducerService(IProducerRepository repository) { _Producersrespository = repository; }

        public async Task<IEnumerable<ProducerViewModel>> GetAll()
        {
            var models = await _Producersrespository.GetAll();

            var listmodel = models.Select(p => new ProducerViewModel { Name = p.Name, Id = p.ID });

            return listmodel;

        }

    }
}
