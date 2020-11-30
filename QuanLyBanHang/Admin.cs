using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    
    public partial class Admin : Form
    {
        public static string maHD = "";
        public static string TenKH = "";
        public static string date = ""; 
        public Admin()
        {
            InitializeComponent();
        }
        DataClasses3DataContext db = new DataClasses3DataContext();
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            textBox13.Text = textBox6.Text = dangnhap.SetValueForText1; // Lấy tên nhân viên
            textBox6.Enabled = textBox13.Enabled = false;

            var load_quyen = db.Quyens.Select(p => new { p.MaQuyen, p.TenQuyen });
            comboBox1.DataSource = load_quyen;
            comboBox1.DisplayMember = "TenQuyen";
            comboBox1.ValueMember = "MaQuyen";
            // Show data nhanvien
            var q = db.NhanViens.Select(p => new { p.MaNV, p.TenNhanVien, p.DiaChi, p.SoDienThoai, p.MaQuyen, p.username, p.password });
            dataGridView4.DataSource = q;
            // Show data NCC
            var q2 = db.NCCs.Select(p => new { p.MaNCC, p.TenNCC, p.SoDienThoai, p.DiaChi });
            dataGridView5.DataSource = q2;
            // Show data Donvi
            var q3 = db.DonVis.Select(p => new { p.MaDV, p.TenDV });
            dataGridView6.DataSource = q3;
            // Show kho sp

            var q4 = from nk in db.NhapKhos
                     join ncc in db.NCCs
                     on nk.MaNCC equals ncc.MaNCC
                     join dv in db.DonVis
                     on nk.MaDV equals dv.MaDV
                     select new { nk.MaSP, nk.TenSP, dv.TenDV, nk.GiaBan, ncc.TenNCC };
            dataGridView1.DataSource = q4;
            comboBox3.DataSource = q3;
            comboBox3.DisplayMember = "TenDV";
            comboBox3.ValueMember = "MaDV";

            comboBox2.DataSource = q2;
            comboBox2.DisplayMember = "TenNCC";
            comboBox2.ValueMember = "MaNCC";

            // Show khi sp xuất

            
            var q6 = from hd in db.HDNhaps
                     join nv in db.NhanViens
                     on hd.MaNV equals nv.MaNV
                     select new { hd.MaHDB, nv.TenNhanVien, hd.NgayNhap };
            dataGridView7.DataSource = q6;

            
            var q5 = from xk in db.XuatKhos 
                     join nk in db.NhapKhos
                     on xk.MaSP equals nk.MaSP
                     select new { xk.MaQuay, xk.TenQuay, xk.MaSP,nk.TenSP,nk.GiaBan, xk.SoLuongXuat };
            dataGridView2.DataSource = q5;

            // show hd bán

            var q7 = from hd in db.HDBans
                     join nv in db.NhanViens
                     on hd.MaNV equals nv.MaNV
                     select new { hd.MaHD, nv.TenNhanVien, hd.TenKhachHang, hd.date };
            dataGridView3.DataSource = q7;

            // show sản phẩm đã nhập
            var q8 = from ct in db.ChiTiet_HDNhaps
                     join nk in db.NhapKhos
                     on ct.MaSP equals nk.MaSP
                     select new { ct.MaHDB, nk.TenSP, ct.GiaNhap, ct.SoLuongNhap, ct.NgayHetHan };
            dataGridView8.DataSource = q8;

            // show tổng số lượng theo mặt hàng
            var q9 = from ct in db.ChiTiet_HDNhaps
                     join nk in db.NhapKhos
                     on ct.MaSP equals nk.MaSP
                     group ct by new { nk.TenSP,nk.MaSP,ct.GiaNhap } into kq
                     select new { MaSP= kq.Key.MaSP, TenSP=kq.Key.TenSP,GiaNhap= kq.Key.GiaNhap, TongSL=kq.Sum(t=>t.SoLuongNhap) };
            dataGridView9.DataSource = q9;


            // Custom layout with permission
            int convertInt = Convert.ToInt32(dangnhap.checkQuyen);
            if(convertInt == 1)
            {
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage7);
            }
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }
        public void load_ncc()
        {
            var q2 = db.NCCs.Select(p => new { p.MaNCC, p.TenNCC, p.SoDienThoai, p.DiaChi });
            dataGridView5.DataSource = q2;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            
            NCC ncc = new NCC();
            ncc.MaNCC = textBox27.Text;
            ncc.TenNCC = textBox26.Text;
            ncc.SoDienThoai = textBox25.Text;
            ncc.DiaChi = textBox24.Text;
            db.NCCs.InsertOnSubmit(ncc);
            db.SubmitChanges();
            load_ncc();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            NCC ncc = db.NCCs.Single(p => p.MaNCC == textBox27.Text);
            db.NCCs.DeleteOnSubmit(ncc);
            db.SubmitChanges();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
            var q = db.NCCs.Select(p => new { p.MaNCC, p.TenNCC, p.SoDienThoai, p.DiaChi });
            dataGridView5.DataSource = q;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon ct = new ChiTietHoaDon();
            ct.Show();

        }
        public void loadnv()
        {
            var nv = db.NhanViens.Select(p => new { p.MaNV, p.TenNhanVien, p.DiaChi, p.SoDienThoai, p.MaQuyen, p.username, p.password });
            dataGridView4.DataSource = nv;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "MaQuyen"; // lọc lại giá trị nhận về
            NhanVien nv = new NhanVien();
            nv.MaNV = textBox19.Text;
            nv.TenNhanVien = textBox18.Text;
            nv.DiaChi = textBox17.Text;
            nv.SoDienThoai = textBox16.Text;
            nv.username = textBox20.Text;
            nv.password = textBox21.Text;
            nv.MaQuyen = comboBox1.SelectedValue.ToString();
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            loadnv();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var nv = db.NhanViens.Single(p => p.MaNV == textBox19.Text);
            nv.TenNhanVien = textBox18.Text;
            nv.DiaChi = textBox17.Text;
            nv.SoDienThoai = textBox16.Text;
            nv.username = textBox20.Text;
            nv.password = textBox21.Text;
            nv.MaQuyen = comboBox1.SelectedValue.ToString();
            db.SubmitChanges();
            loadnv();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                textBox19.Text = row.Cells[0].Value.ToString();
                textBox18.Text = row.Cells[1].Value.ToString();
                textBox17.Text = row.Cells[2].Value.ToString();
                textBox16.Text = row.Cells[3].Value.ToString();
                textBox20.Text = row.Cells[5].Value.ToString();
                textBox15.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var nv = db.NhanViens.Single(p => p.MaNV == textBox19.Text);
            db.NhanViens.DeleteOnSubmit(nv);
            db.SubmitChanges();
            loadnv();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var ncc = db.NCCs.Single(p => p.MaNCC == textBox27.Text);
            db.NCCs.DeleteOnSubmit(ncc);
            db.SubmitChanges();
            load_ncc();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
                textBox27.Text = row.Cells[0].Value.ToString();
                textBox26.Text = row.Cells[1].Value.ToString();
                textBox25.Text = row.Cells[2].Value.ToString();
                textBox24.Text = row.Cells[3].Value.ToString();
              
            }
        }
        public void load_dv()
        {
            var q3 = db.DonVis.Select(p => new { p.MaDV, p.TenDV });
            dataGridView6.DataSource = q3;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            DonVi dv = new DonVi();
            dv.MaDV = textBox30.Text;
            dv.TenDV = textBox29.Text;
            db.DonVis.InsertOnSubmit(dv);
            db.SubmitChanges();
            load_dv();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView6.Rows[e.RowIndex];
                textBox30.Text = row.Cells[0].Value.ToString();
                textBox29.Text = row.Cells[1].Value.ToString();

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var dv = db.DonVis.Single(p => p.MaDV == textBox30.Text);
            dv.MaDV = textBox30.Text;
            dv.TenDV = textBox29.Text;
            db.SubmitChanges();
            load_dv();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var dv = db.DonVis.Single(p => p.MaDV == textBox30.Text);
            db.DonVis.DeleteOnSubmit(dv);
            db.SubmitChanges();
            load_dv();
        }
        public void loadkho()
        {
            var q4 = from nk in db.NhapKhos
                              join ncc in db.NCCs
                              on nk.MaNCC equals ncc.MaNCC
                              join dv in db.DonVis
                              on nk.MaDV equals dv.MaDV
                              select new { nk.MaSP, nk.TenSP, dv.TenDV, nk.GiaBan, ncc.TenNCC };
            dataGridView1.DataSource = q4;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                comboBox3.ValueMember = "MaDV"; // lọc lại giá trị nhận về
                comboBox2.ValueMember = "MaNCC"; // lọc lại giá trị nhận về

                NhapKho nk = new NhapKho();
                nk.MaSP = textBox1.Text;
                nk.TenSP = textBox2.Text;
                nk.GiaBan = Convert.ToInt32(textBox4.Text);
                nk.MaDV = comboBox3.SelectedValue.ToString();
                nk.MaNCC = comboBox2.SelectedValue.ToString();

                db.NhapKhos.InsertOnSubmit(nk);
                db.SubmitChanges();
                loadkho();
            }
            catch(SqlException)
            {
                MessageBox.Show("Khóa chính đã tồn tại");
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox3.Text = row.Cells[2].Value.ToString();
                comboBox2.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox3.ValueMember = "MaDV"; // lọc lại giá trị nhận về
            comboBox2.ValueMember = "MaNCC"; // lọc lại giá trị nhận về
          
            var nk = db.NhapKhos.Single(p => p.MaSP == textBox1.Text);
            nk.MaSP = textBox1.Text;
            nk.TenSP = textBox2.Text;
            nk.GiaBan = Convert.ToInt32(textBox4.Text);
            nk.MaDV = comboBox3.SelectedValue.ToString();
            nk.MaNCC = comboBox2.SelectedValue.ToString();
            
            db.SubmitChanges();
            loadkho();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nk = db.NhapKhos.Single(p => p.MaSP == textBox1.Text);
            db.NhapKhos.DeleteOnSubmit(nk);
            db.SubmitChanges();
            loadkho();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            var row = dataGridView1.CurrentRow;

            textBox8.Text = row.Cells[0].Value.ToString();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        public void xuatkho()
        {
            var q5 = from xk in db.XuatKhos
                     join nk in db.NhapKhos
                     on xk.MaSP equals nk.MaSP
                     select new { xk.MaQuay, xk.TenQuay, xk.MaSP, nk.TenSP, nk.GiaBan, xk.SoLuongXuat };
            dataGridView2.DataSource = q5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox22.Text);
                XuatKho xk = new XuatKho();
                xk.MaQuay = textBox10.Text;
                xk.TenQuay = textBox9.Text;
                xk.MaSP = textBox8.Text;
                xk.SoLuongXuat = number;
                db.XuatKhos.InsertOnSubmit(xk);
                db.SubmitChanges();
                xuatkho();
                // Update số lượng kho
               // DataClasses3DataContext db2 = new DataClasses3DataContext();
                //var update = db2.NhapKhos.Single(p => p.MaSP == textBox8.Text);
               // update.SoLuongNhap = update.SoLuongNhap - number;
               // db2.SubmitChanges();
               //loadkho();
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Mã SP đã tồn tại");
                }
                if (ex.Number == 2601) // Cannot insert duplicate key row in object error
                {
                    MessageBox.Show("Mã SP đã tồn tại");
                    // handle duplicate key error
                    return;
                }
            }




        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var xk = db.XuatKhos.Single(p => p.MaQuay == textBox10.Text);
            xk.MaQuay = textBox10.Text;
            xk.TenQuay = textBox9.Text;
            xk.MaSP = textBox8.Text;
            xk.SoLuongXuat = Convert.ToInt32(textBox22.Text);
            db.SubmitChanges();
            xuatkho();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var xk = db.XuatKhos.Single(p => p.MaQuay == textBox10.Text);
            db.XuatKhos.DeleteOnSubmit(xk);
            db.SubmitChanges();
            xuatkho();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox10.Text = row.Cells[0].Value.ToString();
                textBox9.Text = row.Cells[1].Value.ToString();
                textBox8.Text = row.Cells[2].Value.ToString();
                textBox22.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            DateTime formatDate = DateTime.Parse(dateTimePicker2.Text); // get date
            HDBan hd = new HDBan();
            hd.MaHD = maHD = textBox14.Text;
            hd.date = formatDate;
            date = formatDate.ToString();
            hd.MaNV = dangnhap.MaNV;
            hd.TenKhachHang = TenKH = textBox12.Text;
            db.HDBans.InsertOnSubmit(hd);
            db.SubmitChanges();
            CTHD_Ban ct = new CTHD_Ban();
            ct.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime formatDate = DateTime.Parse(dateTimePicker1.Text); // get date
                HDNhap hd = new HDNhap();
                hd.MaHDB = maHD = textBox7.Text;
                hd.MaNV = dangnhap.MaNV;
                hd.NgayNhap = formatDate;
                db.HDNhaps.InsertOnSubmit(hd);
                db.SubmitChanges();
                CTHDNhap ct = new CTHDNhap();
                ct.Show();

            }
            catch(SqlException)
            {
                MessageBox.Show("Mã Hóa Đơn đã tồn tại");
            }
            
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            XemHD_Nhap view = new XemHD_Nhap();
            view.Show();
        }

        private void dataGridView7_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView7.Rows[e.RowIndex];
                maHD = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                maHD = row.Cells[0].Value.ToString();
                TenKH = row.Cells[2].Value.ToString();
                date = row.Cells[3].Value.ToString();
            }
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl2.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
                
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            string Name = textBox5.Text;
            string codeSP = Name;
            var q4 = from nk in db.NhapKhos
                     join ncc in db.NCCs
                     on nk.MaNCC equals ncc.MaNCC
                     join dv in db.DonVis
                     on nk.MaDV equals dv.MaDV
                     where nk.TenSP.Contains(Name) || nk.MaSP.Contains(codeSP)
                     select new { nk.MaSP, nk.TenSP, dv.TenDV, nk.GiaBan, ncc.TenNCC };
            dataGridView1.DataSource = q4;
        }
        public void load_HDBan()
        {
            var q7 = from hd in db.HDBans
                     join nv in db.NhanViens
                     on hd.MaNV equals nv.MaNV
                     select new { hd.MaHD, nv.TenNhanVien, hd.TenKhachHang, hd.date };
            dataGridView3.DataSource = q7;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var nk = db.HDBans.Single(p => p.MaHD == maHD);
            db.HDBans.DeleteOnSubmit(nk);
            db.SubmitChanges();
            load_HDBan();
        }
        public void load_HDNhap()
        {
            DateTime formatDate = DateTime.Parse(dateTimePicker1.Text); // get date
            var q6 = from hd in db.HDNhaps
                     join nv in db.NhanViens
                     on hd.MaNV equals nv.MaNV
                     select new { hd.MaHDB, nv.TenNhanVien, hd.NgayNhap };
            dataGridView7.DataSource = q6;
        }
        private void button22_Click(object sender, EventArgs e)
        {
            

            var nk = db.HDNhaps.Single(p => p.MaHDB == maHD); // xóa hd;
            db.HDNhaps.DeleteOnSubmit(nk);
            db.SubmitChanges();
            load_HDNhap();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(dateTimePicker3.Text); // get date
            DateTime endDate = DateTime.Parse(dateTimePicker4.Text); // get date

            var q1 = from nt in db.ChiTiet_HDBans
                     join nk in db.NhapKhos
                     on nt.MaSP equals nk.MaSP
                     join hd in db.HDBans
                     on nt.MaHD equals hd.MaHD
                     join hdn in db.ChiTiet_HDNhaps
                     on nt.MaSP equals hdn.MaSP
                     where hd.date >= startDate && hd.date <= endDate
                     select new { nk.TenSP,hdn.GiaNhap,nt.GiaBan, nt.SoLuong, nt.ThanhTien };
            dataGridView10.DataSource = q1;
            int sumTotal =0;
            int sumCapital = 0;
            int sumReal = 0;
            foreach (DataGridViewRow item in dataGridView10.Rows)
            {
                int n = item.Index;
                
                sumTotal += Convert.ToInt32(dataGridView10.Rows[n].Cells[4].Value.ToString());
                sumCapital += Convert.ToInt32(dataGridView10.Rows[n].Cells[1].Value.ToString())* Convert.ToInt32(dataGridView10.Rows[n].Cells[3].Value.ToString());
                
            }
            sumReal = sumTotal - sumCapital;
            label45.Text = string.Format("{0:#,##0}", sumTotal)+ " VNĐ";
            label46.Text = string.Format("{0:#,##0}", sumCapital) + " VNĐ";
            label47.Text = string.Format("{0:#,##0}", sumReal) + " VNĐ";

        }
    }
}
