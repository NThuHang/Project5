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
        public List<DanhMucModel> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.Where(ds => ds.ID_DM_Cha == null).OrderBy(s => s.Seq_Num).ToList();
            foreach (var item in lstParent)
            {
                item.DM_Con = GetDanhMucCon(allItemGroups, item);
            }
            return lstParent;
        }
        public List<DanhMucModel> GetDanhMucCon (List<DanhMucModel> lstAll, DanhMucModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.ID_DM_Cha == node.ID_DM).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetDanhMucCon(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].DM_Con = childs;
            }
            return lstChilds.OrderBy(s => s.Seq_Num).ToList();
        }
    }
}
