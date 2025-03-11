﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace BTL_QuanLyQuanNet
{
    public partial class NapTien: Form
    {
        ConnectDatabase db = new ConnectDatabase();
        public NapTien()
        {
            InitializeComponent();
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            db.moKN();
            string queryCheck = "select count(*) from KHACHHANG where Taikhoan = '" + txtTaikhoan.Text + "'";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, db.GetConnection());
            int res = (int)cmdCheck.ExecuteScalar();
            
            if (res == 1)
            {
                string queryUpdate = "update KHACHHANG set Sodu = Sodu + " + txtSoTien.Text + " where Taikhoan = '" + txtTaikhoan.Text + "'";
                string QueryLichsu = "insert into LICHSU (Taikhoan, Mota) values ('" + txtTaikhoan.Text + "', N'Đã được nạp " + txtSoTien.Text + "')";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, db.GetConnection());
                SqlCommand cmdLichsu = new SqlCommand(QueryLichsu, db.GetConnection());
                cmdUpdate.ExecuteNonQuery();
                cmdLichsu.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            db.dongKN();
            MessageBox.Show("Đã được nạp 10000.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
