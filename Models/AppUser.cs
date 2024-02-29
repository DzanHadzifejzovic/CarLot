using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCAssign1.Models
{
    public class AppUser : IdentityUser  
    { 
        [Range(18,99)]
        public int? Age { get; set; }
        public string? Country { get; set; }

    }
}
