using System.ComponentModel.DataAnnotations;

namespace SKNHPM.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptBuilding { get; set; }   
        public int DeptPhone { get; set; }
        public string DeptFloor { get; set; }

    }
}