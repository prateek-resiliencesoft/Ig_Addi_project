using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Social_Media_Service_Panel.Helper;

namespace SocialPanel
{
    public partial class webhook : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string NewImagePostedSource = sr.ReadToEnd();
                FileHelper.AppendStringToTextfileNewLine(NewImagePostedSource, Server.MapPath("test.txt"));
                FileHelper.AppendStringToTextfileNewLine("================================================", Server.MapPath("test.txt"));

            }
            catch (Exception)
            {
               
            }
        }
    }
}