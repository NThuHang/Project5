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
    public class HoiThaoKhoaHocController : ControllerBase
    {
        private IHoiThaoKhoaHocBLL _HoiThaoKhoaHocBLL;
        public HoiThaoKhoaHocController(IHoiThaoKhoaHocBLL HoiThaoKhoaHocBLL)
        {
            _HoiThaoKhoaHocBLL = HoiThaoKhoaHocBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HoiThaoKhoaHocModel> GetDataAll()
        {
            return _HoiThaoKhoaHocBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public HoiThaoKhoaHocModel GetDatabyID(string id)
        {
            return _HoiThaoKhoaHocBLL.GetDatabyID(id);
        }

        [Route("create-HoiThaoKhoaHoc")]
        [HttpPost]
        public HoiThaoKhoaHocModel CreateItem([FromBody] HoiThaoKhoaHocModel model)
        {
            model.ID_HoiThao = Guid.NewGuid().ToString();
            _HoiThaoKhoaHocBLL.Create(model);
            return model;
        }

        [Route("delete-HoiThaoKhoaHoc")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _HoiThaoKhoaHocBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-HoiThaoKhoaHoc")]
        [HttpPost]
        public HoiThaoKhoaHocModel UpdateUser([FromBody] HoiThaoKhoaHocModel model)
        {
            _HoiThaoKhoaHocBLL.Update(model);
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
                var data = _HoiThaoKhoaHocBLL.Search(page, pageSize, out total, ten);
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
