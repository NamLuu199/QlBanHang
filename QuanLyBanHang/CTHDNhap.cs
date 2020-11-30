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
    public partial class CTHDNhap : Form
    {
        public CTHDNhap()
        {
            InitializeComponent();
        }
        DataClasses3DataContext db = new DataClasses3DataContext();
        private void CTHDNhap_Load(object sender, EventArgs e)
        {
            textBox1.Text = Admin.maHD;
            var data = db.NhapKhos.Select(p => new { p.MaSP, p.TenSP, p.NCC, p.MaDV });
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            dataGridView2.Rows.Add(row.Cells[0].Value.ToString()); // add row
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.Cancel)
            {
                MessageBox.Show("Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                try
                {
                    ChiTiet_HDNhap ct = new ChiTiet_HDNhap();
                    ct.MaHDB = textBox1.Text;
                    ct.MaSP = dr.Cells[0].Value.ToString();
                    ct.GiaNhap = Convert.ToInt32(dr.Cells[1].Value.ToString());
                    ct.SoLuongNhap = Convert.ToInt32(dr.Cells[2].Value.ToString());
                    DateTime formatDate = DateTime.Parse(dr.Cells[3].Value.ToString()); // get date
                    ct.NgayHetHan = formatDate;
                    db.ChiTiet_HDNhaps.InsertOnSubmit(ct);
                    db.SubmitChanges();
                }
                catch(NullReferenceException)
                {
                    // check ngoại lệ trường null
                }
            }
            MessageBox.Show("Thêm hóa đơn thành công");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Admin.maHD;
            string ten = textBox5.Text;
            var data = db.NhapKhos.Where(x => x.TenSP.Contains(ten) || x.MaSP.Contains(ten) ).Select(p => new { p.MaSP, p.TenSP, p.NCC, p.MaDV });
            dataGridView1.DataSource = data;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedCount = dataGridView2.SelectedRows.Count;
            while (selectedCount > 0)
            {
                if (!dataGridView2.SelectedRows[0].IsNewRow)
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                selectedCount--;
            }
        }
    }
}
