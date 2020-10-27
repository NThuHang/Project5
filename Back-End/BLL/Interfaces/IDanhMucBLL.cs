using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDanhMucBLL
    {
        List<DanhMucModel> GetData();
    }
}
