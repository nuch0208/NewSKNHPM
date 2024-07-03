using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace SKNHPM.Models
{
    public class Poter
    {
        [Key]
        public int PoterId { get; set; }    
        public string PoterFname { get; set; }  
        public string PoterLname { get; set; }
        public string Position { get; set; }
    }
}