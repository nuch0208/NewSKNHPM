using System.ComponentModel.DataAnnotations;

namespace SKNHPM.Models
{
    public class MaterialStatus
    {
        [Key]
        public int MatStatusId { get; set; } 
        public string MatStatusName { get; set; }

    }
}