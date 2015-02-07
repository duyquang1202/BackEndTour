
using System.Collections.Generic;
namespace TourDuLich
{
    public class Tour
    {
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public string LoaiTour { get; set; }
        public string DiemXuatPhat { get; set; }
        public string DiemDen { get; set; }
        public string GiaTourDuKien { get; set; }
        public List<ChuongTrinhTour> ChuongTrinhTour { get; set; }
        public string SoLuongVe { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string NgayKetThuc { get; set; }
        public int SoLanDatMua { get; set; }
        public int SoLuotXem { get; set; }
        public string NgayTaoTour { get; set; }
    }
}
