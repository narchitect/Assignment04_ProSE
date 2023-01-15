using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_15_01_23_KittySplit
{
    public class Kitty
    {
        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public Currency HomeCurrency { get; set; }
        public string Link { get; set; }
        public double GroupCost { get; set; }

        public List<Participant> Pariticipants { get; set; } = null!;

        public Kitty()
        {
            this.Pariticipants = new List<Participant>();
        }

        //public Kitty(string eventName) : this()
        //{
        //    this.EventName = eventName;
        //}      


    }
}
