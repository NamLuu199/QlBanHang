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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ username và password");
            }else
            {
                DataClasses3DataContext data = new DataClasses3DataContext();
                var admin = data.NhanViens.Where(p => p.username.Contains(textBox1.Text) && p.password.Contains(textBox2.Text) && p.MaQuyen == "2").Select(p => new { p.username, p.password, p.MaQuyen });
                if (admin.Any())
                {
                    Admin ad = new Admin();
                    ad.Show();
                    this.Hide();
                } 
                var staff = data.NhanViens.Where(p => p.username.Contains(textBox1.Text) && p.password.Contains(textBox2.Text) && p.MaQuyen == "1").Select(p => new { p.username, p.password, p.MaQuyen });
                if (staff.Any())
                {
                    frmNhanViencs nv = new frmNhanViencs();
                    nv.Show();
                    this.Hide();
                }
                if(!admin.Any() && !staff.Any())
                {
                    MessageBox.Show("Kiểm tra lại username và password");
                }
            }

        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
