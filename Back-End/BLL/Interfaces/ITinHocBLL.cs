using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITinHocBLL
    {
        List<TinHocModel> GetData();
        bool Create(TinHocModel model);
        bool Update(TinHocModel model);
        bool Delete(string id);
        TinHocModel GetDatabyID(string id);
        List<TinHocModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

