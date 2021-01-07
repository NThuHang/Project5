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
    public class BaoChiController : ControllerBase
    {
        private IBaoChiBLL _BaoChiBLL;
        public BaoChiController(IBaoChiBLL BaoChiBLL)
        {
            _BaoChiBLL = BaoChiBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<BaoChiModel> GetDataAll()
        {
            return _BaoChiBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public BaoChiModel GetDatabyID(string id)
        {
            return _BaoChiBLL.GetDatabyID(id);
        }
        [Route("get-by-bbao/{id}")]
        [HttpGet]
        public IEnumerable<BaoChiModel> GetDataBao(string id)
        {
            return _BaoChiBLL.GetDataBao(id);
        }

        [Route("create-baochi")]
        [HttpPost]
        public BaoChiModel CreateItem([FromBody] BaoChiModel model)
        {
            model.ID_BBao = Guid.NewGuid().ToString();
            _BaoChiBLL.Create(model);
            return model;
        }

        [Route("delete-baochi")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _BaoChiBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-baochi")]
        [HttpPost]
        public BaoChiModel UpdateUser([FromBody] BaoChiModel model)
        {
            _BaoChiBLL.Update(model);
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
                var data = _BaoChiBLL.Search(page, pageSize, out total, ten);
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
