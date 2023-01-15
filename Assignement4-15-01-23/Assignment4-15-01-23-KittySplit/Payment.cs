using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_15_01_23_KittySplit
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
