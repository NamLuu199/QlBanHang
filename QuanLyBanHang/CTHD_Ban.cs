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
    public partial class CTHD_Ban : Form
    {
        public CTHD_Ban()
        {
            InitializeComponent();
        }
        DataClasses3DataContext db = new DataClasses3DataContext();
        DataClasses3DataContext db2 = new DataClasses3DataContext();
        private void CTHD_Ban_Load(object sender, EventArgs e)
        {
            textBox1.Text = Admin.maHD;
            var q5 = from xk in db.XuatKhos
                     join nk in db.NhapKhos
                     on xk.MaSP equals nk.MaSP
                     select new { xk.MaSP,xk.MaQuay, xk.TenQuay, nk.TenSP, nk.GiaBan, xk.SoLuongXuat };
            dataGridView1.DataSource = q5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            dataGridView2.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString()); // add row
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                try
                {
                    ChiTiet_HDBan ct = new ChiTiet_HDBan();
                    ct.MaHD = textBox1.Text;
                    ct.MaSP = dr.Cells[0].Value.ToString();
                    ct.SoLuong = Convert.ToInt32(dr.Cells[3].Value.ToString());
                    ct.GiaBan = Convert.ToInt32(dr.Cells[2].Value.ToString());
                    ct.ThanhTien = Convert.ToInt32(dr.Cells[4].Value.ToString());
                    db.ChiTiet_HDBans.InsertOnSubmit(ct);
                    db.SubmitChanges();
                }
                catch (NullReferenceException)
                {
                    // check ngoại lệ trường null
                }
            }
            MessageBox.Show("Thêm hóa đơn thành công");
            this.Close();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int sum = 0;
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    int n = item.Index;
                    dataGridView2.Rows[n].Cells[4].Value = (
                        int.Parse(dataGridView2.Rows[n].Cells[2].Value.ToString()) * int.Parse(dataGridView2.Rows[n].Cells[3].Value.ToString())).ToString();
                    sum += Convert.ToInt32(dataGridView2.Rows[n].Cells[4].Value.ToString());
                    textBox2.Text = sum.ToString();
                }
                
            }
            catch(NullReferenceException)
            {
                
            }
            catch(FormatException)
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu");
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string text = textBox5.Text;
            var q5 = from xk in db.XuatKhos
                     join nk in db.NhapKhos
                     on xk.MaSP equals nk.MaSP
                     where nk.MaSP.Contains(text) || nk.TenSP.Contains(text)
                     select new { xk.MaQuay, xk.TenQuay, xk.MaSP, nk.TenSP, nk.GiaBan, xk.SoLuongXuat };
            dataGridView1.DataSource = q5;
        }

        private void button2_Click(object sender, EventArgs e)
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
            int dem = 5;
            Microsoft.Office.Interop.Excel.Worksheet x = obj.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            x.Range[obj.Cells[1, 1], obj.Cells[1, 4]].Merge();
            for (int i = 2; i < dataGridView2.Columns.Count; i++)
            {
                obj.Cells[3, i - 1] = dataGridView2.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView2.Columns.Count - 1; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 4, j] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        dem += i;
                    }
                }
            }
            obj.Cells[dem, 1] = "Tổng tiền: ";
            obj.Cells[dem, 2] = string.Format("{0:#,##0}", textBox2.Text) + " VNĐ";
            obj.Columns.AutoFit();
            obj.Visible = true;
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
