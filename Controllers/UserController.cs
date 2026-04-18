using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyWebApp.Models;
using MyWebApp.Services;
using MyWebApp.DTOs;
using MyWebApp.Observers;

namespace MyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
            _service.AddObserver(new UserLogger());
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_service.GetUsers());
        }

        [HttpPost]
        public IActionResult Create(UserDto dto)
        {
            _service.CreateUser(0, dto.Name, dto.Email);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
    }
}