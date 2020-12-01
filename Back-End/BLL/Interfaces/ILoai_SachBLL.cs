using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILoai_SachBLL
    {
        List<Loai_SachModel> GetData();
        bool Create(Loai_SachModel model);
        bool Update(Loai_SachModel model);
        bool Delete(string id);
        Loai_SachModel GetDatabyID(string id);
        List<Loai_SachModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

