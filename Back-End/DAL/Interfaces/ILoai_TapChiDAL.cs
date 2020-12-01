using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ILoai_TapChiDAL
    {
        List<Loai_TapChiModel> GetData();
        Loai_TapChiModel GetDatabyID(string id);
        bool Create(Loai_TapChiModel model);
        bool Update(Loai_TapChiModel model);
        bool Delete(string id);
        List<Loai_TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
