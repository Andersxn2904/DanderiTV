using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Serie;
using DanderiTV.Layer.DataAccess.Entities;

namespace DanderiTV.Layer.Application.Services
{
    public class SerieService : ISerieServices
    {
        private readonly ISerieRepository _Serierespository;
        public SerieService(ISerieRepository repository) { _Serierespository = repository; }

        public async Task<Serie> CreateAsync(SaveSerieModel model)
        {
            var Serie = new Serie() {
            Name = model.Name,
            CoverUrlProperty = model.CoverUrl,
            VideoUrlProperty = model.VideoUrl,
            MainGenreID = model.MainGenreID,
            SecondaryGenreID = model.SecondaryGenreID,
            ProducerID = model.ProducerID,

            };
           Serie SerieAdded = await _Serierespository.Add(Serie);

            return SerieAdded;

        }

        public async Task<IEnumerable<SerieViewModel>> GetAll()
        {
            return await _Serierespository.GetAllWithInclude();
        }
    }
}
