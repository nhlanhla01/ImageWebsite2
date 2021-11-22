using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace ImageWebsite
{
    public partial class ImageUpload : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(!IsPostBack)
            {
                BindGridView();
            }
            
            
                
            
        }
        void RestControls()
        {
            txtID.Text = txt_Name.Text = txtDescrption.Text = "";
            Label1.Visible = false;
            GetImage.Visible = false;
            GridView1.SelectedIndex = -1;

        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string filePath = Server.MapPath("images/");
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string extension = Path.GetExtension(fileName);
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            int size = postedFile.ContentLength;
            if(FileUpload1.HasFile == true)
            {
                if(extension.ToLower() == ".bmp" || extension.ToLower() == ".ico" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".gif" || extension.ToLower() == ".tiff" || extension.ToLower() == ".png")
                {
                    if (size <= 1000000)
                    {
                        string query2 = "select  * from Image where ID = @id";
                        SqlCommand cmd2 = new SqlCommand(query2,con);
                        cmd2.Parameters.AddWithValue("@id", txtID.Text);
                        con.Open();
                        SqlDataReader dr = cmd2.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            Response.Write("<script>alert('ID Already Exists!!')</script>");
                            con.Close();
                        }
                        else
                        {
                            con.Close();
                            FileUpload1.SaveAs(filePath + fileName);
                            string path2 = "images/" + fileName;

                            string query = "insert into Image values(@id,@Name,@description,@image)";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", txtID.Text);
                            cmd.Parameters.AddWithValue("@Name", txt_Name.Text);
                            cmd.Parameters.AddWithValue("@description", txtDescrption.Text);
                            cmd.Parameters.AddWithValue("@image", path2);
                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                Response.Write("<script>alert('Inserted Successfully!!')</script>");
                                RestControls();
                                BindGridView();
                                Label1.Visible = false;
                                GetImage.Visible = false;
                            }
                            else
                            {
                                Response.Write("<script>alert('Insertion failed!')</script>");

                            }
                            con.Close();
                        }


                    }
                    else
                    {
                        Label1.Text = "Length should be less than 1 MB";
                        Label1.Visible = true;
                        Label1.ForeColor = Color.Red;
                    }

                }
                else
                {
                    Label1.Text = "Format not supported!!";
                    Label1.Visible = true;
                    Label1.ForeColor = Color.Red;
                }

            }
            else
            {
                Label1.Text = "Please upload a photo";
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                
            }


        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            RestControls();
        }

        void BindGridView()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Image";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            GridView1.DataSource = data;
            GridView1.DataBind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            Label lblId = (Label)row.FindControl("LabelId");
            Label lblName = (Label)row.FindControl("LabelName");
            Label lblDescription = (Label)row.FindControl("LabelDecription");
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)row.FindControl("Image1");

            txtID.Text = lblId.Text;
            txt_Name.Text = lblName.Text;
            txtDescrption.Text = lblDescription.Text;
            GetImage.ImageUrl = image.ImageUrl;
            GetImage.Visible = true;

        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string filePath = Server.MapPath("images/");
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string extension = Path.GetExtension(fileName);
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            int size = postedFile.ContentLength;

            string UpdatePath = "images/";
            if (FileUpload1.HasFile == true)
            {
                if (extension.ToLower() == ".bmp" || extension.ToLower() == ".ico" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".gif" || extension.ToLower() == ".tiff" || extension.ToLower() == ".png")
                {
                    if (size <= 1000000)
                    {
                        
                        UpdatePath = UpdatePath + fileName;
                        FileUpload1.SaveAs(Server.MapPath(UpdatePath));

                        string query = "update Image set name= @name,description = @description,image_path = @image where id = @id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescrption.Text);
                        cmd.Parameters.AddWithValue("@image",UpdatePath);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if(a > 0)
                        {
                            Response.Write("<script>alert('Updated Successfully!!')</script>");
                            RestControls();
                            BindGridView();
                            Label1.Visible = false;
                            GetImage.Visible = false;
                        }
                        else
                        {
                            Response.Write("<script>alert('Not Updated!!')</script>");

                        }
                        con.Close();
                    }
                    else
                    {
                        Label1.Text = "Length should be less than 1 MB";
                        Label1.Visible = true;
                        Label1.ForeColor = Color.Red;
                    }

                }
                else
                {
                    Label1.Text = "Format not supported!!";
                    Label1.Visible = true;
                    Label1.ForeColor = Color.Red;
                }

            }
            else
            {
                UpdatePath = GetImage.ImageUrl.ToString();
                string query = "update Image set name= @name,description = @description,image_path = @image where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@description", txtDescrption.Text);
                cmd.Parameters.AddWithValue("@image", UpdatePath);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Updated Successfully!!')</script>");
                    RestControls();
                    BindGridView();
                    Label1.Visible = false;
                    GetImage.Visible = false;

                    string DeletePath = Server.MapPath(GetImage.ImageUrl.ToString());
                    if(File.Exists(DeletePath)== true)
                    { 
                        File.Delete(DeletePath);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Not Updated!!')</script>");

                }
                con.Close();

            }

        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Image where id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Write("<script>alert('Deleted Successfully!!')</script>");
                RestControls();
                BindGridView();
                Label1.Visible = false;
                GetImage.Visible = false;

                string DeletePath = Server.MapPath(GetImage.ImageUrl.ToString());
                if(File.Exists(DeletePath)== true)
                { 
                       File.Delete(DeletePath);
                }
            }
            else
            {
                Response.Write("<script>alert('Not Deleted!!')</script>");

            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Album.aspx");
        }
    }
    }
