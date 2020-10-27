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
    }
}
