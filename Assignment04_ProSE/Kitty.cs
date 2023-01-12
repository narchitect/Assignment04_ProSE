using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_ProSE
{
    public class Kitty
    {
        public int KittyId { get; set; }
        public string EventName { get; set; }
        public string Currency { get; set; }
        public ICollection<Participant>? Participants { get; set; }


        private Kitty() { }
        public Kitty(string eventName, string currency)
        {
            this.EventName = eventName;
            this.Currency = currency;
        }
        public void CreateKitty(string eventName, string currency, Participant participant)
        {
            // Initialize creating one database for each Kitty

        }
    }
}
