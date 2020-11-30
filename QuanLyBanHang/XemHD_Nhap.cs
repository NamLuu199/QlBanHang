using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class XemHD_Nhap : Form
    {
        public XemHD_Nhap()
        {
            InitializeComponent();
        }
        string id;
        DataClasses3DataContext db = new DataClasses3DataContext();
        private void XemHD_Nhap_Load(object sender, EventArgs e)
        {

            load_ct();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        public void load_ct()
        {
            
            var q1 = from nt in db.ChiTiet_HDNhaps
                     join nk in db.NhapKhos
                     on nt.MaSP equals nk.MaSP
                     where nt.MaHDB == Admin.maHD
                     select new { nk.MaSP, nk.TenSP, nt.GiaNhap, nt.SoLuongNhap, nt.NgayHetHan, nt.ID };
            dataGridView1.DataSource = q1;
            dataGridView1.Columns[5].Visible = false;


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                id = row.Cells[5].Value.ToString();
                DateTime formatDate = DateTime.Parse(row.Cells[4].Value.ToString()); // get date
                dateTimePicker1.Value = formatDate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime formatDate = DateTime.Parse(dateTimePicker1.Text); // get date
            var nk = db.ChiTiet_HDNhaps.Single(p => p.ID == Convert.ToInt32(id));
            nk.MaSP = textBox1.Text;
            nk.GiaNhap = Convert.ToInt32(textBox2.Text);
            nk.SoLuongNhap = Convert.ToInt32(textBox4.Text);    
            nk.NgayHetHan = formatDate;
            db.SubmitChanges();
            load_ct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
