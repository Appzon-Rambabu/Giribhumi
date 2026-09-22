using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.IO;

namespace ROFR
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        char a, b, c, d, e;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bitmap objBitmap = new Bitmap(130, 80);
            //Graphics objGraphics = Graphics.FromImage(objBitmap);
            //objGraphics.Clear(Color.White);
            //Random objRandom = new Random();
            //objGraphics.DrawLine(Pens.Black, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
            //objGraphics.DrawRectangle(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
            //objGraphics.DrawLine(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
            //Brush objBrush =
            //    default(Brush);
            ////create background style  
            //System.Drawing.Drawing2D.HatchStyle[] aHatchStyles = new HatchStyle[]
            //{
            //    HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
            //        HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
            //        HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
            //};
            ////create rectangular area  
            //RectangleF oRectangleF = new RectangleF(0, 0, 300, 300);
            //objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
            //objGraphics.FillRectangle(objBrush, oRectangleF);
            ////Generate the image for captcha  
            //string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
            ////add the captcha value in session  
            //Session["CaptchaVerify"] = captchaText.ToLower();
            //Font objFont = new Font("Courier New", 15, FontStyle.Bold);
            ////Draw the image for captcha  
            //objGraphics.DrawString(captchaText, objFont, Brushes.Black, 20, 20);
            //objBitmap.Save(Response.OutputStream, ImageFormat.Gif);

            //KCODE
            Random rn = new Random();
            string rnval = GetRandomText(); ;
            var ids = "";
            ids = DateTime.Now.ToString("ddMMyyyyhhmmssfff") + rnval.ToString();


            Bitmap objBitmap = new Bitmap(150, 90);
            Graphics objGraphics = Graphics.FromImage(objBitmap);
            objGraphics.Clear(Color.White);
            Random objRandom = new Random();
            objGraphics.DrawLine(Pens.White, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
            objGraphics.DrawRectangle(Pens.White, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
            objGraphics.DrawLine(Pens.White, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
            Brush objBrush =
                default(Brush);
            HatchStyle[] aHatchStyles = new HatchStyle[]
            {
               HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
            };
            RectangleF oRectangleF = new RectangleF(0, 0, 400, 400);
            objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.Blue);
            objGraphics.FillRectangle(objBrush, oRectangleF);
            string captchaText =  rnval;
            Font objFont = new Font("Courier New", 18, FontStyle.Bold);
            objGraphics.DrawString(captchaText, objFont, Brushes.White, 15, 30);
            objGraphics.Flush();
            objGraphics.Dispose();

            //string path = HttpContext.Current.Server.MapPath("../../capth");

            string fileName = captchaText + ".Gif";
            //path = Path.Combine(path, fileName);
            string newpath = ids + fileName;
           // objBitmap.Save(Path.Combine(HttpContext.Current.Server.MapPath("../../capth"), newpath), ImageFormat.Gif);
            objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
        }
        private string GetRandomText()

        {

            StringBuilder randomText = new StringBuilder();

            string alphabets = "012345679";

            Random r = new Random();

            for (int j = 0; j < 5; j++)

            {
                //randomText.Append(alphabets[r.Next(alphabets.Length)]);

                a = (alphabets[r.Next(alphabets.Length)]);
                b = (alphabets[r.Next(alphabets.Length)]);
                c = (alphabets[r.Next(alphabets.Length)]);
                d = (alphabets[r.Next(alphabets.Length)]);
                e = (alphabets[r.Next(alphabets.Length)]);

            }

            randomText.Append(a + " " + b + " " + " " + c + " " + d + " " + e);

            Session["CaptchaCode"] = randomText.ToString();

            return Session["CaptchaCode"] as String;

        }
        //protected void Button1_Click(object sender, EventArgs e)

        //{

        //    DataSet dS = ProjectRofrBAL.GetMasterDetails.validaadhar("", "");
        //    DataTable dt = dS.Tables[0];
        //    for (int i = 0; i <=1; i++)
        //    {

        //        WebReference.Services obj = new WebReference.Services();

        //        string a = obj.UidOrEIDValidation(dt.Rows[i]["Aadhaar_NO"].ToString(), "");
        //        string status = a;
        //        txt_status.Text = a;
        //        if (a.Contains("100"))
        //        {

        //            string vaild = "VALID";
        //            ProjectRofrBAL.GetMasterDetails.UpdateAadhaar_status(dt.Rows[i]["Id"].ToString(), vaild);
        //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Updated Successfully !')", true);

        //        }
        //        else if (a.Contains("101"))
        //        {
        //            ProjectRofrBAL.GetMasterDetails.UpdateAadhaar_status(dt.Rows[i]["Id"].ToString(), "invalid");
        //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Updated Successfully !')", true);

        //        }
        //    }

        //    // bind();

        //    //WebReference.Services obj = new WebReference.Services();

        //    // string a = obj.UidOrEIDValidation("123456789101", "");
        //    // Response.Write(a);


        //}
        //public  void bind()
        //{
        //    WebReference.Services obj = new WebReference.Services();

        //    string a = obj.UidOrEIDValidation("724921564027", "724921564027");
        //   Response.Write(a);
        //    //return a;

        //}
    }
}