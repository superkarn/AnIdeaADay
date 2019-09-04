using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AIAD.Library.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;

        // This has to be string
        public string CreatedDate { get; set; }

        public ICollection<Idea> Ideas { get; set; }
    }
}
