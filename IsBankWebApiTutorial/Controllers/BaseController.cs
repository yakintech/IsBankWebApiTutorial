using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
       
    }
}
