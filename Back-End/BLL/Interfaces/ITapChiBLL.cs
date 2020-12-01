using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITapChiBLL
    {
        List<TapChiModel> GetData();
        bool Create(TapChiModel model);
        bool Update(TapChiModel model);
        bool Delete(string id);
        TapChiModel GetDatabyID(string id);
        List<TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

