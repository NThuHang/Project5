using DAL.Helper;
using Model;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace DAL
{
    public partial class HoiThaoKhoaHocDAL : IHoiThaoKhoaHocDAL
    {
        private IDatabaseHelper _dbHelper;
        public HoiThaoKhoaHocDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<HoiThaoKhoaHocModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoithao_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoiThaoKhoaHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HoiThaoKhoaHocModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HoiThaoKhoaHoc_getID",
                     "@ID_BBao", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoiThaoKhoaHocModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(HoiThaoKhoaHocModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoiThaoKhoaHoc_create",
                "@ID_HoiThao", model.ID_HoiThao,
                "@Loai_HoiThao", model.Loai_HoiThao,
                "@Ten_HoiThao", model.Ten_HoiThao,
                "@ThoiGian", model.ThoiGian,
                "@DiaDiem", model.DiaDiem,
                "@Trang_BD", model.Trang_BD,
                "@Trang_KT", model.Trang_KT,
                "@HinhThuc_BaiDang", model.HinhThuc_BaiDang,
                "@QuocGia", model.QuocGia
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoiThaoKhoaHoc_delete",
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
        public bool Update(HoiThaoKhoaHocModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "HoiThaoKhoaHoc_update",
                "@ID_HoiThao", model.ID_HoiThao,
                "@Loai_HoiThao", model.Loai_HoiThao,
                "@Ten_HoiThao", model.Ten_HoiThao,
                "@ThoiGian", model.ThoiGian,
                "@DiaDiem", model.DiaDiem,
                "@Trang_BD", model.Trang_BD,
                "@Trang_KT", model.Trang_KT,
                "@HinhThuc_BaiDang", model.HinhThuc_BaiDang,
                "@QuocGia", model.QuocGia);
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

        public List<HoiThaoKhoaHocModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "hoithao_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoiThaoKhoaHocModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
