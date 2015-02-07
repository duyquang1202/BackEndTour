using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TourDuLich
{
    public partial class FormChiTietTour : Form
    {
        private string serviceURL1 = "http://localhost:1279/Service1.svc/";
        private string serviceURL1_hotel = "api1/khachsan/{0}";
        private List<Tour> toursCungLoai;

        public FormChiTietTour()
        {
            InitializeComponent();
        }

        private void FormChiTietTour_Load(object sender, EventArgs e)
        {
            this.txtChuongTrinhTours.Text = string.Join(Environment.NewLine, FormTrangChu.chiTietTour.ToArray());

            //string result = "";
            string url = string.Format(serviceURL1 + "api1/khachsan/{0}", FormTrangChu.diemDen);
            string url1 = serviceURL1 + "api1/tong/1;3";
            WebClient c = new WebClient();
            //result = c.DownloadString(url);
            //MessageBox.Show(c.DownloadString(url));
            //MessageBox.Show(c.DownloadString(url1));
            
            //5 tours cung loai
            toursCungLoai = new List<Tour>();
            foreach (Tour t in FormTrangChu.tours)
            {
                if (t.LoaiTour.Equals(FormTrangChu.loaiTour))
                {
                    toursCungLoai.Add(t);
                }
            }
            this.dgvTourCungLoai.DataSource = toursCungLoai;
        }

        private void txtChuongTrinhTours_TextChanged(object sender, EventArgs e)
        {
            //Size size = TextRenderer.MeasureText(txtChuongTrinhTours.Text, txtChuongTrinhTours.Font);
            //txtChuongTrinhTours.Width = size.Width;
            //stxtChuongTrinhTours.Height = size.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
