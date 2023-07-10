using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            UserVouchers = new HashSet<UserVoucher>();
        }

        public int VoucherId { get; set; }
        public string VoucherName { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
