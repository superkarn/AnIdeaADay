using System;

namespace AIAD.Library.Models
{
    public class Comment : BaseWithIdModel
    {
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
