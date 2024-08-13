using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace ADO_Demo
{
    public partial class ADO_Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the connection string from web.config
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM product_json;", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
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