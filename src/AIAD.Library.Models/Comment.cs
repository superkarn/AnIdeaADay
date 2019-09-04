using System;

namespace AIAD.Library.Models
{
    public class Comment : BaseWithIdModel
    {
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        public bool IsEnabled { get; set; } = true;
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
