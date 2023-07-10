using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.VoucherDTO
{
    public class GetUserVoucherDTO
    {
        public int VoucherId { get; set; }
        public string VoucherName { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public string? ExpiredDate { get; set; }
    }
}
