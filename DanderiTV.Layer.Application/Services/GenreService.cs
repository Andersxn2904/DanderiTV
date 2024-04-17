using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.DataAccess.Entities;

namespace DanderiTV.Layer.Application.Services
{
    public class GenreService : IGenresServices
    {
        private readonly IGenreRepository _Genresrespository;
        public GenreService(IGenreRepository repository) { _Genresrespository = repository; }

        public async Task<IEnumerable<GenresViewModel>> GetAll()
        {
           var models = await _Genresrespository.GetAll();

           var listmodel = models.Select(g => new GenresViewModel { Name = g.Name, Id = g.ID });

           return listmodel;

        }

        public async Task<Genre> CreateAsync(SaveGenreModel model)
        {
            var Genre = new Genre()
            {
                Name = model.Name,
              

            };
            Genre GenreAdded = await _Genresrespository.Add(Genre);

            return GenreAdded;

        }

        public async Task<GenresViewModel> FindByIdModel(int id)
        {
      
            Genre Genre = await _Genresrespository.FindById(id);
            GenresViewModel ViewModel = new()
            {
                Id = Genre.ID,
                Name = Genre.Name
            };

            return ViewModel;

        }

        public async Task Delete(int id)
        {
            Genre genre = await _Genresrespository . FindById(id);

            await _Genresrespository.Delete(genre);
        }

        public async Task<Genre> Update(SaveGenreModel model, int id)
        {

            Genre genre = await _Genresrespository.FindById(id);
            genre.Name = model.Name;
            Genre GenreUpdated = await _Genresrespository.Update(genre, id);

            return GenreUpdated;

        }




    }
}
