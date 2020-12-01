using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IKhoaBLL
    {
        List<KhoaModel> GetData();
        bool Create(KhoaModel model);
        bool Update(KhoaModel model);
        bool Delete(string id);
        KhoaModel GetDatabyID(string id);
        List<KhoaModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

