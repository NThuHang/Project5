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
    public class GiangVienController : ControllerBase
    {
        private IGiangVienBLL _giangVienBLL;
        private string _path;
        public GiangVienController(IGiangVienBLL giangVienBLL, IConfiguration configuration)
        {
            _giangVienBLL = giangVienBLL;
            _path = configuration["AppSettings:PATH"];
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetDataAll()
        {
            return _giangVienBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public GiangVienModel GetDatabyID(string id)
        {
            return _giangVienBLL.GetDatabyID(id);
        }

        [Route("create-gv")]
        [HttpPost]
        public GiangVienModel CreateItem([FromBody] GiangVienModel model)
        {
            _giangVienBLL.Create(model);
            return model;
        }

        [Route("delete-user")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string gv_id = "";
            if (formData.Keys.Contains("gv_id")
                && !string.IsNullOrEmpty(Convert.ToString(formData["gv_id"]))) 
            { gv_id = Convert.ToString(formData["gv_id"]); }
            _giangVienBLL.Delete(gv_id);
            return Ok();
        }

        [Route("update-user")]
        [HttpPost]
        public GiangVienModel UpdateUser([FromBody] GiangVienModel model)
        {
            _giangVienBLL.Update(model);
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
                string hoten = "";
                if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"])))
                { 
                    hoten = Convert.ToString(formData["hoten"]); 
                }
                long total = 0;
                var data = _giangVienBLL.Search(page, pageSize, out total, hoten);
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
