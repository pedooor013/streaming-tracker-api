using Microsoft.AspNetCore.Mvc;
using StreamingSubscriptionTrackerAPI.Models;
using StreamingSubscriptionTrackerAPI.Services;
using StreamingSubscriptionTrackerAPI.DTOs;

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

        [HttpGet("username/{username}")]
        public IActionResult GetByUsername(string username)
        {
            return Ok(_userService.GetByUsername(username));
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return Ok(_userService.GetByEmail(email));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetByActived(bool actived)
        {
            return Ok(_userService.GetByActived(actived));
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserRequestDTO userDto)
        {
            try
            {
                var createdUser = _userService.Create(userDto);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(long id, [FromBody] UserRequestDTO userDto)
        {
            try
            {
                var updatedUser = _userService.Update(id, userDto);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/actived/{id}")]
        public IActionResult UpdateActived(long id, [FromBody] bool actived)
        {
            try
            {
                var updatedUser = _userService.UpdateActived(id, actived);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var deletedUser = _userService.Delete(id);
                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
