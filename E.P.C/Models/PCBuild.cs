using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E.P.C.Models
{
    public class PCBuild
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BuildName { get; set; }

        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }

        // Link to the user
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
