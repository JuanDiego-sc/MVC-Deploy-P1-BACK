using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreEnriqueMerizalde.Models;

namespace MiniCoreEnriqueMerizalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private readonly DbContextMinicore _dbcontext;
        public ProyectoController(DbContextMinicore dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetProyectos")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            return await _dbcontext.Proyectos.ToListAsync();
        }
    }
}
