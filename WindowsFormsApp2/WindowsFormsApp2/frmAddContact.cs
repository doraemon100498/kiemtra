using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmAddContact : Form
    {
        DataGridView dgvContacts;
        int Rowsnum;
        public frmAddContact(DataGridView dgvContacts, string text, int rowsnum = -1)
        {
            InitializeComponent();
            if (rowsnum != -1)
            {
                Rowsnum = rowsnum;
                this.Text = text;
                this.dgvContacts = dgvContacts;
                txtTenNhom.Text = dgvContacts.Rows[rowsnum].Cells[1].Value.ToString();
                txtTenGoi.Text = dgvContacts.Rows[rowsnum].Cells[2].Value.ToString();
                txtEmail.Text = dgvContacts.Rows[rowsnum].Cells[3].Value.ToString();
                txtSDT.Text = dgvContacts.Rows[rowsnum].Cells[4].Value.ToString();
                txtDiaChi.Text = dgvContacts.Rows[rowsnum].Cells[5].Value.ToString();
            }
            else
            {
                this.Text = text;
                this.dgvContacts = dgvContacts;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (this.Text == "Thêm liên lạc")
            {
                Them();
            }
            else
            {
                Sua();
            }
        }
        private void Them()
        {
            if ( !string.IsNullOrEmpty(txtTenGoi.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtSDT.Text) && !string.IsNullOrEmpty(txtDiaChi.Text))
            {
                dgvContacts.Rows.Add(txtTenGoi.Text, txtEmail, txtSDT);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu còn trống", "Thông báo");
            }
        }
        private void Sua()
        {
            if (!string.IsNullOrEmpty(txtTenGoi.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtSDT.Text) && !string.IsNullOrEmpty(txtDiaChi.Text))
            {
                dgvContacts.Rows[Rowsnum].Cells[0].Value = txtTenGoi.Text;
                dgvContacts.Rows[Rowsnum].Cells[1].Value = txtEmail.Text;
                dgvContacts.Rows[Rowsnum].Cells[2].Value = txtSDT.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu còn trống", "Thông báo");
            }
        }

        private void BtnBoQua_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
