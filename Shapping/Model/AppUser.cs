using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shapping.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [ForeignKey("branch")]
        public int BranchId { get; set; }
        public virtual Branches? branch { get; set; }

        [Required]
        public string Name { get; set; } 
        public bool IsDeleted { get; set; } = false;

        public Marchant? Marchant { get; set; }
    }
}
