using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SKNHPM.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}