using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class DeTaiNCKHBLL : IDeTaiNCKHBLL
    {
        private IDeTaiNCKHDAL _res;
        public DeTaiNCKHBLL(IDeTaiNCKHDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<DeTaiNCKHModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(DeTaiNCKHModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DeTaiNCKHModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public DeTaiNCKHModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<DeTaiNCKHModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
