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
    public class TapChiController : ControllerBase
    {
        private ITapChiBLL _TapChiBLL;
        public TapChiController(ITapChiBLL TapChiBLL)
        {
            _TapChiBLL = TapChiBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TapChiModel> GetDataAll()
        {
            return _TapChiBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TapChiModel GetDatabyID(string id)
        {
            return _TapChiBLL.GetDatabyID(id);
        }
        [Route("get-by-loai/{id}")]
        [HttpGet]
        public IEnumerable<TapChiModel> GetbyIDLoai(string id)
        {
            return _TapChiBLL.GetbyIDLoai(id);
        }

        [Route("create-tapchi")]
        [HttpPost]
        public TapChiModel CreateItem([FromBody] TapChiModel model)
        {
            _TapChiBLL.Create(model);
            return model;
        }

        [Route("delete-tapchi")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string tc_id = "";
            if (formData.Keys.Contains("tc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["tc_id"]))) { tc_id = Convert.ToString(formData["tc_id"]); }
            _TapChiBLL.Delete(tc_id);
            return Ok();
        }

        [Route("update-tapchi")]
        [HttpPost]
        public TapChiModel UpdateUser([FromBody] TapChiModel model)
        {
            _TapChiBLL.Update(model);
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
                var data = _TapChiBLL.Search(page, pageSize, out total, ten);
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
