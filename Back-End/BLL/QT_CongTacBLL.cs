using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class QT_CongTacBLL : IQT_CongTacBLL
    {
        private IQT_CongTacDAL _res;
        public QT_CongTacBLL(IQT_CongTacDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<QT_CongTacModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(QT_CongTacModel model)
        {
            return _res.Create(model);
        }
        public bool Update(QT_CongTacModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public QT_CongTacModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<QT_CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
        public List<QT_CongTacModel> GetGV(string id)
        {
            return _res.GetGV(id);
        }

    }

}
