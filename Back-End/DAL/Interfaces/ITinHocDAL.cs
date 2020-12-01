using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ITinHocDAL
    {
        List<TinHocModel> GetData();
        TinHocModel GetDatabyID(string id);
        bool Create(TinHocModel model);
        bool Update(TinHocModel model);
        bool Delete(string id);
        List<TinHocModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
