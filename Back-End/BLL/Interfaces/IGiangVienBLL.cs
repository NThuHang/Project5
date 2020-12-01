using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IGiangVienBLL
    {
        List<GiangVienModel> GetData();
        bool Create(GiangVienModel model);
        bool Update(GiangVienModel model);
        bool Delete(string id);
        GiangVienModel GetDatabyID(string id);
        List<GiangVienModel> Search(int pageIndex, int pageSize, out long total, string hoten);
        GiangVienModel Get_ThongTin_TK(string id);
    }
}

