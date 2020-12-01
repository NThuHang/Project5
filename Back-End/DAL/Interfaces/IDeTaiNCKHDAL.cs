using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IDeTaiNCKHDAL
    {
        List<DeTaiNCKHModel> GetData();
        DeTaiNCKHModel GetDatabyID(string id);
        bool Create(DeTaiNCKHModel model);
        bool Update(DeTaiNCKHModel model);
        bool Delete(string id);
        List<DeTaiNCKHModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
