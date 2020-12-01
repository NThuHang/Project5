using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IBoMonDAL
    {
        List<BoMonModel> GetData();
        BoMonModel GetDatabyID(string id);
        bool Create(BoMonModel model);
        bool Update(BoMonModel model);
        bool Delete(string id);
        List<BoMonModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
