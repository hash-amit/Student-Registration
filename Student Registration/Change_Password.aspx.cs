using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Student_Registration
{
    public partial class Change_Password : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection("data source=DESKTOP-IOJE25P\\SQLEXPRESS;initial catalog=dbStudents;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void btn_change_pass_Click(object sender, EventArgs e)
        {
            if (text_current_pass.Text != string.Empty && text_new_pass.Text != string.Empty && text_confirm_pass.Text != string.Empty)
            {
                if (text_new_pass.Text == text_confirm_pass.Text)
                {
                    _connection.Open();
                    SqlCommand sc = new SqlCommand("spChangePassword", _connection);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@student_id", Session["student_id"]);
                    sc.Parameters.AddWithValue("@current_pass", text_current_pass.Text);
                    sc.Parameters.AddWithValue("@new_pass", text_new_pass.Text);
                    int i = sc.ExecuteNonQuery();
                    _connection.Close();
                    if (i > 0)
                    {
                        lbl_msg.Text = "Your password has been changed Successfully!";
                    }
                    else
                    {
                        lbl_msg.Text = "Your current password doesn't match!";
                    }
                }
                else
                {
                    lbl_msg.Text = "Your new password doesn't match!";
                }
            }
            else
            {
                lbl_msg.Text = "All fields are mandatory!";
            }
        }
    }
}