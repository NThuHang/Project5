using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HoiThaoKhoaHoc
    {
        public string ID_HoiThao { get; set; }
        public string Loai_HoiThao { get; set; }
        public string Ten_HoiThao { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string DiaDiem { get; set; }
        public int Trang_BD { get; set; }
        public int Trang_KT { get; set; }
        public string HinhThuc_BaiDang { get; set; }
        public string QuocGia { get; set; }
    }
}
