using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoItau.Data;
using ProjetoItau.Models;
using ProjetoItau.Models.Request;

namespace ProjetoItau.Controllers
{
    [ApiController]
    [Route("v1/Professor")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> Get([FromServices] DataContext context)
        {
            var professores = await context.Professores
                .ToListAsync();
            return professores;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Professor>> GetById([FromServices] DataContext context, int id)
        {
            var professor = await context.Professores
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return professor;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Professor>> Post(
            [FromServices] DataContext context,
            [FromBody] Professor model)
        {
            if (ModelState.IsValid)
            {
                context.Professores.Add(model);
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
            [FromBody] ProfessorRequest model)
        {
            if (ModelState.IsValid)
            {
                var professor = await context.Professores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                context.Professores.Remove(professor);
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
