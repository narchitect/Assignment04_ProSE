using System;

namespace Assignment04_ProSE
{
	public class Kitty
	{
		public int Id { get; set; }
        public string Link { get; set; } = null!; //need to check data type of link
        public string EventName { get; set; } = null!;
        public Currency Currency { get; set; }
        public int GroupCost { get; set; }
		public ICollection<Participant> Pariticipants { get; set; } = null!;
        public ICollection<Participant> WhoSeen { get; set; } = null!;
        public ICollection<Participant>? SettledParticipants { get; set; } = new List<Participant>();
        public ICollection<Comment>? Comments { get; set; }

        public Kitty(int id, string link, string eventName, Currency currency, ICollection<Participant> pariticipants)
        {
            Id = id;
            Link = link;
            EventName = eventName;
            Currency = currency;
            Pariticipants = pariticipants;
            WhoSeen = pariticipants;
        }


        public void AddExpense (Participant sender, int Amount, ShareType shareType, string purpose, DateTime paymentDate)
        {
           
        }
    }
}