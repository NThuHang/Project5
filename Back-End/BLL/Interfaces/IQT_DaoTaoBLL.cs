using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IQT_DaoTaoBLL
    {
        List<QT_DaoTaoModel> GetData_GV(string id);
        bool Create(QT_DaoTaoModel model);
        bool Update(QT_DaoTaoModel model);
        bool Delete(string id);
    }
}
