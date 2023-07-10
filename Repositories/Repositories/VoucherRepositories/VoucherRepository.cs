using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.VoucherDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.VoucherRepositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;
        public VoucherRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Voucher> GetAll()
        {
            return _context.Vouchers.Where(v => v.Quantity > 0 && v.Status == 1).ToList();
        }

        public List<GetUserVoucherDTO> GetVouchersByUserId(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {

                var listVoucher = _context.UserVouchers.Where(u => u.UserId == userId).ToList();
                foreach (var voucher in listVoucher)
                {
                    if (voucher.ExpiredDay.Date == DateTime.Now.Date)
                    {
                        _context.UserVouchers.Remove(voucher);
                        _context.SaveChanges();
                    }
                }
                return (from uv in _context.UserVouchers
                        join v in _context.Vouchers on uv.VoucherId equals v.VoucherId
                        where uv.UserId == userId && v.Status == 1
                        select new GetUserVoucherDTO
                        {
                            VoucherId = v.VoucherId,
                            VoucherName = v.VoucherName,
                            Description = v.Description,
                            Logo = v.Logo,
                            ExpiredDate = uv.ExpiredDay.ToString("dd/MM/yyyy"),
                        }).ToList();
            }
            return null;
        }

        public bool CreateVoucher(CreateVoucherDTO voucher)
        {
            var newVoucher = _mapper.Map<Voucher>(voucher);
            newVoucher.Status = 1;
            _context.Vouchers.Add(newVoucher);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteVoucher(int voucherId)
        {
            var voucher = _context.Vouchers.Find(voucherId);
            if (voucher != null)
            {
                _context.Vouchers.Remove(voucher);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool BuyVoucher(BuyingDTO buyer)
        {
            var voucher = _context.Vouchers.Find(buyer.VoucherId);
            var user = _context.Users.Find(buyer.UserId);
            if (user == null || voucher == null) return false;
            var newValue = user.Point - voucher.Price;
            if (newValue < 0) return false;
            user.Point -= voucher.Price;
            voucher.Quantity -= 1;
            _context.UserVouchers.Add(new UserVoucher
            {
                VoucherId = buyer.VoucherId,
                UserId = buyer.UserId,
                ExpiredDay = DateTime.Now.AddMonths(1),
            });
            _context.SaveChanges();
            return true;
        }
    }
}
