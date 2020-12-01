using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHD_SinhVien_NCKHBLL
    {
        List<HD_SinhVien_NCKHModel> GetData();
        bool Create(HD_SinhVien_NCKHModel model);
        bool Update(HD_SinhVien_NCKHModel model);
        bool Delete(string id);
        HD_SinhVien_NCKHModel GetDatabyID(string id);
        List<HD_SinhVien_NCKHModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

