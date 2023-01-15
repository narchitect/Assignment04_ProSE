using System;

namespace Assignment04_ProSE
{
	public class Kitty
	{
		public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public Currency HomeCurrency { get; set; }
        public string Link { get; set; }
        public double GroupCost { get; set; }

		public List<Participant> Participants { get; set; } = null!;

        public Kitty (string eventName, Currency homeCurrency, List<string> participantsNames)
        {
            this.Participants = new List<Participant>();

            this.EventName = eventName;
            this.HomeCurrency = homeCurrency;

            foreach (string p in participantsNames)
            {
                Participants.Add(new Participant(p));
            }
        }

        public Kitty(string eventName, Currency homeCurrency, List<string> participantsNames, string creatorEmail)
            : this(eventName, homeCurrency, participantsNames)
        {
            this.Participants[0].Email = creatorEmail;
        }
    }
}