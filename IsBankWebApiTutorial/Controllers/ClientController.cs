using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{
    //bir user api/client dedigi an bu controller icerisine duser
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        List<string> clients;

        public ClientController()
        {
            clients = new List<string>() { "Cagatay", "Ali", "Muge" };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(clients);
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            clients.Add(name);

            return Ok(clients);
        }

    }
}