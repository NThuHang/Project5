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
        public List<NgoaiNguModel> GetData_GV(string id)
        {
            return _res.GetData_GV(id);
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

    }

}
