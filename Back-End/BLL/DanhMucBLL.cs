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
        public DanhMucBLL(IDanhMucDAL DanhMucRes)
        {
            _res = DanhMucRes;
        }
        public List<DanhMucModel> GetData(string quyen)
        {
            var lay_menu = _res.GetData(quyen);
            var ds_cha = lay_menu.Where(ds => ds.ID_DM_Cha == null).OrderBy(s => s.Seq_Num).ToList();
            foreach (var item in ds_cha)
            {
                item.DM_Con = GetDanhMucCon(lay_menu, item);
            }
            return ds_cha;
        }
        public List<DanhMucModel> GetDanhMucCon (List<DanhMucModel> lstAll, DanhMucModel node)
        {
            var ds_con = lstAll.Where(ds => ds.ID_DM_Cha == node.ID_DM).ToList();
            if (ds_con.Count == 0)
                return null;
            for (int i = 0; i < ds_con.Count; i++)
            {
                var con = GetDanhMucCon(lstAll, ds_con[i]);
                ds_con[i].DM_Con = con;
            }
            return ds_con.OrderBy(s => s.Seq_Num).ToList();
        }
    }
}
