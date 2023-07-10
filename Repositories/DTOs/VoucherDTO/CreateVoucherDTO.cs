using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.VoucherDTO
{
    public class CreateVoucherDTO
    {
        public string VoucherName { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
