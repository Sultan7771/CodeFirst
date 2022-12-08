using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstProject.Models
{
    public class FuelInfo
    {
        [Key]
        public int FuelId { get; set; }
        public string FuelType { get; set; }
        public decimal FuelPrice { get; set; }
    }
}
