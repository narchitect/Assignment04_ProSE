using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_ProSE
{
    public class Comment
    {
        public int ID { get; set; }
        public Participant Writer { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CommentDate { get; set; }
    }
}
