using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoItau.Data;
using ProjetoItau.Models;

namespace ProjetoItau.Controllers
{
    [ApiController]
    [Route("v1/Materia")]
    public class MateriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Materia>>> Get([FromServices] DataContext context)
        {
            var materias = await context.Materias.ToListAsync();
            return materias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Materia>> Post(
            [FromServices] DataContext context,
            [FromBody]Materia model)
        {
            if(ModelState.IsValid)
            {
                context.Materias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
