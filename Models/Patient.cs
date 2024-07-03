using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace SKNHPM.Models
{
    public class Patient
    {
        [Key]
        public int PatienId { get; set; }   
        public string MyProperty { get; set; }
    }
}