using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningToolMVC.Models
{
    public class DefinitionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Sentence { get; set; }

        [Required]
        public string Meaning { get; set; }
    }
}
