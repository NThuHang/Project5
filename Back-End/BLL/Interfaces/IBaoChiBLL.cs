using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IBaoChiBLL
    {
        List<BaoChiModel> GetData();
        bool Create(BaoChiModel model);
        bool Update(BaoChiModel model);
        bool Delete(string id);
        BaoChiModel GetDatabyID(string id);
        List<BaoChiModel> Search(int pageIndex, int pageSize, out long total, string hoten);
    }
}

