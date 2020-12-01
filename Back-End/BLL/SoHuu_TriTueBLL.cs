using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SoHuu_TriTueBLL : ISoHuu_TriTueBLL
    {
        private ISoHuu_TriTueDAL _res;
        public SoHuu_TriTueBLL(ISoHuu_TriTueDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<SoHuu_TriTueModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(SoHuu_TriTueModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SoHuu_TriTueModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public SoHuu_TriTueModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SoHuu_TriTueModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
    }

}
