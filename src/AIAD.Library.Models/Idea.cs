using AIAD.Library.Models.LookUp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIAD.Library.Models
{
    public class Idea : BaseWithIdModel
    {
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public int PrivacyId { get; set; } = 1;
        public IdeaPrivacy Privacy { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Comment> Comments { get; set; }
    }
}
