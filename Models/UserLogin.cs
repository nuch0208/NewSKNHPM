

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace SKNHPM.Models

{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }  
        [Required, MinLength(8)]
        public string Password { get; set; } 
        public string Email { get; set; }   = string.Empty;
        public byte[] PasswordHash { get; set; }  = new byte[32];
        public byte[] PasswordSalt { get; set; }  = new byte[32];
        public string? VerifiedAt {get; set;}
        public string? PasswordResetToket { get; set; }
        public DateTime? ResetTokenExpires {get ; set; }
        public string DeptName { get; set; }    
        public string UserRole { get; set; }    
        public DateTime LastLogin { get; set; } 
        public DateTime DateCreate { get; set; }    
        public string Token { get; set; }
    }
}