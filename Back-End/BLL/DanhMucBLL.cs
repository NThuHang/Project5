using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class DanhMucBLL : IDanhMucBLL
    {
        private IDanhMucDAL _res;
        public DanhMucBLL(IDanhMucDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<DanhMucModel> GetData()
        {
            return _res.GetData();
        }
    }
}
