using System;

namespace Assignment04_ProSE
{
    public class Comment
    {
        public int Id { get; set; }
        public Participant Writer { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CommentDate { get; set; }
    }
}
