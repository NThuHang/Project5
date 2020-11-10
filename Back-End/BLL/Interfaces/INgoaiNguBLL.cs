using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface INgoaiNguBLL
    {
        List<NgoaiNguModel> GetData_GV(string id);
        bool Create(NgoaiNguModel model);
        bool Update(NgoaiNguModel model);
        bool Delete(string id);
    }
}
