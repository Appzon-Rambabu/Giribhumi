using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using ROFR.helper;

namespace ROFR
{
    /// <summary>
    /// Summary description for Land_image_file
    /// </summary>
    public class Land_image_file : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string ImageId = context.Request.QueryString["ImageId"];
               

                //if (dtimage.Rows[0]["Dlc"].ToString() == "System.Byte[]")
                //{
                // }

                DataTable dtfile = Landsettlementpattas.Land_Transfer_file_retrieve((ImageId));
                string filename = dtfile.Rows[0]["RDO_FILENAME"].ToString();
                string date = dtfile.Rows[0]["FILE_DATE"].ToString();
                string id = dtfile.Rows[0]["Id"].ToString();
                string folder = dtfile.Rows[0]["FILE_FOLDER"].ToString();
                string fpath = "LandSettlementPattas";


                string type = dtfile.Rows[0]["RDO_FILENAME"].ToString();
                // string path = dtfile.Rows[0]["Dlcpath"].ToString();
                string path = dtfile.Rows[0]["RDO_PATH"].ToString();
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