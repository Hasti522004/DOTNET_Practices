using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Data;
using System.Runtime.Remoting.Messaging;
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

                    // SQLDataReader Demo

                    // Read() method
                    using (SqlCommand cmd4 = new SqlCommand("SELECT * FROM candidates;", con))
                    {
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Columns.Add("CandidateID");
                            table.Columns.Add("Name");
                            table.Columns.Add("Position");
                            table.Columns.Add("YearsOfExperience");
                            table.Columns.Add("Email");
                            table.Columns.Add("PhoneNumber");
                            table.Columns.Add("NewExperience");
                            while (reader.Read())
                            {
                                DataRow datarow = table.NewRow();
                                int exp = Convert.ToInt32(reader["YearsOfExperience"]);
                                int newexp = exp + 1;
                                datarow["CandidateID"] = reader["CandidateID"];
                                datarow["Name"] = reader["Name"];
                                datarow["Position"] = reader["Position"];
                                datarow["YearsOfExperience"] = reader["YearsOfExperience"];
                                datarow["Email"] = reader["Email"];
                                datarow["PhoneNumber"] = reader["PhoneNumber"];
                                datarow["NewExperience"] = newexp;

                                table.Rows.Add(datarow);    
                            }
                            GridView1.DataSource = table;
                            GridView1.DataBind();
                        }
                    }

                    // SQLDataReader NextResult() method
                    using(SqlCommand cmd5 = new SqlCommand("select * from candidates;select * from hr.employees;",con))
                    {
                        using (SqlDataReader reader = cmd5.ExecuteReader())
                        {
                            GridView1.DataSource =reader;
                            GridView1.DataBind();
                            while(reader.NextResult())
                            {
                                GridView2.DataSource = reader;
                                GridView2.DataBind();
                            }
                        }
                    }

                    // no need to open and close connection
                    SqlDataAdapter da = new SqlDataAdapter("select * from hr.employees;", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    GridView3.DataSource = ds;
                    GridView3.DataBind();
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