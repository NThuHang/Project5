using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhoaBLL : IKhoaBLL
    {
        private IKhoaDAL _res;
        public KhoaBLL(IKhoaDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<KhoaModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(KhoaModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhoaModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public KhoaModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<KhoaModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
