using EFConsoleTutorial.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TodoItem : BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
