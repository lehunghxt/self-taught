using HXT.RabitMQ;
using HXT.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace HXT.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public UsersController(UserService service, IRabbitMQProducer rabbitMQProducer)
        {
            _service = service;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _service.Get();
            return Ok(users);
        }

        [HttpGet]
        [Route("mq")]
        public async Task<ActionResult> RabitMQ()
        {
            var users = await _service.Get();
            _rabbitMQProducer.SendProductMessage(users);
            return Ok(users);
        }
    }
}
