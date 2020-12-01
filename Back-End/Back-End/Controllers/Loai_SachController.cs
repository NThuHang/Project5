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
    public class Loai_SachController : ControllerBase
    {
        private ILoai_SachBLL _Loai_SachBLL;
        public Loai_SachController(ILoai_SachBLL Loai_SachBLL)
        {
            _Loai_SachBLL = Loai_SachBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Loai_SachModel> GetDataAll()
        {
            return _Loai_SachBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public Loai_SachModel GetDatabyID(string id)
        {
            return _Loai_SachBLL.GetDatabyID(id);
        }

        [Route("create-Loai_Sach")]
        [HttpPost]
        public Loai_SachModel CreateItem([FromBody] Loai_SachModel model)
        {
            model.ID_LoaiSach = Guid.NewGuid().ToString();
            _Loai_SachBLL.Create(model);
            return model;
        }

        [Route("delete-Loai_Sach")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _Loai_SachBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-Loai_Sach")]
        [HttpPost]
        public Loai_SachModel UpdateUser([FromBody] Loai_SachModel model)
        {
            _Loai_SachBLL.Update(model);
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
                var data = _Loai_SachBLL.Search(page, pageSize, out total, ten);
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
