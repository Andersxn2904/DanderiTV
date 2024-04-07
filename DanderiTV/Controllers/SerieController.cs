using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Serie;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieServices _serieService;
        private readonly IGenresServices _genresServices;
        private readonly IProducersServices _producersServices;
        public SerieController(ISerieServices serieService,
            IGenresServices genresServices,
            IProducersServices producersServices)

        { _serieService = serieService;
            _genresServices = genresServices;
            _producersServices = producersServices; }


        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateSerie",vm);
            }
            await _serieService.CreateAsync(vm);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Create()
        {
            SaveSerieModel vm = new()
            {
                Genres = await _genresServices.GetAll(),
                Producers = await _producersServices.GetAll(),
            };
            
            return View("CreateSerie", vm);
        }
    }
}
