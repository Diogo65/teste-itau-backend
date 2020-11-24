using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoItau.Models
{
    public class ProfessorMateria
    {
        [Key]
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}
