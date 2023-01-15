using System;

namespace Assignment04_ProSE
{
    public class Payment
    {
        public int Id { get; set; }
        public string Purpose { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; } = null!;
    }


}