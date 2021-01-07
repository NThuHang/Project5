using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDanhMucDAL
    {
        List<DanhMucModel> GetData(string quyen);
    }
}
