using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace ImageWebsite
{
    public partial class Sign_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
           if(IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                String checkuser = "select count(*) from UserData where Username = '" + txtName.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("User already exists");
                }
                conn.Close();
            }


        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into UserData(Username,Email,Password)values(@username, @Email, @Password)";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.AddWithValue("@Username", txtName.Text);
                com.Parameters.AddWithValue("@Email", txtEmail.Text);
                com.Parameters.AddWithValue("@Password", txtPword.Text);

                com.ExecuteNonQuery();
                Response.Write("Successfully registered!");
                Response.Redirect("LoginPage.aspx");

                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error:"+ex.ToString());
            }
            

                
            
        }

       
    }
}