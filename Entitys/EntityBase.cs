using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiFinanciera.Entitys
{
    public abstract class EntityBase
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
