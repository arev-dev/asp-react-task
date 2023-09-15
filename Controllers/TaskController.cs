using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactProject.models;
using Task = ReactProject.models.Task;

namespace ReactProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController:ControllerBase
    {
        private readonly BdtasksContext _dbContext;

        public TaskController(BdtasksContext context){
            _dbContext = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(){
            List<Task> lista = _dbContext.Tasks.OrderByDescending(t => t.Id).ThenBy(t => t.CreatedAt).ToList();
            
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("Get/{Id:int}")]
        public async Task<IActionResult> Get_by_id(int id){
            Task t = _dbContext.Tasks.Find(id);
            
            return StatusCode(StatusCodes.Status200OK, t);
        }

        // Task nuevo = new Task(){
        //         Id = modelo.Id,
        //         Title = modelo.Title,
        //         Description = modelo.Description,
        //         CreatedAt = modelo.CreatedAt,
        //         TypeTask = modelo.TypeTask
        //     };

        //     bool response = await _dbContext.SaveChangesAsync(nuevo);

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Task modelo){
            
            await _dbContext.Tasks.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new {res="OK"});
        }

        
        [HttpDelete]
        [Route("Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int id){
            
            Task t =_dbContext.Tasks.Find(id);
            _dbContext.Tasks.Remove(t);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new {res="OK"});
        }
    }
}