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
    public class SoHuu_TriTueController : ControllerBase
    {
        private ISoHuu_TriTueBLL _SoHuu_TriTueBLL;
        public SoHuu_TriTueController(ISoHuu_TriTueBLL SoHuu_TriTueBLL)
        {
            _SoHuu_TriTueBLL = SoHuu_TriTueBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SoHuu_TriTueModel> GetDataAll()
        {
            return _SoHuu_TriTueBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SoHuu_TriTueModel GetDatabyID(string id)
        {
            return _SoHuu_TriTueBLL.GetDatabyID(id);
        }

        [Route("create-SoHuu_TriTue")]
        [HttpPost]
        public SoHuu_TriTueModel CreateItem([FromBody] SoHuu_TriTueModel model)
        {
            model.ID_TriTue = Guid.NewGuid().ToString();
            _SoHuu_TriTueBLL.Create(model);
            return model;
        }

        [Route("delete-SoHuu_TriTue")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _SoHuu_TriTueBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-SoHuu_TriTue")]
        [HttpPost]
        public SoHuu_TriTueModel UpdateUser([FromBody] SoHuu_TriTueModel model)
        {
            _SoHuu_TriTueBLL.Update(model);
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
                var data = _SoHuu_TriTueBLL.Search(page, pageSize, out total, ten);
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
