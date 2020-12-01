using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class DeTaiNCKHDAL : IDeTaiNCKHDAL
    {
        private IDatabaseHelper _dbHelper;
        public DeTaiNCKHDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<DeTaiNCKHModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DeTaiNCKH_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiNCKHModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DeTaiNCKHModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DeTaiNCKH_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiNCKHModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(DeTaiNCKHModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeTaiNCKH_create",
                "@ID_DeTai", model.ID_DeTai,
                "@Ten_DeTai", model.Ten_DeTai,
                "@Cap_QuanLy", model.Cap_QuanLy,
                "@TG_BD", model.TG_BD,
                "@TG_KT", model.TG_KT,
                "@TinhTrang", model.TinhTrang,
                "@KetQua", model.KetQua
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeTaiNCKH_delete",
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
        public bool Update(DeTaiNCKHModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeTaiNCKH_update",
                "@ID_DeTai", model.ID_DeTai,
                "@Ten_DeTai", model.Ten_DeTai,
                "@Cap_QuanLy", model.Cap_QuanLy,
                "@TG_BD", model.TG_BD,
                "@TG_KT", model.TG_KT,
                "@TinhTrang", model.TinhTrang,
                "@KetQua", model.KetQua);
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

        public List<DeTaiNCKHModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DeTaiNCKH_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DeTaiNCKHModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
