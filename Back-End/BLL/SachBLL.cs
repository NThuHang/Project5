using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SachBLL : ISachBLL
    {
        private ISachDAL _res;
        public SachBLL(ISachDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<SachModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(SachModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SachModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public SachModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SachModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
