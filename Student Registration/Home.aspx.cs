using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Student_Registration
{
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);

        public string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowUserDetails();
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        //Show USER DETAILS
        public void ShowUserDetails()
        {
            if (Session["student_id"] != null)
            {
                _connection.Open();
                SqlCommand sc = new SqlCommand("spGetUserDetails", _connection);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@student_id", Session["student_id"]);
                SqlDataAdapter adapter = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                _connection.Close();
                Message = dt.Rows[0]["Full Name"].ToString();
                gv_user.DataSource = dt;
                gv_user.DataBind();
            }
            else 
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void gv_user_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "D")
            {
                _connection.Open();
                SqlCommand sc = new SqlCommand("Delete from tbStudents where SID = '"+e.CommandArgument+"'", _connection);
                sc.ExecuteNonQuery();
                _connection.Close();
                Response.Redirect("Login.aspx");

            }
            //else if (e.CommandName == "E")
            //{

            //}
        }
    }
}