using BusinessObject.Models;
using Repositories.DTOs.VoucherDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.VoucherRepositories
{
    public interface IVoucherRepository
    {
        List<Voucher> GetAll();
        List<GetUserVoucherDTO> GetVouchersByUserId(int userId);
        bool BuyVoucher(BuyingDTO buyer);
        bool CreateVoucher(CreateVoucherDTO voucher);
        bool DeleteVoucher(int voucherId);
    }
}
