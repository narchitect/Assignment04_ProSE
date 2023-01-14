using System;

namespace Assignment04_ProSE
{
    public class Participant 
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }
        public bool Seen { get; set; }
        public double Total { get; set; }
        public double CurrentDebt { get; set; }

        public int KittyId { get; set; }
        public Kitty Kitty { get; set; }

        //public int PaymentParticipantId { get; set; }
        //public List<PaymentParticipants> PaymentParticipants { get; set; }

        public Participant()
        {
        }


    }
}
