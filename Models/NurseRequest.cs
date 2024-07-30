using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace SKNHPM.Models;

public class NurseRequest
{
    
    [Key]
    public int  JobId   { get; set; } 
    public DateTime ReqTime { get; set; }
    public DateTime EndTime { get; set; }  
    public DateTime? CreateDate { get; set;} = DateTime.UtcNow; 
   
    public int UserId { get; set; }
   
    public string? DeptName { get; set; }  
   
    public string? StartPoint { get; set; }
   
    public string? EndPoint1 { get; set; } 
   
    public string? EndPoint2 { get; set; }   
  
    public string? EndPoint3 { get; set; } 
     
    public string? EndPoint4 { get; set; } 

    public string? JobStatusName { get; set; }
 
    public string? MaterialType { get; set; }   
  
    public string? UrgentType { get; set; }   
  
    public string? PatientType { get; set; } 
   
    public string? PoterFname { get; set; }  
    public string? Remark { get; set; }  
    public int QN { get; set; }
    public string? QNName { get; set; }  
    public string? QNAge { get; set; }   
    public string? QNSex { get; set; }   
}
