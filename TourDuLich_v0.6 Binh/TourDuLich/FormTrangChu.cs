using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TourDuLich
{
    public partial class FormTrangChu : Form
    {
        private const string USERS_FILE_PATH = "App_Data/Users.xml";
        private const string TOURS_FILE_PATH = "App_Data/Tours.xml";
        public static List<Tour> tours;
        public static List<ChuongTrinhTour> chuongtrinhtours;
        public List<Tour> toursMoiNhat;
        public List<Tour> toursDangThamGiaNhat;
        public List<Tour> toursDuocXemNhieuNhat;
        public List<Tour> toursKetQua;
        public static List<String> chiTietTour;
        public static string diemDen;
        public static string diemXuatPhat;
        public static string loaiTour;
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (this.kiemTraDangNhap())
            {
                this.btnDangNhap.Visible = false;
                this.btnDangXuat.Visible = true;

                this.txtTenDangNhap.Visible = false;
                this.txtMatKhau.Visible = false;
                this.lbTenDangNhap.Visible = false;
                this.lbMatKhau.Text = "Xin chào, " + this.txtTenDangNhap.Text;
            }
            else
            {
                this.txtTenDangNhap.Text = "";
                this.txtMatKhau.Text = "";
            }
        }

        private bool kiemTraDangNhap()
        {
            if (this.txtTenDangNhap.Text == "" || this.txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui long nhap day du ten dang nhap va mat khau");
                return false;
            }
            else if (this.txtTenDangNhap.Text != "" && this.txtMatKhau.Text != "")
            {
                string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, USERS_FILE_PATH);

                XElement root = XElement.Load(xmlFileName);
                var user = root.Elements("user").SingleOrDefault(e => e.Attribute("username").Value == this.txtTenDangNhap.Text
                    && e.Attribute("password").Value == this.txtMatKhau.Text);
                if (user == null)
                    return false;
                else
                    return true;
            }

            return true;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Visible = true;
            this.txtTenDangNhap.Text = "";
            this.txtMatKhau.Visible = true;
            this.txtMatKhau.Text = "";
            this.lbTenDangNhap.Visible = true;
            this.lbMatKhau.Text = "Mật khẩu";
            this.btnDangNhap.Visible = true;
            this.btnDangXuat.Visible = false;
        }

        private void VeTrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void loadTours()
        {
            string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TOURS_FILE_PATH);

            XElement root = XElement.Load(xmlFileName);
            var listEle = root.Elements("Tour");

            tours = new List<Tour>();

            foreach (XElement element in listEle)
            {
                var eleChuongTrinhTour = element.Element("ChuongTrinhTour").Elements("item");
                chuongtrinhtours = new List<ChuongTrinhTour>();
                foreach (XElement ele in eleChuongTrinhTour)
                {
                    ChuongTrinhTour chuongTrinhTour = new ChuongTrinhTour
                    {
                        Ngay = ele.Element("Ngay").Value,
                        ThoiGian = ele.Element("ThoiGian").Value,
                        DiaDiem = ele.Element("DiaDiem").Value,
                        ThongTinThem = ele.Element("ThongTinThem").Value
                    };
                    chuongtrinhtours.Add(chuongTrinhTour);
                }

                Tour tour = new Tour
                {
                    MaTour = element.Element("MaTour").Value,
                    TenTour = element.Element("TenTour").Value,
                    LoaiTour = element.Element("LoaiTour").Value,
                    DiemXuatPhat = element.Element("DiemXuatPhat").Value,
                    DiemDen = element.Element("DiemDen").Value,
                    GiaTourDuKien = element.Element("GiaTourDuKien").Value,
                    SoLuongVe = element.Element("SoLuongVe").Value,
                    NgayKhoiHanh = element.Element("NgayKhoiHanh").Value,
                    NgayKetThuc = element.Element("NgayKetThuc").Value,
                    SoLanDatMua = Int32.Parse(element.Element("SoLanDatMua").Value),
                    SoLuotXem = Int32.Parse(element.Element("SoLuotXem").Value),
                    NgayTaoTour = element.Element("NgayTaoTour").Value,
                    ChuongTrinhTour = chuongtrinhtours
                };
                tours.Add(tour);
            }
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            this.btnDangNhap.Visible = true;
            this.btnDangXuat.Visible = false;
            loadTours();
            this.toursMoiNhat = new List<Tour>(tours);
            this.toursMoiNhat.Sort(delegate(Tour x, Tour y)
            {
                return DateTime.Parse(y.NgayTaoTour).CompareTo(DateTime.Parse(x.NgayTaoTour));
            });
            this.toursDangThamGiaNhat = new List<Tour>(tours);
            this.toursDangThamGiaNhat.Sort(delegate(Tour x, Tour y)
            {
                return y.SoLanDatMua.CompareTo(x.SoLanDatMua);
            });
            this.toursDuocXemNhieuNhat = new List<Tour>(tours);
            this.toursDuocXemNhieuNhat.Sort(delegate(Tour x, Tour y)
            {
                return y.SoLuotXem.CompareTo(x.SoLuotXem);
            });
            this.dgvDSTourMoiNhat.DataSource = this.toursMoiNhat;
            this.dgvDSTourDangThamGiaNha.DataSource = this.toursDangThamGiaNhat;
            this.dgvDSTourDuocXemNhieuNhat.DataSource = this.toursDuocXemNhieuNhat;
            //Cai dat gia tri cho cac combobox
            foreach (Tour t in tours)
            {
                this.cbDiemDen.Items.Add(t.DiemDen);
                this.cbGiaTour.Items.Add(t.GiaTourDuKien);
            }
            this.AcceptButton = btnDangNhap;
            this.lbKetQuaTimKiem.Text = "";
        }

        public void hienChiTietTourTheoDanhSach(DataGridViewCellMouseEventArgs e)
        {

            //this.txtChuongTrinhTours.Text = string.Join(Environment.NewLine, chiTiet.ToArray());
        }

        private void dgvDSTourMoiNhat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            chiTietTour = null;
            chiTietTour = new List<string>();
            foreach (ChuongTrinhTour ctTour in toursMoiNhat[e.RowIndex].ChuongTrinhTour)
            {
                chiTietTour.Add(ctTour.Ngay + ", thời gian: " + ctTour.ThoiGian + " tại " + ctTour.DiaDiem);
                chiTietTour.Add("Chương trình: " + ctTour.ThongTinThem);
                chiTietTour.Add("");
            }
            diemDen = toursMoiNhat[e.RowIndex].DiemDen;
            diemXuatPhat = toursMoiNhat[e.RowIndex].DiemXuatPhat;
            loaiTour = toursMoiNhat[e.RowIndex].LoaiTour;
            Form f = new FormChiTietTour();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
        
        private void dgvDSTourDangThamGiaNha_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            chiTietTour = null;
            chiTietTour = new List<string>();
            foreach (ChuongTrinhTour ctTour in toursDangThamGiaNhat[e.RowIndex].ChuongTrinhTour)
            {
                chiTietTour.Add(ctTour.Ngay + ", thời gian: " + ctTour.ThoiGian + " tại " + ctTour.DiaDiem);
                chiTietTour.Add("Chương trình: " + ctTour.ThongTinThem);
                chiTietTour.Add("");
            }
            diemDen = toursDangThamGiaNhat[e.RowIndex].DiemDen;
            diemXuatPhat = toursDangThamGiaNhat[e.RowIndex].DiemXuatPhat;
            loaiTour = toursDangThamGiaNhat[e.RowIndex].LoaiTour;
            Form f = new FormChiTietTour();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
        private void dgvDSTourDuocXemNhieuNhat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            chiTietTour = null;
            chiTietTour = new List<string>();
            foreach (ChuongTrinhTour ctTour in toursDuocXemNhieuNhat[e.RowIndex].ChuongTrinhTour)
            {
                chiTietTour.Add(ctTour.Ngay + ", thời gian: " + ctTour.ThoiGian + " tại " + ctTour.DiaDiem);
                chiTietTour.Add("Chương trình: " + ctTour.ThongTinThem);
                chiTietTour.Add("");
            }
            diemDen = toursDuocXemNhieuNhat[e.RowIndex].DiemDen;
            diemXuatPhat = toursDuocXemNhieuNhat[e.RowIndex].DiemXuatPhat;
            loaiTour = toursDuocXemNhieuNhat[e.RowIndex].LoaiTour;
            Form f = new FormChiTietTour();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
        private void txtChuongTrinhTours_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXemTourTheoLoai_Click(object sender, EventArgs e)
        {
            string loaiTourDuocChon = "";
            //kiem tra 
            if (this.cbxLoaiTour.SelectedItem == null)
            {
                MessageBox.Show("Xin chọn loại tour cần xem");
                return;
            }
            else
                loaiTourDuocChon = this.cbxLoaiTour.SelectedItem.ToString();
            //Duyet trong mang tours va tim tour phu hop
            toursKetQua = new List<Tour>();
            foreach (Tour t in tours)
            {
                if (t.LoaiTour.Equals(loaiTourDuocChon))
                {
                    toursKetQua.Add(t);
                }
            }
            //xuat ket qua
            if (toursKetQua.Count() == 0)
            {
                this.lbKetQuaTimKiem.Text = "Không có Tour nào có loại " + loaiTourDuocChon;
                this.dgvKetQuaTimKiem.DataSource = null;
            }
            else
            {
                this.lbKetQuaTimKiem.Text = "Kết quả các tours loại " + loaiTourDuocChon;
                this.dgvKetQuaTimKiem.DataSource = toursKetQua;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Kiem tra chuoi can tim
            if (this.txtTimKiem.Text == "")
            {
                MessageBox.Show("Xin nhập tên tour cần tìm");
                return;
            }
            if (this.cbDiemDen.SelectedItem == null)
            {
                MessageBox.Show("Xin chọn điểm đến cần tìm");
                return;
            }
            if (this.cbGiaTour.SelectedItem == null)
            {
                MessageBox.Show("Xin chọn giá tour cần tìm");
                return;
            }
            //Tim tour phu hop
            toursKetQua = new List<Tour>();
            foreach (Tour t in tours)
            {
                if (t.DiemDen.Equals(this.cbDiemDen.SelectedItem.ToString())
                    && t.GiaTourDuKien.Equals(this.cbGiaTour.SelectedItem.ToString())
                    && t.TenTour.Contains(this.txtTimKiem.Text))
                {
                    toursKetQua.Add(t);
                }
            }
            //Xuat ket qua
            if (toursKetQua.Count() == 0)
            {
                this.lbKetQuaTimKiem.Text = "Không tìm được kết quả";
                this.dgvKetQuaTimKiem.DataSource = null;
            }
            else
            {
                this.lbKetQuaTimKiem.Text = "Kết quả với từ khóa: " + this.txtTimKiem.Text + "- Địa điểm: " + this.cbDiemDen.SelectedItem.ToString() + "- Giá tour: " + this.cbGiaTour.SelectedItem.ToString();
                this.dgvKetQuaTimKiem.DataSource = toursKetQua;
            }
        }

        private void dgvKetQuaTimKiem_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            chiTietTour = null;
            chiTietTour = new List<string>();
            foreach (ChuongTrinhTour ctTour in toursKetQua[e.RowIndex].ChuongTrinhTour)
            {
                chiTietTour.Add(ctTour.Ngay + ", thời gian: " + ctTour.ThoiGian + " tại " + ctTour.DiaDiem);
                chiTietTour.Add("Chương trình: " + ctTour.ThongTinThem);
                chiTietTour.Add("");
            }
            diemDen = toursKetQua[e.RowIndex].DiemDen;
            diemXuatPhat = toursKetQua[e.RowIndex].DiemXuatPhat;
            loaiTour = toursKetQua[e.RowIndex].LoaiTour;
            Form f = new FormChiTietTour();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        //private string chuyenDoiTiengVietKhongDau(string chuCoDau)
        //{
        //    Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        //    string temp = chuCoDau.Normalize(NormalizationForm.FormD);
        //    return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        //}
    }
}
