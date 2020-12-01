using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ISoHuu_TriTueDAL
    {
        List<SoHuu_TriTueModel> GetData();
        SoHuu_TriTueModel GetDatabyID(string id);
        bool Create(SoHuu_TriTueModel model);
        bool Update(SoHuu_TriTueModel model);
        bool Delete(string id);
        List<SoHuu_TriTueModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
