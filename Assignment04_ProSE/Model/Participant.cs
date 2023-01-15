using System;

namespace Assignment04_ProSE
{
    public class Participant 
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public bool Seen { get; set; }
        public bool Mark { get; set; }
        public double? Total { get; set; }
        

        public int KittyId { get; set; }
        public Kitty Kitty { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Payment> Payments { get; set; }

        public Participant(string name)
        {
            Comments = new List<Comment>();
            Payments = new List<Payment>();

            this.Name = name; 
        }

        public Participant(string name, string email) : this(name)
        {
            this.Email = email;
        }
    }
}
