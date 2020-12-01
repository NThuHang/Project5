using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IHoiThaoKhoaHocDAL
    {
        List<HoiThaoKhoaHocModel> GetData();
        HoiThaoKhoaHocModel GetDatabyID(string id);
        bool Create(HoiThaoKhoaHocModel model);
        bool Update(HoiThaoKhoaHocModel model);
        bool Delete(string id);
        List<HoiThaoKhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
