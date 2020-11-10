using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TinHocBLL : ITinHocBLL
    {
        private ITinHocDAL _res;
        public TinHocBLL(ITinHocDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<TinHocModel> GetData_GV(string id)
        {
            return _res.GetData_GV(id);
        }
        public bool Create(TinHocModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TinHocModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }

}
