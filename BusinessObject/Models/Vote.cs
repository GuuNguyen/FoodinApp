using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public bool IsHelpful { get; set; }

        public virtual Review Review { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
