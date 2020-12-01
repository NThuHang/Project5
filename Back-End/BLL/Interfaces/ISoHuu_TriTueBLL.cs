using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ISoHuu_TriTueBLL
    {
        List<SoHuu_TriTueModel> GetData();
        bool Create(SoHuu_TriTueModel model);
        bool Update(SoHuu_TriTueModel model);
        bool Delete(string id);
        SoHuu_TriTueModel GetDatabyID(string id);
        List<SoHuu_TriTueModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

