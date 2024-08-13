using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO_Demo
{
    public partial class ADO_Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EV-LAP-00158\\MSSQLSERVEV;password=Welcome@123;Initial Catalog=student;Persist Security Info=True;User ID=sa;Encrypt=True;TrustServerCertificate=true");
            SqlCommand cmd = new SqlCommand("select * from hr.candidates", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }
    }
}