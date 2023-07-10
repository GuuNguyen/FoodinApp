using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.VoucherDTO;
using Repositories.Repositories.VoucherRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _repo;

        public VoucherController(IVoucherRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("ByUser/{userId}")]
        public IActionResult GetVouchersByUserId(int userId)
        {
            return Ok(_repo.GetVouchersByUserId(userId));
        }

        [HttpPost]
        public IActionResult CreateVoucher(CreateVoucherDTO voucher)
        {
            var isSuccess = _repo.CreateVoucher(voucher);
            return isSuccess ? Ok(isSuccess) : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher(int id)
        {
            var isSuccess = _repo.DeleteVoucher(id);
            return isSuccess ? Ok(isSuccess) : BadRequest();
        }

        [HttpPost("BuyVoucher")]
        public IActionResult BuyVoucher(BuyingDTO buyer)
        {
            var isSuccess = _repo.BuyVoucher(buyer);
            return isSuccess ? Ok(isSuccess) : BadRequest();
        }
    }
}
