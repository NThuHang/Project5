using System;
using Model;
using System.Collections.Generic;
using System.Text;
namespace DAL
{
    public partial interface ITaiKhoanDAL
    {
        TaiKhoanModel GetTaiKhoan(string tentk, string password);
        TaiKhoanModel GetThongTin(string id);
    }
}
