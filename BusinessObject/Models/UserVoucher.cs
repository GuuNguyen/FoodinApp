using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class UserVoucher
    {
        public int UserId { get; set; }
        public int VoucherId { get; set; }
        public DateTime ExpiredDay { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Voucher Voucher { get; set; } = null!;
    }
}
