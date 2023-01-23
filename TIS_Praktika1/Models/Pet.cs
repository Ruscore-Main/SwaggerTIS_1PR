using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TIS_Praktika1.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Int16 Age { get; set; }
        public bool IsVaccinated { get; set; }
    }
}
