using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningToolMVC.Models
{
    public class AttemptModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Attempt { get; set; }
        public bool IsCorrect { get; set; }

        public int DefinitionId { get; set; }
        public DefinitionModel Definition { get; set; }

        internal void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
