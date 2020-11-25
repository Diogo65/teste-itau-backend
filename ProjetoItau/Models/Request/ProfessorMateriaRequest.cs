using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoItau.Models.Request
{
    public class ProfessorMateriaRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Professor Professor { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public IList<Materia> Materias { get; set; }
    }
}
