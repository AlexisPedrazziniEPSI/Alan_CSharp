using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;
using Geometrie.DTO;

namespace Geometrie.API.Controllers
{
    public class Point_Controller : Controller
    {
        private Point_Service service;

        [HttpPost]
        public IActionResult Add(Point_DTO point)
        {
            return Ok(service.Add(point));
        }

        [HttpPost]
        public IActionResult Delete(Point_DTO point)
        {
            return Ok(service.Delete(point));
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Ok(service.Delete(Id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(int Id) {
            return Ok(service.GetById(Id));
        }

        [HttpPost]
        public IActionResult Update(Point_DTO point)
        {
            return Ok(service.Update(point));
        }

        public Point_Controller(Point_Service service)
        {
            ArgumentNullException.ThrowIfNull(service, nameof(service));

            this.service = service;
        }
    }
}
