using System;
using System.ComponentModel.DataAnnotations;

namespace InAndOutControl.Models
{
    public class Visitor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public int PassportNumber { get; set; }
    }
}