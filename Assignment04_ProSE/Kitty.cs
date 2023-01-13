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
        public ICollection<Participant>? SettledDebts { get; set; }
        public ICollection<Comment>? Comments { get; set; }

        public Kitty()
		{
		}
	}
}