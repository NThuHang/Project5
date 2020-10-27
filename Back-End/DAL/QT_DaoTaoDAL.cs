using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class QT_DaoTaoDAL : IQT_DaoTaoDAL
    {
        private IDatabaseHelper _dbHelper;
        public QT_DaoTaoDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Lấy quá trình đào tạo theo ID giảng viên
        public List<QT_DaoTaoModel> GetData_GV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "daotao_getAll_ID_giangvien",
                     "@ID_GV", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<QT_DaoTaoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(QT_DaoTaoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "qtdt_create",
                "@ID_DT", model.ID_DT,
                "@ID_GV", model.ID_GV,
                "@Ten_DT", model.Ten_DT,
                "@ND_DT", model.ND_DT,
                "@ChuyenMon", model.ChuyenMon,
                "@ThoiGian", model.ThoiGian);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "gv_delete",
                "@ID_DT", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(QT_DaoTaoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "gv_update",
                "@ID_DT", model.ID_DT,
                "@ID_GV", model.ID_GV,
                "@Ten_DT", model.Ten_DT,
                "@ND_DT", model.ND_DT,
                "@ChuyenMon", model.ChuyenMon,
                "@ThoiGian", model.ThoiGian);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
