
using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.Application.Models.Producers;
using DanderiTV.Layer.DataAccess.Entities;

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

        public async Task<Producer> CreateAsync(SaveProducerModel model)
        {
            var Genre = new Producer()
            {
                Name = model.Name,


            };
            Producer ProducerAdded = await _Producersrespository.Add(Genre);

            return ProducerAdded;

        }

        public async Task<ProducerViewModel> FindByIdModel(int id)
        {

            Producer Producer = await _Producersrespository.FindById(id);
            ProducerViewModel ViewModel = new()
            {
                Id = Producer.ID,
                Name = Producer.Name
            };

            return ViewModel;

        }

        public async Task<Producer> Update(SaveProducerModel model, int id)
        {

            Producer producer = await _Producersrespository.FindById(id);
            producer.Name = model.Name;
            Producer ProducerUpdated = await _Producersrespository.Update(producer, id);

            return ProducerUpdated;

        }

        public async Task Delete(int id)
        {
            Producer genre = await _Producersrespository.FindById(id);

            await _Producersrespository.Delete(genre);
        }



    }
}
