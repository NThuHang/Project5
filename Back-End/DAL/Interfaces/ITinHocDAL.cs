using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ITinHocDAL
    {
        List<TinHocModel> GetData_GV(string id);
        bool Create(TinHocModel model);
        bool Update(TinHocModel model);
        bool Delete(string id);
    }
}
