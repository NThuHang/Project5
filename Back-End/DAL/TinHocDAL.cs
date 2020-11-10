using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class TinHocDAL : ITinHocDAL
    {
        private IDatabaseHelper _dbHelper;
        public TinHocDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Lấy thông tin ngoại ngữ theo ID giảng viên
        public List<TinHocModel> GetData_GV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "TinHoc_get_gv",
                     "@ID_GV", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(TinHocModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "TinHoc_create",
                "@ID_TH", model.ID_TH,
                "@ID_GV", model.ID_GV,
                "@Ten_TinHoc", model.Ten_TinHoc,
                "@TrinhDo", model.TrinhDo,
                "@ChungChi", model.ChungChi);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "TinHoc_delete",
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
        public bool Update(TinHocModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "TinHoc_update",
                "@ID_TH", model.ID_TH,
                "@ID_GV", model.ID_GV,
                "@Ten_TinHoc", model.Ten_TinHoc,
                "@TrinhDo", model.TrinhDo,
                "@ChungChi", model.ChungChi);
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
