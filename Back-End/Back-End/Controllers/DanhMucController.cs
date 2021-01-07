using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBLL _DanhMucBLL;
        public DanhMucController(IDanhMucBLL DanhMucBLL)
        {
            _DanhMucBLL = DanhMucBLL;
        }

        [Route("get-all/{quyen}")]
        [HttpGet]
        public IEnumerable<DanhMucModel> GetDatabAll(string quyen)
        {
            return _DanhMucBLL.GetData(quyen);
        }
    }
}
