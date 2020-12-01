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
    public class QT_CongTacController : ControllerBase
    {
        private IQT_CongTacBLL _QT_CongTacBLL;
        public QT_CongTacController(IQT_CongTacBLL QT_CongTacBLL)
        {
            _QT_CongTacBLL = QT_CongTacBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<QT_CongTacModel> GetDataAll()
        {
            return _QT_CongTacBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public QT_CongTacModel GetDatabyID(string id)
        {
            return _QT_CongTacBLL.GetDatabyID(id);
        }

        [Route("create-QT_CongTac")]
        [HttpPost]
        public QT_CongTacModel CreateItem([FromBody] QT_CongTacModel model)
        {
            model.ID_CT = Guid.NewGuid().ToString();
            _QT_CongTacBLL.Create(model);
            return model;
        }

        [Route("delete-QT_CongTac")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _QT_CongTacBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-QT_CongTac")]
        [HttpPost]
        public QT_CongTacModel UpdateUser([FromBody] QT_CongTacModel model)
        {
            _QT_CongTacBLL.Update(model);
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
                var data = _QT_CongTacBLL.Search(page, pageSize, out total, ten);
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
