using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace ROFR.pages
{
    public partial class Captcha : System.Web.UI.Page
    {
        char a, b, c, d, e;
        string ct;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //ct = GetRandomText();
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
                //HatchStyle[] aHatchStyles = new HatchStyle[]
                //{
                //HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
                //    HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
                //    HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
                //};
                ////create rectangular area  
                //RectangleF oRectangleF = new RectangleF(0, 0, 300, 300);
                //objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
                //objGraphics.FillRectangle(objBrush, oRectangleF);
                ////Generate the image for captcha  
                //string captchaText = string.Format("{0:X}", (string)Session["CaptchaCode"]);
                ////add the captcha value in session  
                //Session["CaptchaVerify"] = (string)Session["CaptchaCode"];
                //Font objFont = new Font("Courier New", 25, FontStyle.Bold);
                ////Draw the image for captcha  
                ////objGraphics.DrawString(captchaText, objFont, Brushes.Black, 20, 20);
                //objGraphics.DrawString((string)Session["CaptchaCode"], objFont, Brushes.Black, 20, 20);
                //objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
                var ids = "";
                ids = DateTime.Now.Ticks.ToString();
                var serila = GetRandomText();

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
                objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.DarkGreen);
                objGraphics.FillRectangle(objBrush, oRectangleF);
                string captchaText = string.Format("{0:X}", (string)Session["CaptchaCode"]);
                Font objFont = new Font("Courier New", 25, FontStyle.Bold);
                objGraphics.DrawString(captchaText, objFont, Brushes.White, 20, 30);
                objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
                objGraphics.Flush();
                objGraphics.Dispose();
            }

         

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

            // randomText.Append(a + " " + b + " " + " " + c + " " + d + " " + e);

            string aa = a.ToString();
            string ba = b.ToString();
            string ca = c.ToString();
            string da = d.ToString();
            string ea = e.ToString();
            var ss = aa + ba + ca + da + ea;


            randomText.Append(ss);
            Session["CaptchaCode"] = randomText.ToString();

            return Session["CaptchaCode"] as String;

        }
    }
}