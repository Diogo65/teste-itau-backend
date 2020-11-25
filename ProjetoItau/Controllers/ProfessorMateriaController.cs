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
    [Route("v1/ProfessorMateria")]
    public class ProfessorMateriaController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AdicionarMateriaAoProfessor(
            [FromServices] DataContext context,
            [FromBody] ProfessorMateriaRequest model)
        {
            if (ModelState.IsValid)
            {
                foreach (var materia in model.Materias)
                {
                    ProfessorMateria professorMateria = new ProfessorMateria()
                    {
                        Professor = model.Professor,
                        Materia = materia
                    };

                    context.ProfessoresMaterias.Add(professorMateria);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok("Foi adicionado novas matéria para o professor " + model.Professor.Nome);
        }

        [HttpGet]
        [Route("professor/{id:int}")]
        public async Task<ActionResult<List<ProfessorMateria>>> GetByProfessor([FromServices] DataContext context, int id)
        {
            var professorMateria = await context.ProfessoresMaterias
                .Include(x => x.Materia)
                .AsNoTracking()
                .Where(x => x.ProfessorId == id)
                .ToListAsync();
            return professorMateria;
        }

        [HttpGet]
        [Route("materia/{id:int}")]
        public async Task<ActionResult<List<ProfessorMateria>>> GetByMateria([FromServices] DataContext context, int id)
        {
            var professorMateria = await context.ProfessoresMaterias
                .Include(x => x.Professor)
                .AsNoTracking()
                .Where(x => x.MateriaId == id)
                .ToListAsync();
            return professorMateria;
        }
    }
}
