using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Dynamic;
using System.Drawing;
using System.Management;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;


namespace ROFR.helper
{
    public class EcropSupport
    {

        Landsettlementpattasd userObj = new Landsettlementpattasd();
        public dynamic Get_Ecrop_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Ecrop_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {
             
            }
            return obj_data;
        }

        public dynamic UpdateEcrop_valid(addbeneficiary_details obj)
        {
            dynamic objdata = new ExpandoObject();
            try
            {

                string filepath = SaveImage(obj.Image, obj.id, obj.Itda);
                obj.Imagepath = filepath;
             
                DataTable dt = userObj.UpdateEcrop_sp(obj);
              
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "1")
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";

                    objdata.Reason = "Updated Successfully";
                    return objdata;
                }
                else
                {
                    objdata.Status = "0";
                    objdata.Message = "Failure";
                   //objdata.Reason = "Username or Password is Incorrect";
                    return objdata;
                }

            }
            catch (Exception ex)
            {
                objdata.Status = "0";
                objdata.Message = "Data Not Available";

                return objdata;
            }
        }
        public string SaveImage(string ImgStr, string id, string itdaname)
        {
            String path = HttpContext.Current.Server.MapPath("~/Ecrop" + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + id); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = id + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return imgPath;
        }
    }
}