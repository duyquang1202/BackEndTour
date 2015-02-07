namespace TourDuLich
{
    partial class FormChiTietTour
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtChuongTrinhTours = new System.Windows.Forms.TextBox();
            this.dgvTourCungLoai = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDSKhachSan = new System.Windows.Forms.DataGridView();
            this.dgvDanhSachPhuongTien = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTourCungLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhuongTien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi tiết tour";
            // 
            // txtChuongTrinhTours
            // 
            this.txtChuongTrinhTours.Location = new System.Drawing.Point(26, 53);
            this.txtChuongTrinhTours.Multiline = true;
            this.txtChuongTrinhTours.Name = "txtChuongTrinhTours";
            this.txtChuongTrinhTours.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChuongTrinhTours.Size = new System.Drawing.Size(449, 133);
            this.txtChuongTrinhTours.TabIndex = 1;
            this.txtChuongTrinhTours.TextChanged += new System.EventHandler(this.txtChuongTrinhTours_TextChanged);
            // 
            // dgvTourCungLoai
            // 
            this.dgvTourCungLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTourCungLoai.Location = new System.Drawing.Point(26, 408);
            this.dgvTourCungLoai.Name = "dgvTourCungLoai";
            this.dgvTourCungLoai.Size = new System.Drawing.Size(449, 97);
            this.dgvTourCungLoai.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Đặt tour";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khách sạn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phương tiện";
            // 
            // dgvDSKhachSan
            // 
            this.dgvDSKhachSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKhachSan.Location = new System.Drawing.Point(26, 225);
            this.dgvDSKhachSan.Name = "dgvDSKhachSan";
            this.dgvDSKhachSan.Size = new System.Drawing.Size(449, 59);
            this.dgvDSKhachSan.TabIndex = 7;
            // 
            // dgvDanhSachPhuongTien
            // 
            this.dgvDanhSachPhuongTien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachPhuongTien.Location = new System.Drawing.Point(26, 317);
            this.dgvDanhSachPhuongTien.Name = "dgvDanhSachPhuongTien";
            this.dgvDanhSachPhuongTien.Size = new System.Drawing.Size(449, 59);
            this.dgvDanhSachPhuongTien.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Các tour cùng loại";
            // 
            // FormChiTietTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 556);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDanhSachPhuongTien);
            this.Controls.Add(this.dgvDSKhachSan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvTourCungLoai);
            this.Controls.Add(this.txtChuongTrinhTours);
            this.Controls.Add(this.label1);
            this.Name = "FormChiTietTour";
            this.Text = "FormChiTietTour";
            this.Load += new System.EventHandler(this.FormChiTietTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTourCungLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhuongTien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChuongTrinhTours;
        private System.Windows.Forms.DataGridView dgvTourCungLoai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDSKhachSan;
        private System.Windows.Forms.DataGridView dgvDanhSachPhuongTien;
        private System.Windows.Forms.Label label4;
    }
}