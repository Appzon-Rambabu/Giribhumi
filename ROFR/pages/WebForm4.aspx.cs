using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ROFR.pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
      string file= HttpContext.Current.Server.MapPath("~/img/textfileexample.txt");
            string text = File.ReadAllText(file);
            //string authors  = "1,2,3,4,5";
            // Split authors separated by a comma followed by space  
            string[] authorsList = text.Split(',');
            //foreach (string author in authorsList)
            //{
            //   // Response.Write(author + "<br>");
            //    Label1.Text+= author + "<br>";
            //}

            Label1.Text = authorsList[0].ToString();
            Label2.Text = authorsList[1].ToString();
            Label3.Text = authorsList[2].ToString();
            Label4.Text = authorsList[3].ToString();
            Label5.Text = authorsList[4].ToString();
            //Console.WriteLine(author);


        }
    }
}