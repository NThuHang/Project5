using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TapChiBLL : ITapChiBLL
    {
        private ITapChiDAL _res;
        public TapChiBLL(ITapChiDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<TapChiModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(TapChiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TapChiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public TapChiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
