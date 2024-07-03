
using System.ComponentModel.DataAnnotations;

namespace SKNHPM.Models
{
    public class Urgent
    {
        [Key]
        public int UrgentId { get; set; }
        public string   UrgentType { get; set;}    
    }
}