using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ISachBLL
    {
        List<SachModel> GetData();
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
        SachModel GetDatabyID(string id);
        List<SachModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

