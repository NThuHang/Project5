using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILoai_TapChiBLL
    {
        List<Loai_TapChiModel> GetData();
        bool Create(Loai_TapChiModel model);
        bool Update(Loai_TapChiModel model);
        bool Delete(string id);
        Loai_TapChiModel GetDatabyID(string id);
        List<Loai_TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

