using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IQT_CongTacBLL
    {
        List<QT_CongTacModel> GetData();
        bool Create(QT_CongTacModel model);
        bool Update(QT_CongTacModel model);
        bool Delete(string id);
        QT_CongTacModel GetDatabyID(string id);
        List<QT_CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}

