using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreEnriqueMerizalde.Models;

namespace MiniCoreEnriqueMerizalde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly DbContextMinicore _dbcontext;
        public EmpleadoController(DbContextMinicore dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetEmpleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _dbcontext.Empleados.ToListAsync();
        }
    }
}

