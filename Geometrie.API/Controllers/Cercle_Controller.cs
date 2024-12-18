using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Swashbuckle.AspNetCore.Filters;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Cercle_Controller : Controller
    {
        private ICercle_Service service;

        public Cercle_Controller(ICercle_Service service)
        {
            this.service = service;
        }

        // MAPPAGEEEEE

        [HttpPost]
        public Cercle_DTO Add(Cercle_DTO cercle)
        {
            return service.Add(cercle);
        }

        [HttpPost]
        [ActionName("DeleteByObject")]
        public IActionResult Delete(Cercle_DTO cercle)
        {
            return Ok(service.Delete(cercle));
        }

        [HttpPost]
        [ActionName("DeleteById")]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpGet]
        [ActionName("GetAll (lister)")]
        public IEnumerable<Cercle_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet]
        [ActionName("GetById (lire)")]
        public Cercle_DTO? GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        [ActionName("Update (modifier)")]
        public Cercle_DTO Update(Cercle_DTO cercle)
        {
            return service.Update(cercle);
        }

        [HttpPost]
        [ActionName("CalculerAirePlusieursCercles (donnez 2 cercle au moins)")]
        [SwaggerRequestExample(typeof(Cercle_DTO), typeof(Cercle_DTO_Example))]
        public double CalculerAirePlusieursCercles(params Cercle_DTO[] cercles)
        {
            var IP = HttpContext?.Connection.RemoteIpAddress?.ToString();
            IP = IP ?? "inconnue";

            return service.CalculAirePlusieursCercles(IP, cercles);
        }
    }
    public class Cercle_DTO_Example : IExamplesProvider<Cercle_DTO>
    {
        public Cercle_DTO GetExamples()
        {
            return new Cercle_DTO { Id = 1, Rayon = 5 };
        }
    }
}
