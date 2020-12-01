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
    public class HD_SinhVien_NCKHController : ControllerBase
    {
        private IHD_SinhVien_NCKHBLL _HD_SinhVien_NCKHBLL;
        public HD_SinhVien_NCKHController(IHD_SinhVien_NCKHBLL HD_SinhVien_NCKHBLL)
        {
            _HD_SinhVien_NCKHBLL = HD_SinhVien_NCKHBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HD_SinhVien_NCKHModel> GetDataAll()
        {
            return _HD_SinhVien_NCKHBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public HD_SinhVien_NCKHModel GetDatabyID(string id)
        {
            return _HD_SinhVien_NCKHBLL.GetDatabyID(id);
        }

        [Route("create-HD_SinhVien_NCKH")]
        [HttpPost]
        public HD_SinhVien_NCKHModel CreateItem([FromBody] HD_SinhVien_NCKHModel model)
        {
            model.ID_HDSV = Guid.NewGuid().ToString();
            _HD_SinhVien_NCKHBLL.Create(model);
            return model;
        }

        [Route("delete-HD_SinhVien_NCKH")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _HD_SinhVien_NCKHBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-HD_SinhVien_NCKH")]
        [HttpPost]
        public HD_SinhVien_NCKHModel UpdateUser([FromBody] HD_SinhVien_NCKHModel model)
        {
            _HD_SinhVien_NCKHBLL.Update(model);
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
                var data = _HD_SinhVien_NCKHBLL.Search(page, pageSize, out total, ten);
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
