using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IHD_SinhVien_NCKHDAL
    {
        List<HD_SinhVien_NCKHModel> GetData();
        HD_SinhVien_NCKHModel GetDatabyID(string id);
        bool Create(HD_SinhVien_NCKHModel model);
        bool Update(HD_SinhVien_NCKHModel model);
        bool Delete(string id);
        List<HD_SinhVien_NCKHModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
