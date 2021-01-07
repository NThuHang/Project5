using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface  IQT_DaoTaoDAL
    {
        List<QT_DaoTaoModel> GetData_GV(string id);
        bool Create(QT_DaoTaoModel model);
        bool Update(QT_DaoTaoModel model);
        bool Delete(string id);
        QT_DaoTaoModel GetDatabyID(string id);
        List<QT_DaoTaoModel> GetGV(string id);
        List<QT_DaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
