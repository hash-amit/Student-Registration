using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Student_Registration
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        public void ClearForm() 
        {
            text_email.Text = string.Empty;
            text_pass.Text = string.Empty;
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (text_email.Text != string.Empty && text_pass.Text != string.Empty && text_pass.Text.Length <= 10)
            {
                _connection.Open();
                SqlCommand sc = new SqlCommand("spCheckEmailPass", _connection);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@email", text_email.Text);
                sc.Parameters.AddWithValue("@pass", text_pass.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                _connection.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["student_id"] = Convert.ToInt32(dt.Rows[0]["SID"]);
                    ClearForm();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lbl_msg.Text = "Oops! You may have entered wrong credentials!";
                }
            }
        }
    }
}