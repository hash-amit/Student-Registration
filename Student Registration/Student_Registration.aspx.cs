using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace Student_Registration
{
    public partial class Student_Registration : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGender();
                BindCourses();
                BindCountries();
                ddl_country.Items.Insert(0, new ListItem("Select Country", "0")); //in this line first 0 is indicates the number of index and the second 0 is the value
                ddl_course.Items.Insert(0, new ListItem("Select Course", "0"));
                ddl_state.Items.Insert(0, new ListItem("Select State", "0"));
                ddl_state.Enabled = false;
            }
        }

        //Clear Student Registration Form
        public void ClearForm()
        {
            text_fname.Text = string.Empty;
            text_email.Text = string.Empty;
            rbl_gender.ClearSelection(); 
            ddl_course.SelectedIndex = 0;
            ddl_country.SelectedIndex = 0;
            ddl_state.SelectedIndex = 0;
            ddl_state.Enabled = false;
            text_phone.Text = string.Empty;
            text_pass.Text = string.Empty;
        }

        //Binding Gender
        public void BindGender() 
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("spBindGender", _connection);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sc);  
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            rbl_gender.DataValueField = "GID";
            rbl_gender.DataTextField = "GENDER NAME";
            rbl_gender.DataSource = dt;
            rbl_gender.DataBind();
        }

        //Binding Courses
        public void BindCourses() 
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("spBindCourses", _connection);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            ddl_course.DataValueField = "CID";
            ddl_course.DataTextField = "COURSE NAME";
            ddl_course.DataSource = dt;
            ddl_course.DataBind();
        }

        //Binding Countries
        public void BindCountries()
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("spBindCountries", _connection);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            ddl_country.DataValueField = "COUNTRY ID";
            ddl_country.DataTextField = "COUNTRY NAME";
            ddl_country.DataSource = dt;
            ddl_country.DataBind();
        }

        //Binding States
        public void BindStates()
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("spBindStates", _connection);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@country", Convert.ToInt32(ddl_country.SelectedValue));
            SqlDataAdapter adapter = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();
            ddl_state.Enabled = true;
            ddl_state.DataValueField = "STATE ID";
            ddl_state.DataTextField = "STATE NAME";
            ddl_state.DataSource = dt;
            ddl_state.DataBind();
            ddl_state.Items.Insert(0, new ListItem("Select State", "0"));
        }

        public bool FormValidation()
        {
            if (rbl_gender.SelectedValue != "")
            {
                if(ddl_course.SelectedValue != "0")
                {
                    if(ddl_country.SelectedValue != "0")
                    {
                        if(ddl_state.SelectedValue != "0")
                        {
                            if((text_phone.Text.Length) == 10)
                            {
                                string Ext = (Path.GetExtension(photo.PostedFile.FileName)).ToUpper();
                                string fName = Path.GetFileName(photo.PostedFile.FileName);
                                if ((fName != "") && (Ext == ".JPG" || Ext == ".JPEG" || Ext == ".PNG" || Ext == ".JFIF"))
                                {
                                    ViewState["fileName"] = DateTime.Now.Ticks + fName; ;
                                    return true;
                                }
                                else
                                {
                                    lbl_msg.Text = "Please upload image file";
                                }
                            }
                            else
                            {
                                lbl_msg.Text = "Mobile number should be of 10 digit";
                            }
                        }
                        else
                        {
                            lbl_msg.Text = "Please select State";
                        }
                    }
                    else
                    {
                        lbl_msg.Text = "Please select Country";
                    }
                }
                else
                {
                    lbl_msg.Text = "Please select Course";
                }
            }
            else
            {
                lbl_msg.Text = "Please select the Gender";
            }
            return false;
        }

        public bool CheckDuplicateRegistration()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("spCheckEmail", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", text_email.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _connection.Close();
            if (dt.Rows.Count > 0)
            {
                lbl_msg.Text = "Email is already registered!";
                return false;
            }
            else
            {
                return true;
            }
        }

        //Inserting user input into database
        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (FormValidation() == true)
            {
                if (CheckDuplicateRegistration() == true)
                {
                    photo.SaveAs(Server.MapPath("Photos" + "\\" + ViewState["fileName"]));
                    _connection.Open();
                    SqlCommand sc = new SqlCommand("spInstertData", _connection);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@fname", text_fname.Text);
                    sc.Parameters.AddWithValue("@email", text_email.Text);
                    sc.Parameters.AddWithValue("@gender", rbl_gender.SelectedValue);
                    sc.Parameters.AddWithValue("@course", ddl_course.SelectedValue);
                    sc.Parameters.AddWithValue("@country", ddl_country.SelectedValue);
                    sc.Parameters.AddWithValue("@state", ddl_state.SelectedValue);
                    sc.Parameters.AddWithValue("@phone", text_phone.Text);
                    sc.Parameters.AddWithValue("@pass", text_pass.Text);
                    sc.Parameters.AddWithValue("@photo", ViewState["fileName"]);
                    sc.ExecuteNonQuery();
                    _connection.Close();
                    ClearForm();
                    lbl_msg.Text = "You have successfully registered...!!";
                }
            }
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_country.SelectedIndex == 0)
            {
                ddl_state.Enabled = false;
            }
            else
            {
                BindStates();
            }
        }
    }
}