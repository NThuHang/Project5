using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;


namespace Back_End.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBLL _taiKhoanBLL;
        public TaiKhoanController(ITaiKhoanBLL taiKhoanBLL)
        {
            _taiKhoanBLL = taiKhoanBLL;
        }

        [AllowAnonymous]
        [HttpPost("xacthuctk")]
        public IActionResult XacThuc([FromBody] XacThucTaiKhoanModel model)
        {
            var taikhoan = _taiKhoanBLL.XacThuc(model.Username, model.Password);

            if (taikhoan == null)
                return BadRequest(new { message = "Tên đăng nhập hoặc tài khoản của bạn không chính xác" });

            return Ok(taikhoan);
        }
        
    }
}
