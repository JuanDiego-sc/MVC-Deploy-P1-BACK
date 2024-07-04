using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MiniCoreEnriqueMerizalde.Controllers;

namespace MiniCoreEnriqueMerizalde.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly DbContextMinicore _context;

        public TasksController(DbContextMinicore context)
        {
            _context = context;
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueTasks([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var tasks = await _context.Tareas
                .Include(t => t.Empleado)
                .Include(t => t.Proyecto)
                .Where(t => t.Estado_Tarea == "In progress")
                .ToListAsync();

            var overdueTasks = tasks
                .Select(t => new
                {
                    t.Empleado.Nombre_Empleado,
                    t.Empleado.Apellido_Empleado,
                    t.Descripcion_Tarea,
                    t.Fecha_Inicio_Tarea,
                    t.Tiempo_Estimado_Tarea,
                    t.Proyecto.Nombre_Proyecto,
                    CalculatedEndDate = t.Fecha_Inicio_Tarea.AddWeekdays(t.Tiempo_Estimado_Tarea),
                    DaysOverdue = (endDate > t.Fecha_Inicio_Tarea.AddWeekdays(t.Tiempo_Estimado_Tarea))
                        ? DateExtensions.GetWeekdaysBetween(t.Fecha_Inicio_Tarea.AddWeekdays(t.Tiempo_Estimado_Tarea), endDate)
                        : 0 
                })
                .Where(t => t.CalculatedEndDate < endDate && t.DaysOverdue > 0)
                .ToList();

            return Ok(overdueTasks);
        }
    }
}

