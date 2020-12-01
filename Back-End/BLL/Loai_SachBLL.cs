using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class Loai_SachBLL : ILoai_SachBLL
    {
        private ILoai_SachDAL _res;
        public Loai_SachBLL(ILoai_SachDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<Loai_SachModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(Loai_SachModel model)
        {
            return _res.Create(model);
        }
        public bool Update(Loai_SachModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public Loai_SachModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<Loai_SachModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
