using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHoiThaoKhoaHocBLL
    {
        List<HoiThaoKhoaHocModel> GetData();
        bool Create(HoiThaoKhoaHocModel model);
        bool Update(HoiThaoKhoaHocModel model);
        bool Delete(string id);
        HoiThaoKhoaHocModel GetDatabyID(string id);
        List<HoiThaoKhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

