using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Serie;
using DanderiTV.Layer.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> ViewTrailer([FromRoute] int ID)
        {
            var serieTask = _serieService.GetByID(ID);
            var serie = await serieTask;

            return View(serie);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(SaveSerieModel vm)
		{
			vm.Genres = await _genresServices.GetAll();
			vm.Producers = await _producersServices.GetAll();

			if (!ModelState.IsValid)
			{

				return View("CreateSerie", vm);
			}
			else
			{
				await _serieService.Update(vm,vm.ID);
				return RedirectToRoute(new { controller = "Home", action = "Index" });
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			SaveSerieModel vm = await _serieService.GetByIDSaveModel(id);
			vm.Genres = await _genresServices.GetAll();
			vm.Producers = await _producersServices.GetAll();

			return View("CreateSerie", vm);
		}


		public async Task<IActionResult> Create()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var serieGetAllTask = _genresServices.GetAll();
            var producerGetAllTask = _producersServices.GetAll();

            SaveSerieModel vm = new()
            {
                Genres = await serieGetAllTask,
                Producers = await producerGetAllTask


            };

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed}");

          




            return View("CreateSerie", vm);
           
        }
    }
}
