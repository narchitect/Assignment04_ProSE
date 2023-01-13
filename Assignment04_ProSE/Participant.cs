using System;

namespace Assignment04_ProSE
{
    public class Participant : Kitty
    {
        public Participant(int id, string link, string eventName, Currency currency, ICollection<Participant> pariticipants) : base(id, link, eventName, currency, pariticipants)
        {
        }

        public int Id { get; set; }
        public string ParticipantName { get; set; } = null!;
        public string? ParticipantEmail { get; set; }
        public int CurrentDebt { get; set; }
        public int TotalCost { get; set; }
        public bool SeenKitty { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
