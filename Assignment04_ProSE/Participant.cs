using System;

namespace Assignment04_ProSE
{
    public class Participant
    {
        public int Id { get; set; }
        public string ParticipantName { get; set; } = null!;
        public string? ParticipantEmail { get; set; }
        public int CurrentDebt { get; set; }
        public int TotalCost { get; set; }
        public bool SeenKitty { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }
}
