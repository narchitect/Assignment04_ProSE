using System;

namespace Assignment04_ProSE
{
    public class Payment : Participant
    {
        public Payment(int id, string link, string eventName, Currency currency, ICollection<Participant> pariticipants) : base(id, link, eventName, currency, pariticipants)
        {
        }

        public int Id { get; set; }
        public int Amount { get; set; }
        public string Purpose { get; set; } = null!;
        public Participant Sender { get; set; } = null!;
        public ICollection<Participant> Receivers { get; set; } = null!;
        public ShareType ShareType { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }

        pubic 

        public void SetReceiver(Kitty AEvent)
        {
            if (PaymentType == PaymentType.Expense || PaymentType == PaymentType.Income)
            {
                Receivers = AEvent.Pariticipants;
            }
            else if (PaymentType == PaymentType.MoneyGiven)
            {
                Receivers = 
            }
        }
    }
}