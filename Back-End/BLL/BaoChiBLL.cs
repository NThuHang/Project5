using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class BaoChiBLL : IBaoChiBLL
    {
        private IBaoChiDAL _res;
        public BaoChiBLL(IBaoChiDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<BaoChiModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(BaoChiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(BaoChiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public BaoChiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<BaoChiModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
