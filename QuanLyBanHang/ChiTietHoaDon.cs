using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
using style = Microsoft.Office.Interop.Excel.Workbook;

namespace QuanLyBanHang
{
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        string id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox6.Text = row.Cells[3].Value.ToString();
                id = row.Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        DataClasses3DataContext db = new DataClasses3DataContext();
        
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {


            load_bliss();
            try
            {
                int sum = 0;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    int n = item.Index;
                    dataGridView1.Rows[n].Cells[4].Value = (
                        int.Parse(dataGridView1.Rows[n].Cells[2].Value.ToString()) * int.Parse(dataGridView1.Rows[n].Cells[3].Value.ToString())).ToString();
                    sum += Convert.ToInt32(dataGridView1.Rows[n].Cells[4].Value.ToString());
                    
                }
                label5.Text = string.Format("{0:#,##0}", sum) + " VNĐ";


            }
            catch (NullReferenceException)
            {

            }

        }
        public void load_bliss()
        {
            var q1 = from nt in db.ChiTiet_HDBans
                     join nk in db.NhapKhos
                     on nt.MaSP equals nk.MaSP
                     where nt.MaHD == Admin.maHD
                     select new { nk.MaSP, nk.TenSP, nt.GiaBan, nt.SoLuong, nt.ThanhTien,nt.ID };
            dataGridView1.DataSource = q1;
            dataGridView1.Columns[5].Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            // get header text colmumns
            obj.Cells[1, 1] = "Hóa Đơn bán hàng";
            obj.Cells[2, 1] = "Tên khách hàng: ";
            obj.Cells[2, 2] = Admin.TenKH;

            obj.Cells[2, 3] = "Ngày: ";
            obj.Cells[2, 4] = Convert.ToDateTime(Admin.date).ToString("dd/MM/yyyy");
            int dem = 2;
            Microsoft.Office.Interop.Excel.Worksheet x = obj.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            x.Range[obj.Cells[1, 1], obj.Cells[1, 4]].Merge();
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                obj.Cells[3, i - 1] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count - 1; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 4, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        dem += i;
                    }
                }
            }
            obj.Cells[dem, 1] = "Tổng tiền: ";
            obj.Cells[dem,2] = label5.Text;
            obj.Columns.AutoFit();
            obj.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nk = db.ChiTiet_HDBans.Single(p => p.ID == Convert.ToInt32(id));
            nk.MaSP = textBox1.Text;
            nk.GiaBan = Convert.ToInt32(textBox4.Text); 
            nk.SoLuong = Convert.ToInt32(textBox6.Text);
            int thanhtien = Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox6.Text);
            nk.ThanhTien = thanhtien;
            db.SubmitChanges();
            load_bliss();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nk = db.ChiTiet_HDBans.Single(p => p.ID == Convert.ToInt32(id));
            db.ChiTiet_HDBans.DeleteOnSubmit(nk);
            db.SubmitChanges();
            load_bliss();
        }
    }
}
