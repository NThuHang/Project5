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
    public class TinHocController : ControllerBase
    {
        private ITinHocBLL _TinHocBLL;
        public TinHocController(ITinHocBLL TinHocBLL)
        {
            _TinHocBLL = TinHocBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TinHocModel> GetDataAll()
        {
            return _TinHocBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TinHocModel GetDatabyID(string id)
        {
            return _TinHocBLL.GetDatabyID(id);
        }

        [Route("create-TinHoc")]
        [HttpPost]
        public TinHocModel CreateItem([FromBody] TinHocModel model)
        {
            model.ID_TH = Guid.NewGuid().ToString();
            _TinHocBLL.Create(model);
            return model;
        }

        [Route("delete-TinHoc")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _TinHocBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-TinHoc")]
        [HttpPost]
        public TinHocModel UpdateUser([FromBody] TinHocModel model)
        {
            _TinHocBLL.Update(model);
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
                var data = _TinHocBLL.Search(page, pageSize, out total, ten);
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
