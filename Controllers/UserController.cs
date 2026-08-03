using Microsoft.AspNetCore.Mvc;
using StreamingSubscriptionTrackerAPI.Services;

namespace StreamingSubscriptionTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        []

    }
}
