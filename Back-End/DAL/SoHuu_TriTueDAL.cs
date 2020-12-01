using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class SoHuu_TriTueDAL : ISoHuu_TriTueDAL
    {
        private IDatabaseHelper _dbHelper;
        public SoHuu_TriTueDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<SoHuu_TriTueModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SoHuu_TriTue_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SoHuu_TriTueModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SoHuu_TriTueModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SoHuu_TriTue_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SoHuu_TriTueModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SoHuu_TriTueModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SoHuu_TriTue_create",
                "@ID_TriTue", model.ID_TriTue,
                "@Ten_TriTue", model.Ten_TriTue,
                "@ThoiGian", model.ThoiGian,
                "@DonVi_Cap", model.DonVi_Cap
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SoHuu_TriTue_delete",
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
        public bool Update(SoHuu_TriTueModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SoHuu_TriTue_update",
                "@ID_TriTue", model.ID_TriTue,
                "@Ten_TriTue", model.Ten_TriTue,
                "@ThoiGian", model.ThoiGian,
                "@DonVi_Cap", model.DonVi_Cap);
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

        public List<SoHuu_TriTueModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SoHuu_TriTue_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SoHuu_TriTueModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
