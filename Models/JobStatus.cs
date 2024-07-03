using System.ComponentModel.DataAnnotations;

namespace SKNHPM.Models
{
    public class JobStatus
    {
        [Key]
        public int JobStatusId { get; set; }
        public string JobStatusName { get; set; }   
    }
}