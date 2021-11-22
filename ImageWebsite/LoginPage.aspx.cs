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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            String checkuser = "select count(*) from UserData where Username = '" + txtusername.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPassword = "select Password from UserData where Username = '" + txtusername.Text + "'";
                SqlCommand passCom = new SqlCommand(checkPassword, conn);
                string password = passCom.ExecuteScalar().ToString().Replace(" ","");
                if(password == txtPassword.Text)
                {
                    Session["New"] = txtusername.Text;
                    Response.Write("Password is correct.");
                    Response.Redirect("UploadPhoto.aspx");
                    
                }
                else
                {
                    Response.Write("Password is not correct.");
                }
            }
            else
            {
                Response.Write("Username is not correct.");
            }
            

        }

        protected void btn_LogOut_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("LoginPage.aspx");

            
        }
    }
}