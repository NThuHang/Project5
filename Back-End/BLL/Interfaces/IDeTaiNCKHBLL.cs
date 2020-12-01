using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDeTaiNCKHBLL
    {
        List<DeTaiNCKHModel> GetData();
        bool Create(DeTaiNCKHModel model);
        bool Update(DeTaiNCKHModel model);
        bool Delete(string id);
        DeTaiNCKHModel GetDatabyID(string id);
        List<DeTaiNCKHModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

