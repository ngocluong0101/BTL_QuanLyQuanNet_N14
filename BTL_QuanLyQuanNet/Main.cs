﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyQuanNet
{
    public partial class Main: Form
    {
        private Form CurrentChildForm;
        public Main()
        {
            InitializeComponent();
            this.Size = this.ClientSize;
        }

        private void OpenChildForm(Form ChildForm)
        {
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            CurrentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTinhtrangmay_Click(object sender, EventArgs e)
        {
            lblTieude.Text = btnTinhtrangmay.Text;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
            lblTieude.Text = btnKhachhang.Text;
        }
    }
}
