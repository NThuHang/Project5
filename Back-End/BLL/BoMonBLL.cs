using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class BoMonBLL : IBoMonBLL
    {
        private IBoMonDAL _res;
        public BoMonBLL(IBoMonDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<BoMonModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(BoMonModel model)
        {
            return _res.Create(model);
        }
        public bool Update(BoMonModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public BoMonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<BoMonModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
