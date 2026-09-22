using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using ROFR.helper;

namespace ROFR
{
    /// <summary>
    /// Summary description for DlcImage
    /// </summary>
    public class DlcImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                string ImageId = context.Request.QueryString["ImageId"];
                DataTable dtimage = ProjectRofrBAL.GetMasterDetails.pdfFile_retrieve(ImageId);
                string filename = dtimage.Rows[0]["Dlc"].ToString();
                string path = dtimage.Rows[0]["Dlcpath"].ToString();

                //if (dtimage.Rows[0]["Dlc"].ToString() == "System.Byte[]")
                //{
                // }
                byte[] imageBytes = File.ReadAllBytes(path + filename);
                context.Response.BinaryWrite((Byte[])imageBytes);


                context.Response.End();
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, "", HttpContext.Current.Request.UserHostAddress);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}