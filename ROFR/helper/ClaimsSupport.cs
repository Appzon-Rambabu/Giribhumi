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
    public class ClaimsSupport
    {
        public dynamic Loginhelper(string username, string password)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.Rejected_claims_login(username,password);
              

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

                    return objdata;
                }
                else
                {
                    objdata.Status = "0";
                    objdata.Message = "Failure";
                    objdata.data = "";
                    //objdata.Reason = "Username or Password is Incorrect";
                    return objdata;
                }
            }
            catch (Exception ex)
            {
                objdata.Status = "Failure";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }


        public dynamic Rejectedclaims()
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.RejectedClaims();
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

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
                objdata.Status = "No data available";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }

        public dynamic RejectedClaimsItdawise(string Itdaname)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.RejectedClaimsItdawise(Itdaname);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

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
                objdata.Status = "No data available";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }
        public dynamic RejectedClaimsMandals(string Itdaname)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.RejectedClaimMandals(Itdaname);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

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
                objdata.Status = "No data available";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }

        public dynamic RejectedClaimsMandalwise(string Itdaname, string Mandal)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.RejectedClaimsMandalwise(Itdaname,Mandal);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

                    return objdata;
                }
                else
                {
                    objdata.Status = "0";
                    objdata.Message = "No Data available";
                    //objdata.Reason = "Username or Password is Incorrect";
                    return objdata;
                }
            }
            catch (Exception ex)
            {
                objdata.Status = "Failure";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }


        public dynamic RejectedClaimsClaimidwise(string Itdaname,string Mandal,string claimid )
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                DataTable dt = Landsettlementpattas.RejectedClaimsClaimidwise(Itdaname,Mandal,claimid);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

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
                objdata.Status = "No data available";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }


        public dynamic UpdateClaims(rejected_claims rcobj)
        {
            dynamic objdata = new ExpandoObject();
            try
            {

                string filepath=SaveImage(rcobj.imgbase64,rcobj.claimid,rcobj.itdaname);
                rcobj.filepath = filepath;
                string evidencepath = Evidence(rcobj.evidence, rcobj.claimid, rcobj.itdaname);
                rcobj.evidencepath = evidencepath;
                DataTable dt = Landsettlementpattas.Updateclaims(rcobj);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");



                if (dt != null && dt.Rows.Count > 0 &&dt.Rows[0]["status"].ToString()== "Success")
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                   

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

        public dynamic InsertClaims(rejected_claims rcobj)
        {
            dynamic objdata = new ExpandoObject();
            try
            {


                DataTable ds = Landsettlementpattas.GetClaimid(rcobj.itdaname,rcobj.DISTRICT,rcobj.Mandal);
                // DataTable dtc = ds.Tables[0];
                string claimid = ds.Rows[0]["CLAIMID"].ToString();
                string filepath = SaveImage(rcobj.imgbase64,claimid , rcobj.itdaname);
                rcobj.filepath = filepath;
                string evidencepath = Evidence(rcobj.evidence, claimid, rcobj.itdaname);
                rcobj.evidencepath = evidencepath;
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");
                rcobj.claimid = claimid;
                DataTable dt = Landsettlementpattas.Insertclaims(rcobj);

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "Success")
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";

                    objdata.claimid = dt.Rows[0]["CLAIM_ID"].ToString();
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

        public dynamic RejectedClaimsVillages(string Itdaname,string district, string mandal)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
               
                DataTable dt = Landsettlementpattas.RejectedClaimsVillages(Itdaname,district,mandal);
                // DataTable dt = clsdb.retdt(qhel.loginqueryhelper(username, password), "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.Status = "1";
                    objdata.Message = "Success";
                    objdata.data = dt;

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
                objdata.Status = "No data available";
                objdata.Reason = ex.Message;
                return objdata;
            }
        }
        public string SaveImage(string ImgStr,string claimid,string itdaname)
        {
            String path = HttpContext.Current.Server.MapPath("~/RejectedClaims"+"/"+itdaname); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = claimid + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return imgPath;
        }
        public string Evidence(string ImgStr, string claimid, string itdaname)
        {
            String path = HttpContext.Current.Server.MapPath("~/Evidencedocuments" + "/" + itdaname); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = claimid + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return imgPath;
        }


    }
}