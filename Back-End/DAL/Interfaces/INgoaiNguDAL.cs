using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface INgoaiNguDAL
    {
        List<NgoaiNguModel> GetData();
        NgoaiNguModel GetDatabyID(string id);
        bool Create(NgoaiNguModel model);
        bool Update(NgoaiNguModel model);
        bool Delete(string id);
        List<NgoaiNguModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
