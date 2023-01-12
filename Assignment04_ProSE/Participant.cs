using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_ProSE
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantEmail { get; set; }
        public ICollection<Payment>? Payments { get; set; }

        public string InvationLink { get; set; }

        //Constructor
        private Participant() { }

        //Create Participant object
        public Participant(string participantName, string participantEmail)
        {
            this.ParticipantName = participantName;
            this.ParticipantEmail = participantEmail;

        }

        // List of Participant with ICollections
        public ICollection<Participant> participantList = new List<Participant>();
    }
}
