using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace SKNHPM.Models;

public class NurseRequest
{
    
    [Key]
    public int  JobId   { get; set; } 
    public DateTime? ReqTime { get; set; }
    public DateTime? EndTime { get; set; }   
   
    public int? UserId { get; set; }
   
    public string? DeptName { get; set; }  = string.Empty;
   
    public string? StartPoint { get; set; }  = string.Empty;
   
    public string? EndPoint1 { get; set; } = string.Empty;
   
    public string? EndPoint2 { get; set; }    = string.Empty;
  
    public string? EndPoint3 { get; set; } = string.Empty;
     
    public string? EndPoint4 { get; set; } = string.Empty;

    public string? JobStatusName { get; set; }= string.Empty;
 
    public string? MaterialType { get; set; }    = string.Empty;
  
    public string? UrgentType { get; set; }   = string.Empty;
  
    public string? PatientType { get; set; } = string.Empty;
   
    public string? PoterFname { get; set; }  = string.Empty;
    public string? Remark { get; set; }  = string.Empty;
    public int QN { get; set; }
    public string? QNName { get; set; }  = string.Empty;
    public string? QNAge { get; set; }   = string.Empty;
    public string? QNSex { get; set; }   = string.Empty;
}
