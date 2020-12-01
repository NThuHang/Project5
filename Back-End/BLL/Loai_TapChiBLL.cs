using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class Loai_TapChiBLL : ILoai_TapChiBLL
    {
        private ILoai_TapChiDAL _res;
        public Loai_TapChiBLL(ILoai_TapChiDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<Loai_TapChiModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(Loai_TapChiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(Loai_TapChiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public Loai_TapChiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<Loai_TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
