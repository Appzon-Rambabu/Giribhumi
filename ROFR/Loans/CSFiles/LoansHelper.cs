using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace ROFR.Loans.CSFiles
{
    public class LoansHelper : LoansSPHelper
    {
        dynamic _ResultObj = new ExpandoObject();
        ResponseModel _ResObj = new ResponseModel();

        #region Login Module
        public dynamic check_s_captch(UserLoginCls root)
        {
            captchgens retrn = new captchgens();
            try
            {

                Random rn = new Random();
                int rnval = rn.Next(100000, 999999);
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
                string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
                Font objFont = new Font("Courier New", 25, FontStyle.Bold);
                objGraphics.DrawString(captchaText, objFont, Brushes.White, 20, 30);
                objGraphics.Flush();
                objGraphics.Dispose();

                //string path = HttpContext.Current.Server.MapPath("../../capth");

                string fileName = captchaText + ".Gif";
                //path = Path.Combine(path, fileName);
                string newpath = ids + fileName;
                objBitmap.Save(Path.Combine(HttpContext.Current.Server.MapPath("../../capth"), newpath), ImageFormat.Gif);

                root.PTYPE = "18";
                root.REFER_ID = captchaText;
                root.CAPTHA_VALUE = ids.ToString().Trim();
                root.IP = GetCurrentIPAddress();

                //bool captchgen = true;
                bool captchgen = CaptchaSave_Helper(root);
                if (captchgen == true)
                {

                    byte[] imageBytes = System.IO.File.ReadAllBytes(Path.Combine(HttpContext.Current.Server.MapPath("../../capth"), newpath));
                    string base64String = Convert.ToBase64String(imageBytes);
                    //retrn.idval = Encrypt(ids, "");
                    retrn.idval = root.CAPTHA_VALUE;
                    retrn.code = "100";
                    retrn.imgurl = base64String;

                    //DirectoryInfo diInfo = new DirectoryInfo(Path.Combine(HttpContext.Current.Server.MapPath("../../capth")));
                    //FileInfo[] files = diInfo.GetFiles();
                    //for (int i = 0; i < files.Length; i++)
                    //{
                    string filePath = Path.Combine(HttpContext.Current.Server.MapPath("../../capth/" + newpath));
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    //}
                    return retrn;

                }
                else
                {
                    retrn.idval = "";
                    retrn.code = "99";
                    retrn.imgurl = "Error.htm";
                    return retrn;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("CaptchaExceptionLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, "Error Deleting Beneficiary Data" + ex.Message.ToString()));

                retrn.code = "102";
                retrn.Reason = "Capatcha Not Loaded Properly";

                return retrn;
            }
        }

        public dynamic GBLIUserLogin(UserLoginCls Lobj)
        {
            try
            {
                Lobj.PTYPE = "19";
                if (GetGBLICaptchVerify(Lobj))
                {
                    Lobj.PTYPE = "17";

                    DataTable CurrentUser = GetCommonData_SP(Lobj);
                    if (CurrentUser != null && CurrentUser.Rows.Count > 0)
                    {
                        _ResObj.Status = 100;
                        _ResObj.Reason = "User Login Successfully";
                        _ResObj.DataList = CurrentUser;
                    }
                    else
                    {
                        _ResObj.Status = 102;
                        _ResObj.Reason = "Invalid Username or Password";
                    }
                }
                else
                {
                    _ResObj.Status = 102;
                    _ResObj.Reason = "Invalid Captcha";
                }
            }
            catch (Exception ex)
            {
                _ResObj.Status = 102;
                _ResObj.Reason = "Error Occured While Login";

            }
            return _ResObj;
        }

        public string GetCurrentIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public bool CaptchaSave_Helper(UserLoginCls rootobj)
        {
            try
            {
                var val = GetCommonData_SP(rootobj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool GetGBLICaptchVerify(UserLoginCls ObjL)
        {
            try
            {
                DataTable dtCaptch = GetCommonData_SP(ObjL);
                if (dtCaptch != null && dtCaptch.Rows.Count > 0 && dtCaptch.Rows[0][0].ToString() == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion

        #region Admin Module

        public dynamic LoadCommonData_Helper(UserLoginCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var val = GetCommonData_SP(rootobj);
                obj.Status = 100;
                obj.Reason = "Data Loaded Successfully";
                obj.Data = val;

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occure While Load Data";
                return obj;
            }

        }

        public dynamic UpdateUser_Helper(UserLoginCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                DataTable CurrentUser = GetCommonData_SP(rootobj);
                if (CurrentUser != null && CurrentUser.Rows.Count > 0 && CurrentUser.Rows[0][0].ToString() == "1")
                {
                    obj.Status = 100;
                    obj.Reason = "User Password Update Successfully";
                    //obj.Data = CurrentUser;
                }
                else
                {
                    obj.Status = 102;
                    obj.Reason = "Invalid Old Password";
                }

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occure While Load Data";
                return obj;
            }

        }

        #endregion

        #region Adangal Module

        public dynamic LoanAdangalData_Helper(AdangalCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var val = LoanAdangalData_Helper_SP(rootobj);
                obj.Status = 100;
                obj.Reason = "Data Loaded Successfully";
                obj.Data = val;

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occured While Load Data";
                return obj;
            }

        }

        #endregion

        #region Loans Module

        public dynamic LoadLoansCommonData_Helper(CommonCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var val = GetLoansCommonData_SP(rootobj);
                obj.Status = 100;
                obj.Reason = "Data Loaded Successfully";
                obj.Data = val;

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occure While Load Data";
                return obj;
            }

        }

        #endregion

        #region Reports Module

        public dynamic LoadReportsCommonData_Helper(ReportsCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var val = GetReportsCommonData_SP(rootobj);
                obj.Status = 100;
                obj.Reason = "Data Loaded Successfully";
                obj.Data = val;

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occure While Load Data";
                return obj;
            }

        }

        public dynamic LoadBranchWise_Helper(ReportsCls rootobj)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var val = GetBranchData_SP(rootobj);
                obj.Status = 100;
                obj.Reason = "Data Loaded Successfully";
                obj.Data = val;

                return obj;
            }
            catch (Exception ex)
            {
                obj.Status = 102;
                obj.Reason = "Error Occure While Load Data";
                return obj;
            }

        }

        #endregion
    }
}