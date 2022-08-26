using EFConsoleTutorial.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courses : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Students> Students { get; set; } = default!;
    }
}
