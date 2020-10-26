using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class GiangVienBLL : IGiangVienBLL
    {
        private IGiangVienDAL _res;
        public GiangVienBLL(IGiangVienDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<GiangVienModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(GiangVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(GiangVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public GiangVienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }

}
