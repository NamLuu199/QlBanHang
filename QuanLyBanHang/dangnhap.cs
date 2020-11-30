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
        public static string SetValueForText1 = "";
        public static string checkQuyen ="";
        public static string MaNV = "";
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
                var admin = data.NhanViens.Where(p => p.username.Contains(textBox1.Text) && p.password.Contains(textBox2.Text)).Select(p => new {p.MaNV, p.TenNhanVien,p.username, p.password, p.MaQuyen });
                if (admin.Any())
                {
                    Admin ad = new Admin();
                    foreach(var item in admin)
                    {
                        SetValueForText1 = item.TenNhanVien;
                        MaNV = item.MaNV;
                        checkQuyen = item.MaQuyen;
                    }
                    ad.Show();
                    this.Hide();
                } 
                if(!admin.Any())
                {
                    MessageBox.Show("Kiểm tra lại username và password");
                }
            }

        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
