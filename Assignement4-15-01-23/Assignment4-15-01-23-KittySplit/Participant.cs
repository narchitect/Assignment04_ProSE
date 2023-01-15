using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_15_01_23_KittySplit
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }
        public bool Seen { get; set; }
        public bool Mark { get; set; }
        public double Total { get; set; }


        public int KittyId { get; set; }
        public Kitty Kitty { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Payment> Payments { get; set; }

        public Participant()
        {
            Comments = new List<Comment>();
            Payments = new List<Payment>();
        }
    }
}
