using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HD_SinhVien_NCKHBLL : IHD_SinhVien_NCKHBLL
    {
        private IHD_SinhVien_NCKHDAL _res;
        public HD_SinhVien_NCKHBLL(IHD_SinhVien_NCKHDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<HD_SinhVien_NCKHModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(HD_SinhVien_NCKHModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HD_SinhVien_NCKHModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public HD_SinhVien_NCKHModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<HD_SinhVien_NCKHModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
