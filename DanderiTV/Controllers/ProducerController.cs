using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Models.Producers;
using DanderiTV.Layer.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanderiTV.Controllers
{
    public class ProducerController : Controller
    {
        public readonly IProducersServices _producersServices;

        public ProducerController(IProducersServices producersServices)
        {
            _producersServices = producersServices;
        }


        public async Task<IActionResult> Home()
        {
            return View(await _producersServices.GetAll());
        }

        public async Task<IActionResult> CreateProducer()
        {
            SaveProducerModel vm = new();
            
            return View("CreateProducer", vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducer(SaveProducerModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProducer", vm);
            }
            await _producersServices.CreateAsync(vm);
            return RedirectToRoute(new { controller = "Producer", action = "Home" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _producersServices.FindByIdModel(id);
            SaveProducerModel model = new(); model.ID = vm.Id; model.Name = vm.Name;
           
            return View("CreateProducer", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProducerModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProducer", vm);
            }
            await _producersServices.Update(vm, vm.ID);
            return RedirectToRoute(new { controller = "Producer", action = "Home" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _producersServices.FindByIdModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _producersServices.Delete(id);
            return RedirectToRoute(new { controller = "Producer", action = "Home" });
        }






    }
}
