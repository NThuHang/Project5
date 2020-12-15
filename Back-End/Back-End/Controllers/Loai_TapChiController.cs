using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Loai_TapChiController : ControllerBase
    {
        private ILoai_TapChiBLL _Loai_TapChiBLL;
        public Loai_TapChiController(ILoai_TapChiBLL LoaiTapChiBLL)
        {
            _Loai_TapChiBLL = LoaiTapChiBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Loai_TapChiModel> GetDataAll()
        {
            return _Loai_TapChiBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public Loai_TapChiModel GetDatabyID(string id)
        {
            return _Loai_TapChiBLL.GetDatabyID(id);
        }

        [Route("create-Loai_TapChi")]
        [HttpPost]
        public Loai_TapChiModel CreateItem([FromBody] Loai_TapChiModel model)
        {
            _Loai_TapChiBLL.Create(model);
            return model;
        }

        [Route("delete-Loai_TapChi")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _Loai_TapChiBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-Loai_TapChi")]
        [HttpPost]
        public Loai_TapChiModel UpdateUser([FromBody] Loai_TapChiModel model)
        {
            _Loai_TapChiBLL.Update(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                long total = 0;
                var data = _Loai_TapChiBLL.Search(page, pageSize, out total, ten);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
