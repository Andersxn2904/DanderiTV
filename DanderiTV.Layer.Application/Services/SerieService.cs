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
            CoverUrl = model.CoverUrl,
            VideoUrl = model.VideoUrl,
            MainGenreID = model.MainGenreID,
            SecondaryGenreID = model.SecondaryGenreID,
            ProducerID = model.ProducerID,

            };
           Serie SerieAdded = await _Serierespository.Add(Serie);

            return SerieAdded;

        }

        public async Task<IEnumerable<SerieViewModel>> GetAll() => await _Serierespository.GetAllWithInclude();

        public async Task<SerieViewModel> GetByID(int ID) 
        {
            var serie = await _Serierespository.FindByIDWithAll(ID);
            SerieViewModel serieViewModel = new();
            serieViewModel.Name = serie.Name;
            serieViewModel.Producer = serie.Producer;
            serieViewModel.MainGenre = serie.MainGenre;
            serieViewModel.ID = serie.ID;
            serieViewModel.CoverUrl = serie.CoverUrl;
            serieViewModel.MainGenreID = serie.MainGenreID;
            serieViewModel.MainGenre = serie.MainGenre;
            serieViewModel.SecondaryGenre = serie.SecondaryGenre;
            serieViewModel.VideoUrl = serie.VideoUrl;

            return serieViewModel;

                
        }
		public async Task<SaveSerieModel> GetByIDSaveModel(int ID)
		{
			var serie = await _Serierespository.FindByIDWithAll(ID);
			SaveSerieModel serieViewModel = new();
			serieViewModel.Name = serie.Name;
			serieViewModel.ProducerID = (Int32)serie.ProducerID;
			serieViewModel.MainGenreID = (Int32)serie.MainGenreID;
            serieViewModel.CoverUrl = serie.CoverUrl;
			serieViewModel.ID = serie.ID;
			serieViewModel.VideoUrl = serie.VideoUrl;

			return serieViewModel;


		}

		public async Task<Serie> Update(SaveSerieModel SerieToAdd, int id)
        {
            Serie serie = new();
			serie.Name = SerieToAdd.Name;
			serie.ProducerID = SerieToAdd.ProducerID;
			serie.MainGenreID = SerieToAdd.MainGenreID;
			serie.ID = SerieToAdd.ID;
			serie.VideoUrl = SerieToAdd.VideoUrl;

            var serieAdded = await _Serierespository.Update(serie, id);

            return serieAdded;
        }


	}
}
