using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IKhoaDAL
    {
        List<KhoaModel> GetData();
        KhoaModel GetDatabyID(string id);
        bool Create(KhoaModel model);
        bool Update(KhoaModel model);
        bool Delete(string id);
        List<KhoaModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
