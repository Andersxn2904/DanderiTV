using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Genres;
using DanderiTV.Layer.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenresServices _genreservice;

        public GenreController(IGenresServices genreservice)
        {
            _genreservice = genreservice;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genreservice.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(SaveGenreModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            await _genreservice.CreateAsync(model);

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _genreservice.FindByIdModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGenre([FromBody]int Id)
        {
            await _genreservice.Delete(Id);
            return RedirectToRoute(new { controller = "Genre", action = "Index" });
        }






    }
}
