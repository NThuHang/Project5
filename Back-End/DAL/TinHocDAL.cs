using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class TinHocDAL : ITinHocDAL
    {
        private IDatabaseHelper _dbHelper;
        public TinHocDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<TinHocModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "TinHoc_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TinHocModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "TinHoc_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinHocModel>().FirstOrDefault();
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
                "@ChungChi", model.ChungChi
                );
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
                "@ID_BBao", id);
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

        public List<TinHocModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "TinHoc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TinHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
