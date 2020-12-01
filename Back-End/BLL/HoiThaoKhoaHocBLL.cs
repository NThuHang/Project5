using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoiThaoKhoaHocBLL : IHoiThaoKhoaHocBLL
    {
        private IHoiThaoKhoaHocDAL _res;
        public HoiThaoKhoaHocBLL(IHoiThaoKhoaHocDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<HoiThaoKhoaHocModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(HoiThaoKhoaHocModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoiThaoKhoaHocModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public HoiThaoKhoaHocModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<HoiThaoKhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
