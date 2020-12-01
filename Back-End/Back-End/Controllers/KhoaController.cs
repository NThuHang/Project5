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
    public class KhoaController : ControllerBase
    {
        private IKhoaBLL _KhoaBLL;
        public KhoaController(IKhoaBLL KhoaBLL)
        {
            _KhoaBLL = KhoaBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<KhoaModel> GetDataAll()
        {
            return _KhoaBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhoaModel GetDatabyID(string id)
        {
            return _KhoaBLL.GetDatabyID(id);
        }

        [Route("create-Khoa")]
        [HttpPost]
        public KhoaModel CreateItem([FromBody] KhoaModel model)
        {
            model.ID_Khoa = Guid.NewGuid().ToString();
            _KhoaBLL.Create(model);
            return model;
        }

        [Route("delete-Khoa")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _KhoaBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-Khoa")]
        [HttpPost]
        public KhoaModel UpdateUser([FromBody] KhoaModel model)
        {
            _KhoaBLL.Update(model);
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
                var data = _KhoaBLL.Search(page, pageSize, out total, ten);
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
