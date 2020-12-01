﻿using System;
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
    public class NgoaiNguController : ControllerBase
    {
        private INgoaiNguBLL _NgoaiNguBLL;
        public NgoaiNguController(INgoaiNguBLL NgoaiNguBLL)
        {
            _NgoaiNguBLL = NgoaiNguBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NgoaiNguModel> GetDataAll()
        {
            return _NgoaiNguBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NgoaiNguModel GetDatabyID(string id)
        {
            return _NgoaiNguBLL.GetDatabyID(id);
        }

        [Route("create-NgoaiNgu")]
        [HttpPost]
        public NgoaiNguModel CreateItem([FromBody] NgoaiNguModel model)
        {
            model.ID_NN = Guid.NewGuid().ToString();
            _NgoaiNguBLL.Create(model);
            return model;
        }

        [Route("delete-NgoaiNgu")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _NgoaiNguBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-NgoaiNgu")]
        [HttpPost]
        public NgoaiNguModel UpdateUser([FromBody] NgoaiNguModel model)
        {
            _NgoaiNguBLL.Update(model);
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
                var data = _NgoaiNguBLL.Search(page, pageSize, out total, ten);
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
