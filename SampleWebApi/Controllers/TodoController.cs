using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Model;
using SampleWebApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private SampleContext _context;

        public TodoController(SampleContext context) 
        { 
            this._context = context;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Todos);
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Todo _todo = _context.Todos.FirstOrDefault(x => x.Id == id);

            if (_todo == null)
                return NotFound();  

            return Ok(_todo);
        }

        // POST api/<TodoController>
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Created();
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Todo todoNewData)
        {
            var _todo = _context.Todos.FirstOrDefault(x => x.Id == id);

            if (_todo == null)
                return NotFound();

            _todo.Title = todoNewData.Title;
            _todo.Description = todoNewData.Description;


            _context.Todos.Update(_todo);
            _context.SaveChanges();

            return Ok();

        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _todo = _context.Todos.FirstOrDefault(x => x.Id == id);

            if (_todo == null)
                return NotFound();

            _context.Todos.Remove(_todo);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
