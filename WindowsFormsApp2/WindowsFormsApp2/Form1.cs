using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string pathData = Application.StartupPath + @"\Data\Contacts.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList ds = Contacts.GetListGroup(pathData);
            foreach(string i in ds)
            {
                dgvGroup.Rows.Add(i);
            }
            if (File.Exists(pathData))
            {
                var listLines = File.ReadAllLines(pathData);
                string data = dgvGroup.Rows[0].Cells[0].FormattedValue.ToString();
                if (data != null)
                {
                    foreach (var line in listLines)
                    {
                        var rs = line.Split(new char[] { '#' });
                        if (string.Compare(data, rs[0], true) == 0)
                        {
                            dgvContacts.Rows.Add(rs[1], rs[2], rs[3]);
                        }
                    }
                }
                if (dgvContacts.Rows[0].Cells[0].Value != null)
                {
                    string name = dgvContacts.Rows[0].Cells[0].FormattedValue.ToString();
                    Contacts lh = Contacts.GetContact(pathData, name);
                    lblTenGoi.Text = name;
                    lblDiaChi.Text = lh.Address;
                    lblEmail.Text = lh.Email;
                    lblSDT.Text = lh.Phone;
                }
            }
        }
        private void DgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                dgvContacts.Rows.Clear();
                if (File.Exists(pathData))
                {
                    var listLines = File.ReadAllLines(pathData);
                    string data = dgvGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
                    if (data != null)
                    {
                        foreach (var line in listLines)
                        {
                            var rs = line.Split(new char[] { '#' });
                            if (string.Compare(data, rs[0], true) == 0)
                            {
                                dgvContacts.Rows.Add(rs[1], rs[2], rs[3]);
                            }
                        }
                    }
                    if (dgvContacts.Rows[0].Cells[0].Value != null)
                    {
                        string name = dgvContacts.Rows[0].Cells[0].FormattedValue.ToString();
                        Contacts lh = Contacts.GetContact(pathData, name);
                        lblTenGoi.Text = name;
                        lblDiaChi.Text = lh.Address;
                        lblEmail.Text = lh.Email;
                        lblSDT.Text = lh.Phone;
                    }
                }
            }
        }

        private void DgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string name= dgvContacts.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                Contacts lh = Contacts.GetContact(pathData, name);
                lblTenGoi.Text = name;
                lblDiaChi.Text = lh.Address;
                lblEmail.Text = lh.Email;
                lblSDT.Text = lh.Phone;
            }
        }

        private void TsbXoaLienLac_Click(object sender, EventArgs e)
        {
            dgvContacts.Rows.RemoveAt(dgvContacts.CurrentCell.RowIndex);
            bdsContacts.DataSource = dgvContacts.DataSource;

        }

        private void TsbXoaNhom_Click(object sender, EventArgs e)
        {
            dgvGroup.Rows.RemoveAt(dgvGroup.CurrentCell.RowIndex);
            bdsGroups.DataSource = dgvGroup.DataSource;
        }

        private void TsbThemNhom_Click(object sender, EventArgs e)
        {

        }

        private void TsbThemLienLac_Click(object sender, EventArgs e)
        {
            var frm = new frmAddContact(dgvContacts,"Thêm liên lạc");
            frm.ShowDialog();
        }
    }
}
