using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NgoaiNguBLL : INgoaiNguBLL
    {
        private INgoaiNguDAL _res;
        public NgoaiNguBLL(INgoaiNguDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<NgoaiNguModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(NgoaiNguModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NgoaiNguModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public NgoaiNguModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<NgoaiNguModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
