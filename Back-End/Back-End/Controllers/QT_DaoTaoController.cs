using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QT_DaoTaoController : ControllerBase
    {
        private IQT_DaoTaoBLL _QT_DaoTaoBLL;
        public QT_DaoTaoController(IQT_DaoTaoBLL QT_DaoTaoBLL)
        {
            _QT_DaoTaoBLL = QT_DaoTaoBLL;
        }

        [Route("get-all/{id}")]
        [HttpGet]
        public IEnumerable<QT_DaoTaoModel> GetDatabAll_GV(string id)
        {
            return _QT_DaoTaoBLL.GetData_GV(id);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public QT_DaoTaoModel GetDatabyID(string id)
        {
            return _QT_DaoTaoBLL.GetDatabyID(id);
        }
        [Route("create-daotao")]
        [HttpPost]
        public QT_DaoTaoModel CreateItem([FromBody] QT_DaoTaoModel model)
        {
            _QT_DaoTaoBLL.Create(model);
            return model;
        }

        [Route("delete-daotao")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string dt_id = "";
            if (formData.Keys.Contains("dt_id") && !string.IsNullOrEmpty(Convert.ToString(formData["dt_id"]))) { dt_id = Convert.ToString(formData["dt_id"]); }
            _QT_DaoTaoBLL.Delete(dt_id);
            return Ok();
        }

        [Route("update-daotao")]
        [HttpPost]
        public QT_DaoTaoModel UpdateUser([FromBody] QT_DaoTaoModel model)
        {
            _QT_DaoTaoBLL.Update(model);
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
                var data = _QT_DaoTaoBLL.Search(page, pageSize, out total, ten);
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
        [Route("get-gv/{id}")]
        [HttpGet]
        public List<QT_DaoTaoModel> GetGV(string id)
        {
            return _QT_DaoTaoBLL.GetGV(id);
        }
    }
}
