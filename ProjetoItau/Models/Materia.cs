using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoItau.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve contrer menos de 60 caracteres")]
        public string Nome { get; set; }
        private IList<ProfessorMateria> Professores { get; set; }

    }
}
