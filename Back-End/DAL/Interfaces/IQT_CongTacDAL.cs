using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IQT_CongTacDAL
    {
        List<QT_CongTacModel> GetData();
        QT_CongTacModel GetDatabyID(string id);
        bool Create(QT_CongTacModel model);
        bool Update(QT_CongTacModel model);
        bool Delete(string id);
        List<QT_CongTacModel> GetGV(string id);
        List<QT_CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
