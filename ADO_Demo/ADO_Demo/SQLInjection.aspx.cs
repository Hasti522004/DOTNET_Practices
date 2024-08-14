using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO_Demo
{
    public partial class SQLInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SQL Injection 

            // ja' ; delete from hr.candidates; --

            // Query in SQL server Profiler : select * from hr.candidates where fullname like 'ja' ; delete from hr.candidates; --%';

            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using(SqlConnection conn = new SqlConnection(CS))
            //{
            //    string com = "select * from hr.candidates where fullname like '" + TextBox1.Text +"%';";
            //    conn.Open();
            //    using(SqlCommand cmd = new SqlCommand(com, conn))
            //    {
            //        GridView1.DataSource = cmd.ExecuteReader();
            //        GridView1.DataBind();
            //    }
            //}

            // SQL Prevention using Parameterized Query

            // Query Execute in SQL : exec sp_executesql N'select * from hr.employees where fullname like @fullname',N'@fullname nvarchar(36)',@fullname=N'jo'' ; delete from hr.candidates; --%'

            //treated as a value not as a Query. convert ' -> ''

            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(CS))
            //{
            //    string com = "select * from hr.employees where fullname like @fullname";
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(com, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@fullname", TextBox1.Text + "%");
            //        GridView1.DataSource = cmd.ExecuteReader();
            //        GridView1.DataBind();
            //    }
            //}

            // SQL Prevention using Stored Procedure

            /*
             * Store Procedure in SQL 
             * 
            create Procedure spGetFullname
            @fullname varchar(255)
            as 
            begin 
	            select * from hr.employees
	            where fullname like @fullname + '%'
            end
             */

            // exec spGetFullname @fullname=N'ja'' ; delete from hr.employees; --'

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            { 
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("spGetFullname", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fullname", TextBox1.Text);
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }
    }
}



