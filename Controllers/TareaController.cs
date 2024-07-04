using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreEnriqueMerizalde.Models;

namespace MiniCoreEnriqueMerizalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly DbContextMinicore _dbcontext;
        public TareaController(DbContextMinicore dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //
        [HttpGet]
        [Route("GetTareas")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTarea()
        {
            return await _dbcontext.Tareas.ToListAsync();
        }
    }
}
