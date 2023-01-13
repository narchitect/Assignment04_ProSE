using System;

namespace Assignment04_ProSE
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Purpose { get; set; } = null!;
        public Participant Sender { get; set; } = null!;
        public Participant Receiver { get; set; } = null!;
        public ShareType ShareType { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}