using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ILoai_SachDAL
    {
        List<Loai_SachModel> GetData();
        Loai_SachModel GetDatabyID(string id);
        bool Create(Loai_SachModel model);
        bool Update(Loai_SachModel model);
        bool Delete(string id);
        List<Loai_SachModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
