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

        // Core components (store names or IDs depending on your DB design)
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string Motherboard { get; set; }
        public string PSU { get; set; }
        public string Case { get; set; }

        // ✅ Case cooling (always allowed)
        public string Fan { get; set; }

        // ❗ CPU cooling (mutually exclusive choice)
        public string CPUFan { get; set; }
        public string AIO { get; set; }

        // Optional: store total price for saved builds
        public double TotalPrice { get; set; }

        // Link to user
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}