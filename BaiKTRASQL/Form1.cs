using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.Common;



namespace BaiKTRASQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=HGIA;Initial Catalog=QuanLyGiaiDau;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
        String ma;

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
        //--------------------------------Bảng Giải Đấu---------------------------------------------------------
        private void tabPage1_Click(object sender, EventArgs e)
        {

            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from GiaiDau";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaGiaiDau"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["MaDoiBong"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["TenDoiBong"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["NgayBatDau"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["NgayKetThuc"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["MaGiaiDau"].Value.ToString();
            }
        }
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex == -1) { return; }
        //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        //    ma = row.Cells[0].Value.ToString();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            string magd = textBox1.Text;
            string madb = textBox2.Text;
            string tendb = textBox3.Text;
            string ngaybd = textBox4.Text;
            string ngaykt = textBox5.Text;
            string diadiem = textBox6.Text;
            ketnoi.Open();
            sql = @"insert into GiaiDau
            values
            (N'" + magd + "', N'" + madb + "', N'" + tendb + "',N'" + ngaybd + "', N'" + ngaykt + "',N'" + diadiem + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from GiaiDau";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
            
        }
        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
        }

        

        public void xoa()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete GiaiDau where MaGiaiDau ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from GiaiDau";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string magd = textBox1.Text;
            string madb = textBox2.Text;
            string tendb = textBox3.Text;
            string ngaybd = textBox4.Text;
            string ngaykt = textBox5.Text;
            string diadiem = textBox6.Text;
            string Vitri = textBox7.Text;
            ketnoi.Open();
            sql = @"update GiaiDau set
            MaGiaiDau = N'" + magd + "', MaDoiBong = N'" + madb + "', TenDoiBong = N'" + tendb + "', NgayBatDau = N'" + ngaybd + "', NgayKetThuc = N'" + ngaykt + "', DiaDiem = N'" + diadiem + "'" + $" where MaGiaiDau = N'" + Vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            textBox7.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from GiaiDau";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "MaGiaiDau")
            {
                sql = @"select MaGiaiDau from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "MaDoiBong")
            {
                sql = @"select MaDoiBong from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "TenDoiBong")
            {
                sql = @"select TenDoiBong from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "NgayBatDau")
            {
                sql = @"select NgayBatDau from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "NgayKetThuc")
            {
                sql = @"select NgayKetThuc from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "DiaDiem")
            {
                sql = @"select DiaDiem from GiaiDau";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from DoiBong";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from CauThu";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from TranDau";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from BanThang";
            hienthi();
            dataGridView5.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }
//----------------------------------------------------Bảng Đội Bóng---------------------------------------------
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["MaDoiBong"].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["TenDoiBong"].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["HLV"].Value.ToString();
                textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells["MaDoiBong"].Value.ToString();
                
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }
        bool valid = false;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "MaDoiBong")
            {
                sql = @"select MaGiaiDau from DoiBong";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "TenDoiBong")
            {
                sql = @"select MaGiaiDau from DoiBong";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "HLV")
            {
                sql = @"select MaGiaiDau from DoiBong";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string madb = textBox8.Text;
            string tendb = textBox9.Text;
            string hlv = textBox10.Text;
        

            ketnoi.Open();
            sql = @"insert into DoiBong
            values
            (N'" + madb + "', N'" + tendb + "', N'" + hlv + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from DoiBong";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete DoiBong where MaDoiBong ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from DoiBong";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string mdb = textBox8.Text;
            string tbd = textBox9.Text;
            string hlv = textBox10.Text;
          
            string Vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update DoiBong set
            MaDoiBong = N'" + mdb + "', TenDoiBong = N'" + tbd + "', HLV = N'" + hlv + "'" + $" where DoiBong = N'" + Vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from DoiBong";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox12.Text = dataGridView3.Rows[e.RowIndex].Cells["MaCauThu"].Value.ToString();
                textBox13.Text = dataGridView3.Rows[e.RowIndex].Cells["TenCauThu"].Value.ToString();
                textBox14.Text = dataGridView3.Rows[e.RowIndex].Cells["MaDoiBong"].Value.ToString();
                textBox15.Text = dataGridView3.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString();
                textBox16.Text = dataGridView3.Rows[e.RowIndex].Cells["QueQuan"].Value.ToString();
                textBox17.Text = dataGridView3.Rows[e.RowIndex].Cells["ChieuCao"].Value.ToString();
                textBox18.Text = dataGridView3.Rows[e.RowIndex].Cells["CanNang"].Value.ToString();
                textBox18.Text = dataGridView3.Rows[e.RowIndex].Cells["MaCauThu"].Value.ToString();

            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "MaCauThu")
            {
                sql = @"select MaCauThu from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "TenCauThu")
            {
                sql = @"select TenCauThu from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "MaDoiBong")
            {
                sql = @"select MaDoiBong from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
          
            if (select == "NgaySinh")
            {
                sql = @"select NgaySinh from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "QueQuan")
            {
                sql = @"select QueQuan from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "ChieuCao")
            {
                sql = @"select ChieuCao from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            if (select == "CanNang")
            {
                sql = @"select CanNang from CauThu";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
