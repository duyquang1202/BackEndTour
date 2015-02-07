using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TourDuLich
{
    public partial class FormQuanLyAPI : Form
    {
        private string tenFileHotel = "App_Data/url-hotel.txt";
        private string tenFileBus = "App_Data/url-bus.txt";
        private string tenFileTrain = "App_Data/url-train.txt";
        private string tenFilePlane = "App_Data/url-plane.txt";
        public FormQuanLyAPI()
        {
            InitializeComponent();
            cbLoaiAPI.SelectedIndex = 0;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string filename = layAIP();
            string[] lines = File.ReadAllLines(@filename);
            if (txtUrl.Text != "")
            {
                bool flag = false;
                foreach (string line in lines)
                {
                    if (line == txtUrl.Text)
                    {
                        MessageBox.Show("Url đã có");
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    using (StreamWriter writer = new StreamWriter(@filename, true))
                    {
                        writer.WriteLine(txtUrl.Text);
                        MessageBox.Show("Thêm url thành công");
                    }
                    docUrl(filename);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng nhập Url cần thêm");
            }
        }

        private void dgvDanhSachAPI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrl.Text = dgvDanhSachAPI.Rows[dgvDanhSachAPI.CurrentCell.RowIndex].Cells[0].Value.ToString();
        }
        private void docUrl(string filename)
        {
            dgvDanhSachAPI.Rows.Clear();
            string[] lines = File.ReadAllLines(@filename);
            dgvDanhSachAPI.ColumnCount = 1;
            dgvDanhSachAPI.Columns[0].Name = "URL";
            dgvDanhSachAPI.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i < lines.Length; i++)
            {
                dgvDanhSachAPI.Rows.Add(lines[i]);
            }
        }

        private void cbLoaiAPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbLoaiAPI.SelectedIndex)
            {
                case 0:
                    docUrl(tenFileHotel);
                    break;
                case 1:
                    docUrl(tenFileBus);
                    break;
                case 2:
                    docUrl(tenFileTrain);
                    break;
                case 3:
                    docUrl(tenFilePlane);
                    break;
            }
        }
        private String layAIP()
        {
            string filename = null;
            switch(cbLoaiAPI.SelectedIndex)
            {
                case 0:
                    filename = tenFileHotel;
                    break;
                case 1:
                    filename = tenFileBus;
                    break;
                case 2:
                    filename = tenFileTrain;
                    break;
                case 3:
                    filename = tenFilePlane;
                    break;
            }
            return filename;
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string filename = layAIP();
            string[] lines = File.ReadAllLines(@filename);
            if (txtUrl.Text != "")
            {
                bool flag = false;
                foreach (string line in lines)
                {
                    if (line == txtUrl.Text)
                    {
                        MessageBox.Show("Url đã có");
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    File.WriteAllText(filename, File.ReadAllText(filename).Replace(dgvDanhSachAPI.Rows[dgvDanhSachAPI.CurrentCell.RowIndex].Cells[0].Value.ToString(), txtUrl.Text));
                    MessageBox.Show("Sửa url thành công");
                    docUrl(filename);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng nhập Url cần sửa");
            }           
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = layAIP();
                File.WriteAllLines(filename,
                        File.ReadLines(filename).Where(l => l != dgvDanhSachAPI.
                Rows[dgvDanhSachAPI.CurrentCell.RowIndex].Cells[0].Value.ToString()).ToList());
                MessageBox.Show("Xóa url thành công");
                docUrl(filename);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn dòng nhập Url cần xóa");
            }
        }

        private void FormQuanLyAPI_Load(object sender, EventArgs e)
        {

        }
    }

}
