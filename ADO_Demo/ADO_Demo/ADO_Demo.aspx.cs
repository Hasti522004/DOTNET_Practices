using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Runtime.InteropServices;
namespace ADO_Demo
{
    public partial class ADO_Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. ADO Basic Connections :

            //SqlConnection con = new SqlConnection("Data Source=EV-LAP-00158\\MSSQLSERVEV;password=Welcome@123;Initial Catalog=student;Persist Security Info=True;User ID=sa;Encrypt=True;TrustServerCertificate=true");

            //SqlCommand cmd = new SqlCommand("select * from hr.candidates", con);

            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();

            //GridView1.DataSource = reader;

            //GridView1.DataBind();

            //con.Close();

            // 2. ADO SQLCommand Execute Query Types :

            // (1) ExecuteReader - for multiple rows
            // (2) ExecuteScalar - for single result
            // (3) ExecuteNonQuery - for insert/update/delete

            try
            {
                // Retrieve the connection string from web.config
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM product_json;", con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }     
                    }
                    using (SqlCommand cmd2 = new SqlCommand("select count(*) from product_json;", con))
                    {
                        int totalrows = (int)cmd2.ExecuteScalar();
                        Response.Write("Total Rows = " + totalrows.ToString() +"<br/>");
                    }   
                    using(SqlCommand cmd3 = new SqlCommand("insert into hr.candidates(fullname) values ('Jatan');", con))
                    {
                        int affectedRows = cmd3.ExecuteNonQuery();
                        Response.Write($"\nTotal Affected Rows : {affectedRows.ToString()}");   
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


    }
}