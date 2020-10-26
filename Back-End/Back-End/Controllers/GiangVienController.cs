using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private IGiangVienBLL _GiangVienBLL;
        public GiangVienController(IGiangVienBLL GiangVienBLL)
        {
            _GiangVienBLL = GiangVienBLL;
        }
        
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetDatabAll()
        {
            return _GiangVienBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public GiangVienModel GetDatabyID(string id)
        {
            return _GiangVienBLL.GetDatabyID(id);
        }

        [Route("create-gv")]
        [HttpPost]
        public GiangVienModel CreateItem([FromBody] GiangVienModel model)
        {
            _GiangVienBLL.Create(model);
            return model;
        }

        [Route("delete-user")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string gv_id = "";
            if (formData.Keys.Contains("gv_id") && !string.IsNullOrEmpty(Convert.ToString(formData["gv_id"]))) { gv_id = Convert.ToString(formData["gv_id"]); }
            _GiangVienBLL.Delete(gv_id);
            return Ok();
        }

        [Route("update-user")]
        [HttpPost]
        public GiangVienModel UpdateUser([FromBody] GiangVienModel model)
        {
            _GiangVienBLL.Update(model);
            return model;
        }


    }
}
