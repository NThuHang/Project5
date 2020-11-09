using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DanhMucModel
    {
        public string ID_DM { get; set; }
        public string ID_DM_Cha { get; set; }
        public string Ten_DM { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public short? Seq_Num { get; set; }
        public List<DanhMucModel> DM_Con { get; set; }
        public string type { get; set; }
    }
}
