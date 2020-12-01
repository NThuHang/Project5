using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INgoaiNguBLL
    {
        List<NgoaiNguModel> GetData();
        bool Create(NgoaiNguModel model);
        bool Update(NgoaiNguModel model);
        bool Delete(string id);
        NgoaiNguModel GetDatabyID(string id);
        List<NgoaiNguModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

