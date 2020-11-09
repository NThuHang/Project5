using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITaiKhoanBLL
    {
        TaiKhoanModel XacThuc(string username, string password);
    }
}
