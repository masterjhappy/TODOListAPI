using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOListAPI.Application.Interface;
using TODOListAPI.Models;

namespace TODOListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Todo item)
        {
            return Ok(_todoService.Add(item));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo item)
        {
            if(id != item.Id)
            {
                return BadRequest();
            }
            return _todoService.Update(item) ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            return _todoService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
