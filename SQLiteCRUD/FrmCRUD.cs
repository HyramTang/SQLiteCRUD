using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLiteCRUD
{
    public partial class FrmCRUD : Form
    {
        public FrmCRUD()
        {
            InitializeComponent();
        }
        SQLiteDAL DAL = new SQLiteDAL();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string SQLInserData = @"INSERT INTO Users (UserName,Password)VALUES('" + txtUserName.Text + "','" + txtPassword.Text + "')";
            try
            {
                if (DAL.RUD(SQLInserData))
                    Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            dataGridView1.DataSource = DAL.Select("SELECT * FROM Users");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
