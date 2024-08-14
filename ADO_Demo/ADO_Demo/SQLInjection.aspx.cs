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
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(CS))
            {
                string com = "select * from hr.candidates where fullname like '" + TextBox1.Text +"%';";
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(com, conn))
                {
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }
    }
}

// ja' ; delete from hr.candidates; --