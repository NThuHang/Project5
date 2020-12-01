using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class HD_SinhVien_NCKHDAL : IHD_SinhVien_NCKHDAL
    {
        private IDatabaseHelper _dbHelper;
        public HD_SinhVien_NCKHDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<HD_SinhVien_NCKHModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HD_SinhVien_NCKH_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HD_SinhVien_NCKHModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HD_SinhVien_NCKHModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HD_SinhVien_NCKH_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HD_SinhVien_NCKHModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(HD_SinhVien_NCKHModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HD_SinhVien_NCKH_create",
                "@ID_HDSV", model.ID_HDSV,
                "@Ten_DeTai", model.Ten_DeTai,
                "@Cap_ThucHien", model.Cap_ThucHien,
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HD_SinhVien_NCKH_delete",
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
        public bool Update(HD_SinhVien_NCKHModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HD_SinhVien_NCKH_update",
                "@ID_HDSV", model.ID_HDSV,
                "@Ten_DeTai", model.Ten_DeTai,
                "@Cap_ThucHien", model.Cap_ThucHien,
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

        public List<HD_SinhVien_NCKHModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HD_SinhVien_NCKH_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HD_SinhVien_NCKHModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
