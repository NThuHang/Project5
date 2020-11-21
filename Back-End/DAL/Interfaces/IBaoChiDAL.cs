using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IBaoChiDAL
    {
        List<BaoChiModel> GetData();
        BaoChiModel GetDatabyID(string id);
        bool Create(BaoChiModel model);
        bool Update(BaoChiModel model);
        bool Delete(string id);
        List<BaoChiModel> Search(int pageIndex, int pageSize, out long total, string hoten);
    }
}
