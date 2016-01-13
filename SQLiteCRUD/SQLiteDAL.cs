using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SQLiteCRUD
{
    public class SQLiteDAL
    {
        string connstr = @"Data Source=A.db";
        SQLiteConnection conn;
        SQLiteDataAdapter adpt;
        SQLiteCommand cmd;
        public SQLiteDAL()
        {
            conn = new SQLiteConnection(@"Data Source=A.db");
        }

        public DataTable Select(string Sql)
        {
            cmd = new SQLiteCommand(Sql, conn);
            adpt = new SQLiteDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            adpt.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        public bool RUD(string Sql)
        {
            bool IsOk = false;
            cmd = new SQLiteCommand(Sql, conn);

            conn.Open();
            IsOk = cmd.ExecuteNonQuery() > 0 ? true : false;
            conn.Close();

            return IsOk;
        }
    }
}
