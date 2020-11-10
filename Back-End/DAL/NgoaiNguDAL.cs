using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class NgoaiNguDAL : INgoaiNguDAL
    {
        private IDatabaseHelper _dbHelper;
        public NgoaiNguDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Lấy thông tin ngoại ngữ theo ID giảng viên
        public List<NgoaiNguModel> GetData_GV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ngoaingu_get_gv",
                     "@ID_GV", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NgoaiNguModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(NgoaiNguModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ngoaingu_create",
                "@ID_NN", model.ID_NN,
                "@ID_GV", model.ID_GV,
                "@Ten_NN", model.Ten_NN,
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ngoaingu_delete",
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
        public bool Update(NgoaiNguModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ngoaingu_update",
                "@ID_NN", model.ID_NN,
                "@ID_GV", model.ID_GV,
                "@Ten_NN", model.Ten_NN,
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
