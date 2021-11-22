using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ImageWebsite
{
    public partial class UploadPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Photos/"));
                List<ListItem> files = new List<ListItem>();
                foreach(string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, "~/Photos/" + fileName));
                }
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }

        protected void Button_submit_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photos/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImageUpload.aspx");
        }
    }
}