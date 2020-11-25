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
        public async Task<ActionResult<bool>> AdicionarMateriaAoProfessor(
        [FromServices] DataContext context,
        [FromBody] ProfessorMateriaRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var validProfessorMateria = await context.ProfessoresMaterias
                    .Include(x => x.Professor)
                    .AsNoTracking()
                    .Where(x => x.MateriaId == model.MateriaId && 
                    x.ProfessorId == model.ProfessorId)
                    .FirstOrDefaultAsync();

                    if(validProfessorMateria == null)
                    {
                        ProfessorMateria professorMateria = new ProfessorMateria()
                        {
                            ProfessorId = model.ProfessorId,
                            MateriaId = model.MateriaId
                        };

                        context.ProfessoresMaterias.Add(professorMateria);
                        await context.SaveChangesAsync();

                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }

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
