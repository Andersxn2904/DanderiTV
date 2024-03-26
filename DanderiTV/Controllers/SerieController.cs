
using DanderiTV.Layer.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieServices _serieService;
        public SerieController(ISerieServices serieService) { _serieService = serieService; }

        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAll());
        }
    }
}
