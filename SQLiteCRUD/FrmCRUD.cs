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
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string SQLInserData = @"INSERT INTO Users (UserName,Password)VALUES('" + txtUserName.Text + "','" + txtPassword.Text + "')";
            try
            {
                if (DAL.RUD(SQLInserData))
                    RefreshGridView();
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            lblMsg.Text = "Create Success!";
        }

        private void RefreshGridView()
        {
            dataGridView1.DataSource = DAL.Select("SELECT * FROM Users");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectIndex = this.dataGridView1.SelectedRows[0].Index;
            DataRow rowSelected = ((this.dataGridView1.SelectedRows[0]).DataBoundItem as DataRowView).Row;
            string SqlUpdateData = @"Update Users SET UserName='" + rowSelected["UserName"] + "',Password='" + rowSelected["Password"] + "' WHERE Id=" + rowSelected["Id"] + "";
            try
            {
                if (DAL.RUD(SqlUpdateData))
                    RefreshGridView();
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[SelectIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            lblMsg.Text = "Update Success!";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((DataTable)dataGridView1.DataSource).Rows.Count > 0 && dataGridView1.SelectedRows.Count > 0 && (this.dataGridView1.SelectedRows[0]).DataBoundItem != null)
            {
                DataRow SelectRow = ((this.dataGridView1.SelectedRows[0]).DataBoundItem as DataRowView).Row;
                DAL.RUD("DELETE FROM Users WHERE Id=" + SelectRow[0] + "");
                lblMsg.Text = "Delete Success!";
                RefreshGridView();
                if (dataGridView1.Rows.Count - 2 >= 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;
                }
            }
        }

        private void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            //milliseconds += 100;

            //// The timer has reached the double click time limit.
            //if (milliseconds >= SystemInformation.DoubleClickTime)
            //{
            //    if (isDoubleClick)
            //    {
            //        if (dataGridView1.SelectedRows != null)
            //            SelectedRow = dataGridView1.SelectedRows[0];
            //        dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            //        dataGridView1.ReadOnly = false;
            //        dataGridView1.BeginEdit(true);

            //        bool status = dataGridView1.IsCurrentCellInEditMode;
            //    }
            //    else
            //    {
            //        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //        dataGridView1.ReadOnly = true;

            //        if (SelectedRow != null)
            //            dataGridView1.Rows[SelectedRow.Index].Selected = true;

            //        if (!dataGridView1.IsCurrentCellInEditMode)
            //        {
            //            Console.WriteLine("经过！");
            //        }
            //        SelectedRow = null;

            //        if (dataGridView1.SelectedRows != null)
            //            dataGridView1.SelectedRows[0].Selected = false;
            //        //dataGridView1.Rows[e.RowIndex].Selected = true;
            //    }

            //    doubleClickTimer.Stop();
            //    isFirstClick = true;
            //    isDoubleClick = false;
            //    milliseconds = 0;
            //}
        }
    }
}
