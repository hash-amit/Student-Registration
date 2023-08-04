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
    public partial class Student_Registration : System.Web.UI.Page
    {
        SqlConnection _connection = new SqlConnection("data source=DESKTOP-IOJE25P\\SQLEXPRESS;initial catalog=dbStudents;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGender();
                BindCourses();
                BindCountries();
                ddl_country.Items.Insert(0, new ListItem("-----Select-----", "0")); //in this line first 0 is indicates the number of index and the second 0 is the value
                ddl_state.Enabled = false;
            }
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
        }

        //Inserting user input into database
        protected void btn_register_Click(object sender, EventArgs e)
        {
            _connection.Open();
            SqlCommand sc = new SqlCommand("spInstertData",_connection);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@fname", text_fname.Text);
            sc.Parameters.AddWithValue("@email", text_fname.Text);
            sc.Parameters.AddWithValue("@gender", rbl_gender.SelectedValue);
            sc.Parameters.AddWithValue("@course", ddl_course.SelectedValue);
            sc.Parameters.AddWithValue("@country", ddl_country.SelectedValue);
            sc.Parameters.AddWithValue("@state", ddl_state.SelectedValue);
            sc.Parameters.AddWithValue("@phone", text_phone.Text);
            sc.Parameters.AddWithValue("@pass", text_pass.Text);
            sc.ExecuteNonQuery();
            _connection.Close();
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