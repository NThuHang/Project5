using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class NgoaiNguDAL : INgoaiNguDAL
    {
        private IDatabaseHelper _dbHelper;
        public NgoaiNguDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<NgoaiNguModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "NgoaiNgu_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NgoaiNguModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NgoaiNguModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "NgoaiNgu_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NgoaiNguModel>().FirstOrDefault();
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "NgoaiNgu_create",
               "@ID_NN", model.ID_NN,
                "@ID_GV", model.ID_GV,
                "@Ten_NN", model.Ten_NN,
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "NgoaiNgu_delete",
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
        public bool Update(NgoaiNguModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "NgoaiNgu_update",
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

        public List<NgoaiNguModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "NgoaiNgu_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NgoaiNguModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
