using System;

namespace Assignment04_ProSE
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime dateTime { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; } = null!;
    }
}
