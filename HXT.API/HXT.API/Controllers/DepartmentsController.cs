using HXT.Service.Department;
using Microsoft.AspNetCore.Mvc;

namespace HXT.API.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _service.AddAllEntitiesAsync();

            return Ok();
        }
    }
}
