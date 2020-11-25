using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoItau.Data;
using ProjetoItau.Models;
using ProjetoItau.Models.Request;

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
            [FromBody] Materia model)
        {
            if (ModelState.IsValid)
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

        [HttpPost]
        [Route("excluir")]
        public async Task<ActionResult<bool>> Exluir(
            [FromServices] DataContext context,
            [FromBody] MateriaRequest model)
        {
            if (ModelState.IsValid)
            {
                var materia = await context.Materias
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                context.Materias.Remove(materia);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
    
}
