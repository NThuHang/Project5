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

    }

}
