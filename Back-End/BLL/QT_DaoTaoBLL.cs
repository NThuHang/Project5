using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class QT_DaoTaoBLL : IQT_DaoTaoBLL
    {
        private IQT_DaoTaoDAL _res;
        public QT_DaoTaoBLL(IQT_DaoTaoDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<QT_DaoTaoModel> GetData_GV(string id)
        {
            return _res.GetData_GV(id);
        }
        public QT_DaoTaoModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(QT_DaoTaoModel model)
        {
            return _res.Create(model);
        }
        public bool Update(QT_DaoTaoModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<QT_DaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
        public List<QT_DaoTaoModel> GetGV(string id)
        {
            return _res.GetGV(id);
        }
    }

}
