using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Student_Registration
{
    public partial class EditProfile : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {
                    if ((Session["student_id"]).ToString() == string.Empty)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                catch(Exception ex)
                {
                    Response.Redirect("Login.aspx");
                }
                BindGender();
                BindCourses();
                BindCountries();
                ddl_course.Items.Insert(0, new ListItem("Select Course", "0"));
                ddl_country.Items.Insert(0, new ListItem("Select Country", "0")); 
                PopulateData();
            }
        }

        // Binding list of Gender
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

        // Binding list of courses
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

        // Binding list of countries
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
            //ddl_state.Items.Insert(0, new ListItem("Select State", "0"));
        }

        // Populating user detail into the edit form to update it
        public void PopulateData()
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("select * from tbStudents where SID = '" + Session["student_id"] +"'", _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(sc);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            _connection.Close();
            text_fname.Text = dataTable.Rows[0]["Full Name"].ToString();
            text_email.Text = dataTable.Rows[0]["EMAIL"].ToString();
            rbl_gender.SelectedIndex = (Convert.ToInt32(dataTable.Rows[0]["GENDER"]))-1;
            ddl_course.SelectedIndex = Convert.ToInt32(dataTable.Rows[0]["COURSES"]);
            ddl_country.SelectedIndex = Convert.ToInt32(dataTable.Rows[0]["COUNTRY"]);
            
            // Binding state & inserting an Item at it's index number 0
            BindStates();
            ddl_state.Items.Insert(0, new ListItem("Select State", "0"));
            
            ddl_state.SelectedIndex = Convert.ToInt32(dataTable.Rows[0]["STATE"]);
            text_phone.Text = dataTable.Rows[0]["PHONE"].ToString();
            //ViewState["img_name"] = dataTable.Rows[0]["PHOTO"].ToString();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Text = "Update"; 
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_country.SelectedIndex == 0)
            {
                ddl_state.Enabled = false;
            }
            else
            {
                ddl_state.Enabled = true;
                BindStates();
            }
        }
    }
}