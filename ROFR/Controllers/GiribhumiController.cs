using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using ROFR.helper;
using System.Dynamic;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Cors;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using ROFR.Models;
using System.Globalization;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ROFR.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("Giribhumi")]

    public class GiribhumiController : ApiController
    {
        GiribhumiSupport gs = new GiribhumiSupport();
        Profile.Security ps = new Profile.Security();

        dynamic obj_data = new ExpandoObject();

        SQLManager sm = new SQLManager();
        /// <summary>
        /// Created by Bhagya on 29-06-2020 for Girivikasam website for 1B data retrieving..Db Vasavi
        /// type:1 return datatable
        /// </summary>
        /// <param name="obj">
        /// Idtaname
        /// District
        /// Mandal
        /// Village
        /// </param>
        /// <returns></returns>
        /// 

        // for  lANDSTATUSREPORT Beneficiary
        [HttpPost]
        [Route("GetLandstatusBeneficiary_report")]
        public dynamic GetLandstatus_Beneficiary_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("LandstatusBeneficiary_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_LandStatus_Beneficiary_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("LandstatusBeneficiary_report_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // for  lANDSTATUSREPORT 
        [HttpPost]
        [Route("GetLandstatus_report")]
        public dynamic GetLandstatus_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Landstatus_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_LandStatus_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Landstatus_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        //GetRythubharosaPaymentstatus
        [HttpPost]
        [Route("GetRythubharosaPaymentstatus_report")]
        public dynamic GetRythubharosaPaymentstatus(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("GetRythubharosaPaymentstatus_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_RythubharosaPaymentStatus_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("GetRythubharosaPaymentstatus_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // for Benificiarywise 
        [HttpPost]
        [Route("GetBenficiarywise_report")]
        public dynamic GetBenficiarywise_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Benficiarywise_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_benificiary_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Benificiary_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]

        [Route("GetAdangal")]
        public dynamic GetAdangal(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_Ecrop_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]

        [Route("Girivikasam_Rofr")]
        public dynamic Girivikasam_Rofr(addbeneficiary_details obj)
        {

            try
            {
                return gs.Girivikasam_Rofr_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpPost]
        [Route("Epassbook")]
        public dynamic Epassbook(addbeneficiary_details obj)
        {

            try
            {
                return gs.Epassbook_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ViewEpassbook")]
        public dynamic ViewEpassbook(addbeneficiary_details obj)
        {

            try
            {
                return gs.ViewEpassbook_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ROFR_MASTERS")]
        public dynamic ROFR_MASTERS(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rofr_Masters_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("GIRIVIKASAM_DROPDOWNS")]
        public dynamic GIRIVIKASAM_DROPDOWNSs(addbeneficiary_details obj)
        {

            try
            {
                return gs.Girivikasam_Masters_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpPost]
        [Route("Rythubarosa")]
        public dynamic Rythubarosa(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rythubarosa_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Rofr_Extent_data")]
        public dynamic Rofr_Extent_data(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rofr_Extent_data_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        ///Giribhumi Controler 
        /// <summary>  
        /// Upload Document.....  
        /// </summary>        
        /// <returns></returns>  
        [HttpPost]
        [Route("MultipartImage_Upload")]
        public async Task<HttpResponseMessage> MultipartImage_Upload()
        {
            // Check if the request contains multipart/form-data.  
            dynamic obj = new ExpandoObject();
            dynamic res = new ExpandoObject();
            string response;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            //access files  
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

            string ctype1 = file1.Headers.ContentType.ToString();
            string extension1 = System.IO.Path.GetExtension(thisFileName);
            int count1 = thisFileName.Split('.').Length - 1;

            string filename = String.Empty;

            Stream input = await file1.ReadAsStreamAsync();

            string directoryName = String.Empty;
            string DocsPath = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];
            string path = String.Empty;
            HttpContent file2 = files[1];
            var thisFileName1 = file2.Headers.ContentDisposition.FileName.Trim('\"');

            string ctype2 = file2.Headers.ContentType.ToString();
            string extension2 = System.IO.Path.GetExtension(thisFileName1);
            int count2 = thisFileName1.Split('.').Length - 1;
            string filename1 = String.Empty;
            string path1 = String.Empty;
            Stream input1 = await file2.ReadAsStreamAsync();
            string directoryName1 = String.Empty;
            string DocsPath1 = String.Empty;
            string URL1 = String.Empty;
            string tempDocUrl1 = WebConfigurationManager.AppSettings["DocsUrl"];
            if ((count1 > 1) || (count2 > 1))
            {
                res.Status = "102";
                res.Message = "Please enter valid Images format";
                res.Reason = "Filename contains double extensions";
                var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                return respons;
            }
            else if (file1.Headers.ContentLength > 2000000 && file2.Headers.ContentLength > 2000000)
            {
                res.Status = "107";
                res.Message = "File size exceeds 2 MB";
                res.Reason = "File size exceeds 2 MB";
                var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                return respons;
            }
            else
            {

                if (formData["ClientDocs"] == "ClientDocs")
                {

                    if ((extension1 == ".jpg" || extension1 == ".jpeg" || extension1 == ".JPG" || extension1 == ".JPEG" || extension1 == ".png" || extension1 == ".PNG") && (extension2 == ".jpg" || extension2 == ".jpeg" || extension2 == ".JPG" || extension2 == ".JPEG" || extension2 == ".png" || extension2 == ".PNG"))
                    {
                        if ((ctype1 == "image/png" || ctype1 == "image/jpeg" || ctype1 == "image/*") && (ctype2 == "image/png" || ctype2 == "image/jpeg" || ctype2 == "image/*"))
                        {
                            path = @"F:\tribal\Land Images\Image1";
                            //path = @"D:\tribal\Land Images\Image1";
                            directoryName = System.IO.Path.Combine(path, "Land Images" + "/" + "Image1");


                            filename = System.IO.Path.Combine(path, (DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + formData["id"] + "_" + thisFileName));
                            //Deletion exists file  
                            if (File.Exists(filename))
                            {
                                File.Delete(filename);
                            }

                            // DocsPath = tempDocUrl + "/" + directoryName;
                            //  DocsPath = System.IO.Path.Combine(tempDocUrl, directoryName);
                            // DocsPath = System.IO.Path.GetFullPath(path);
                            DocsPath = tempDocUrl + "/" + "Rofr Images" + "/" + "Land Images" + "/" + "Image1";
                            URL = DocsPath + thisFileName;


                            // var path1 = HttpRuntime.AppDomainAppPath;
                            // path1 = @"E:\test\Land Images\Image2";
                            path1 = @"F:\tribal\Land Images\Image2";

                            directoryName1 = System.IO.Path.Combine(path1, "Land Images" + "/" + "Image2");


                            // filename1 = System.IO.Path.Combine(directoryName1, (DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + formData["id"] + "_" + thisFileName1));
                            filename1 = System.IO.Path.Combine(path1, (DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + formData["id"] + "_" + thisFileName1));
                            //Deletion exists file  
                            if (File.Exists(filename1))
                            {
                                File.Delete(filename1);
                            }

                            DocsPath1 = tempDocUrl1 + "/" + "Rofr Images" + "/" + "Land Images" + "/" + "Image2";
                            URL1 = DocsPath1 + thisFileName1;
                            //Directory.CreateDirectory(@directoryName); 
                            using (Stream file = File.OpenWrite(filename))
                            {
                                input.CopyTo(file);
                                //close file  

                                file.Close();
                            }
                            using (Stream filen = File.OpenWrite(filename1))
                            {
                                input1.CopyTo(filen);
                                //close file  

                                filen.Close();
                            }
                            obj.Land_Filename = DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + formData["id"] + "_" + thisFileName;
                            obj.Land_Image = DocsPath;
                            //obj.Land_Image = filename;
                            // obj.Land_Image = path;
                            obj.Land_Filename1 = DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + formData["id"] + "_" + thisFileName1;
                            obj.Land_Image1 = DocsPath1;
                            // obj.Land_Image1 = path1;
                            obj.Benficiary_id = formData["benid"];
                            obj.plotid = formData["id"];
                            obj.TYPE = formData["TYPE"];
                            obj.username = formData["username"];
                            obj.ip = formData["ip"];
                            obj.latitude = formData["latitude"];
                            obj.longitude = formData["longitude"];
                            res = gs.Multipart_Image_Valid(obj);
                            var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                            return respons;
                        }
                        else
                        {
                            res.Status = "104";
                            res.Message = "Selected files are not Image. Please check and select Image to upload";
                            res.Reason = "Files are not in Image Format";
                            var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                            return respons;
                        }
                    }
                    else
                    {
                        res.Status = "103";
                        res.Message = "Only jpeg or png formats are allowed for images";
                        res.Reason = "Files are not in Valid Format";
                        //return res;
                        var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                        return respons;
                    }
                }

            }
            //return Request.CreateResponse(HttpStatusCode.OK, new { res });
            return res;

        }


        [HttpPost]
        [Route("Rofr_Plot_Details")]
        public dynamic Rofr_Plot_Details(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rofr_Plot_Details_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ROFR_MASTERS_DATA")]
        public dynamic ROFR_MASTERS_DATA(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rofr_masters_data_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ROFR_MOBILE_VESION")]
        public dynamic ROFR_MOBILE_VESION(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rofr_mobile_version_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpGet]
        [Route("Farmer_Details_Card")]
        public dynamic Farmer_Details_Card()
        {

            try
            {
                return gs.Farmer_Details_Card_valid();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpGet]
        [Route("Farmer_Card_Latlongs")]
        public dynamic Farmer_Card_Latlongs()
        {

            try
            {
                return gs.Farmer_Card_valid();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpGet]
        [Route("Farmer_Card_Compartment")]
        public dynamic Farmer_Card_Compartment()
        {

            try
            {
                return gs.Farmer_Card_Compartment_valid();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpGet]
        [Route("Land_Status_Report")]
        public dynamic Land_Status_Report()
        {

            try
            {
                return gs.Land_Status_Report_valid();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Land_Images_Report")]
        public dynamic Land_Images_Report(addbeneficiary_details obj)
        {

            try
            {
                return gs.Land_Images_Report_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("Rofr_ben_Details")]
        public dynamic Rofr_ben_Details(addbeneficiary_details obj)
        {

            try
            {
                string logdata = obj.ToString();
                string mappath = HttpContext.Current.Server.MapPath("Rofr_ben_DetailsResponsesuccesslogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Rofr_ben_Details_valid(obj);
            }
            catch (Exception ex)
            {
                string logdata = ex.Message;
                string mappath = HttpContext.Current.Server.MapPath("Rofr_ben_DetailsResponselogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }



        [HttpPost]
        [Route("Multipart_Dlc_Upload")]
        public async Task<HttpResponseMessage> Multipart_Dlc_Upload()
        {
            dynamic res = new ExpandoObject();

            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var provider = await Request.Content.ReadAsMultipartAsync(
                    new InMemoryMultipartFormDataStreamProvider());

                NameValueCollection formData = provider.FormData;
                IList<HttpContent> files = provider.Files;

                if (files == null || files.Count == 0)
                {
                    res.Status = "105";
                    res.Message = "No file uploaded";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                HttpContent file = files[0];

                string originalFileName = file.Headers.ContentDisposition.FileName.Trim('"');
                string safeFileName = Path.GetFileName(originalFileName);

                string extension = Path.GetExtension(safeFileName).ToLower();
                string contentType = file.Headers.ContentType.MediaType;

                // 🔹 Validate extension
                if (!(extension == ".jpg" || extension == ".jpeg" ||
                      extension == ".png" || extension == ".pdf"))
                {
                    res.Status = "103";
                    res.Message = "Only JPG, PNG or PDF allowed";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                // 🔹 Validate MIME
                if (!(contentType == "image/jpeg" ||
                      contentType == "image/png" ||
                      contentType == "application/pdf"))
                {
                    res.Status = "104";
                    res.Message = "Invalid file type";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                // 🔹 Get Date
                string folderDate = formData["Dlc_date"];

                if (string.IsNullOrWhiteSpace(folderDate))
                {
                    res.Status = "108";
                    res.Message = "Dlc_date missing";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                DateTime parsedDate;
                if (!DateTime.TryParse(folderDate, out parsedDate))
                {
                    res.Status = "107";
                    res.Message = "Invalid date";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                string formattedFolder = parsedDate.ToString("dd-MM-yyyy");

                // 🔹 Base Path
                string basePath = @"F:\tribal\DLC";

                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                string physicalFolderPath = Path.Combine(basePath, formattedFolder);

                if (!Directory.Exists(physicalFolderPath))
                    Directory.CreateDirectory(physicalFolderPath);

                // 🔹 Create new filename
                string fileDate = DateTime.Now.ToString("dd-MM-yyyy");
                string newFileName = fileDate + "_" + safeFileName;

                string fullPath = Path.Combine(physicalFolderPath, newFileName);

                // 🔹 Save file
                using (Stream input = await file.ReadAsStreamAsync())
                using (FileStream output = new FileStream(fullPath, FileMode.Create))
                {
                    await input.CopyToAsync(output);
                }

                // 🔹 Create URL
                string DocsUrl = WebConfigurationManager.AppSettings["DocsUrl"];
                string fileUrl = DocsUrl + "/DLC/" + formattedFolder + "/" + newFileName;

                // 🔹 MULTIPLE ID SUPPORT
                string ids = formData["ID"];  // example: "1,2,3"

                if (string.IsNullOrWhiteSpace(ids))
                {
                    res.Status = "109";
                    res.Message = "No ID selected";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                string[] idArray = ids.Split(',');

                int typeValue;
                if (!int.TryParse(formData["TYPE"], out typeValue))
                {
                    res.Status = "110";
                    res.Message = "Invalid TYPE";
                    return Request.CreateResponse(HttpStatusCode.OK, new { res });
                }

                foreach (string idStr in idArray)
                {
                    int idValue;
                    if (!int.TryParse(idStr.Trim(), out idValue))
                        continue;

                    dynamic obj = new ExpandoObject();
                    obj.DLCPATH = fileUrl;
                    obj.Dlc_date = formattedFolder;
                    obj.ID = idValue;
                    obj.TYPE = typeValue;

                    // 🔹 Call your DB method
                    gs.Multipart_Dlc_Valid(obj);
                }

                res.Status = "200";
                res.Message = "File uploaded and saved for multiple IDs successfully";
                return Request.CreateResponse(HttpStatusCode.OK, new { res });
            }
            catch (Exception ex)
            {
                res.Status = "500";
                res.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, new { res });
            }
        }






        //[HttpPost]
        //[Route("Multipart_Dlc_Upload")]
        //public async Task<HttpResponseMessage> Multipart_Dlc_Upload()
        //{
        //    // Check if the request contains multipart/form-data.  
        //    dynamic obj = new ExpandoObject();
        //    dynamic res = new ExpandoObject();
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
        //    //access form data  
        //    NameValueCollection formData = provider.FormData;
        //    //access files  
        //    IList<HttpContent> files = provider.Files;

        //    HttpContent file1 = files[0];
        //    var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

        //    string ctype1 = file1.Headers.ContentType.ToString();
        //    string extension1 = System.IO.Path.GetExtension(thisFileName);
        //    int count1 = thisFileName.Split('.').Length - 1;

        //    string filename = String.Empty;
        //    Stream input = await file1.ReadAsStreamAsync();
        //    string directoryName = String.Empty;
        //    string DocsPath = String.Empty;
        //    string URL = String.Empty;
        //    string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];


        //    string dateformat = String.Empty;
        //    if ((count1 > 1))
        //    {
        //        res.Status = "102";
        //        res.Message = "Please enter valid Images format";


        //        res.Reason = "Filename contains double extensions";
        //        var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
        //        return respons;
        //    }
        //    else
        //    {
        //        if (formData["Dlcfile"] == "Dlcfile")
        //        {
        //            if ((extension1 == ".jpg" || extension1 == ".jpeg" || extension1 == ".JPG" || extension1 == ".JPEG" || extension1 == ".png" || extension1 == ".PNG" || extension1 == ".pdf" || extension1 == ".PDF"))
        //            {
        //                if ((ctype1 == "image/png" || ctype1 == "image/jpeg" || ctype1 == "application/pdf"))

        //                {
        //                    dateformat = formData["dlc_date"];

        //                    dateformat = dateformat.Replace("/", "-");


        //                    string location = HttpContext.Current.Server.MapPath("~/DLC/" + dateformat + "/");

        //                    if (!Directory.Exists(location))
        //                    {
        //                        Directory.CreateDirectory(location);

        //                    }
        //                    var path = HttpRuntime.AppDomainAppPath;
        //                    directoryName = System.IO.Path.Combine(path, "DLC" + "/" + dateformat);
        //                    filename = System.IO.Path.Combine(directoryName, (DateTime.Now.ToString("dd-MM-yyyy") + "_" + thisFileName));

        //                    //Deletion exists file  
        //                    if (File.Exists(filename))
        //                    {
        //                        File.Delete(filename);
        //                    }

        //                    DocsPath = tempDocUrl + "/" + "DLC" + "/" + dateformat;
        //                    URL = DocsPath + "/" + (DateTime.Now.ToString("dd-MM-yyyy") + "_" + thisFileName);

        //                    //Directory.CreateDirectory(@directoryName); 
        //                    using (Stream file = File.OpenWrite(filename))
        //                    {
        //                        input.CopyTo(file);
        //                        //close file  

        //                        file.Close();
        //                    }

        //                    obj.DLCPATH = URL;
        //                    obj.Dlc_date = dateformat;


        //                    obj.ID = formData["ID"];

        //                    obj.TYPE = formData["TYPE"];



        //                    res = gs.Multipart_Dlc_Valid(obj);
        //                    var response = Request.CreateResponse(HttpStatusCode.OK, new { res });
        //                    // response.Headers.Add("DocsUrl", URL);
        //                    return response;
        //                }
        //                else
        //                {
        //                    res.Status = "104";
        //                    res.Message = "Selected files are not Image or PDF. Please check and select Image or PDF to upload";


        //                    res.Reason = "Files are not in specified Format";
        //                    // response = Request.CreateResponse(HttpStatusCode.OK, new { res }).ToString();
        //                    //return res;
        //                    var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
        //                    return respons;
        //                }
        //            }
        //            else
        //            {
        //                res.Status = "103";
        //                res.Message = "Only jpeg or png,pdf formats are allowed ";


        //                res.Reason = "Files are not in Valid Format";
        //                //return res;
        //                var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
        //                return respons;
        //            }
        //        }
        //    }
        //    return res;

        //}




        [HttpPost]
        [Route("Rofr")]
        public dynamic Rofr(dynamic obj)
        {

            try
            {
                dynamic token = new ExpandoObject();
                token = ps.openToken(obj);
                return token;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }

        [HttpPost]
        [Route("RB_STATUS")]
        public dynamic RB_STATUS(addbeneficiary_details obj)
        {

            try
            {

                return gs.RB_STATUS_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("RTGS_INSERT_DATA")]
        public dynamic RTGS_INSERT_DATA(Rtgs lmobj)
        {
            // DataTable dt = new DataTable();
            //var data = "";
            dynamic data = new ExpandoObject();
            addbeneficiary_details obj = new addbeneficiary_details();
            obj.Type = "1";
            DataTable dt = GiribhumiSupport.Get_RTGS_INSERT_Valid(obj);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    lmobj.beficiaryId = dt.Rows[i]["BENFICIARY_ID"].ToString();
                    lmobj.itdaName = dt.Rows[i]["ITDA_NAME"].ToString();
                    lmobj.districtName = dt.Rows[i]["DISTRICT"].ToString();
                    lmobj.districtId = dt.Rows[i]["DISTRICT_CODE"].ToString();
                    lmobj.mandalName = dt.Rows[i]["MANDAL"].ToString();
                    lmobj.mandalId = dt.Rows[i]["MANDAL_CODE"].ToString();
                    lmobj.revVillageId = dt.Rows[i]["VILLAGE_REVCODE"].ToString();
                    lmobj.revVillageName = dt.Rows[i]["REV_VILLAGE"].ToString();
                    lmobj.villageName = dt.Rows[i]["VILLAGE"].ToString();
                    lmobj.villageId = dt.Rows[i]["VILLAGE_CODE"].ToString();
                    lmobj.pattadharName = dt.Rows[i]["ROFR_PATTADAAR"].ToString();
                    lmobj.fatherName = dt.Rows[i]["FATHER_NAME"].ToString();
                    lmobj.uidNum = dt.Rows[i]["AADHAAR_NO"].ToString();
                    lmobj.caste = dt.Rows[i]["CASTE"].ToString();
                    lmobj.dob = dt.Rows[i]["DOB"].ToString();
                    lmobj.gender = dt.Rows[i]["GENDER"].ToString();
                    lmobj.mobileNumber = dt.Rows[i]["MOBILE_NO"].ToString();
                    lmobj.surveyNo = dt.Rows[i]["SURVEY NUMBER"].ToString();
                    lmobj.khathaNo = dt.Rows[i]["KHATHA NUMBER"].ToString();
                    lmobj.extent = dt.Rows[i]["EXTENT"].ToString();

                    string url = "http://peoplehubservices.ap.gov.in/rtgs/api/thirdParty/rofrDetailsPull";

                    // GetData(url);
                    var val = PostData(url, lmobj);
                    data = GetSerialzedData<dynamic>(val);
                    if (data.success == true)
                    {
                        obj.Type = "2";
                        obj.Benificiary_id = data.personDetails[0]["BENFICIARY_ID"].ToString();
                        obj.Aadhaar_NO = data.personDetails[0]["UID_NUM"].ToString();
                        GiribhumiSupport.Get_RTGS_INSERT_Valid(obj);
                    }
                }
            }
            data.Success = "Sucess";
            data.Message = "Updated Successfully";
            return data;
        }
        public T GetSerialzedData<T>(string Input)
        {
            return JsonConvert.DeserializeObject<T>(Input);
        }


        public dynamic PostData(string url, dynamic jsonData)
        {
            var response = String.Empty;
            try
            {

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Headers.Add("username", "tribal");
                req.Headers.Add("password", "5a93b8c1a2763c61396bb5e346a9a528718021bf14226f06a699e19252564a1e");
                //req.Headers.Add("Session_Key", "969A687C0F273H0852A75347529CF5D385974995FC1B9JJ97CD0RFV07A215RElTUEFUQ0G");

                //req.Credentials = CredentialCache.DefaultCredentials;
                WebProxy myProxy = new WebProxy();
                req.Proxy = myProxy;
                req.Method = "POST";
                var _jsonObject = JsonConvert.SerializeObject(jsonData);

                //If there is any json data
                if (!String.IsNullOrEmpty(_jsonObject))
                {
                    using (System.IO.Stream s = req.GetRequestStream())
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                            sw.Write(_jsonObject);


                    }
                }
                req.ContentType = "application/json; charset=utf-8";
                req.AllowAutoRedirect = false;
                var resp = (HttpWebResponse)req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());

                if ((resp.StatusCode == HttpStatusCode.Redirect) || (resp.StatusCode == HttpStatusCode.SeeOther) ||
                    (resp.StatusCode == HttpStatusCode.RedirectMethod))
                {
                }
                else
                {
                    response = sr.ReadToEnd().Trim();
                }
            }
            catch (WebException wex)
            {
                throw new Exception(wex.Message);
            }

            return response;
        }




        [HttpGet]
        [Route("LAND_HOLDING_DYNAMIC_SERVICE")]
        public dynamic LAND_HOLDING_DYNAMIC_SERVICE()
        {

            try
            {
                return gs.LAND_HOLDING_DYNAMIC_SERVICE();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("FARMER_IMAGES_REPORT")]
        public dynamic FARMER_IMAGES_REPORT(addbeneficiary_details obj)
        {

            try
            {
                return gs.Farmer_Images_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("DLC_REPORT")]
        public dynamic DLC_REPORT(addbeneficiary_details obj)
        {

            try
            {
                return gs.Dlc_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Rythubharosa_2019")]
        public dynamic Rythubharosa_2019(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rythubharosa_2019_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Rythubharosa_2020")]
        public dynamic Rythubharosa_2020(addbeneficiary_details obj)
        {

            try
            {
                return gs.Rythubharosa_2020_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Land_Invalid_Data")]
        public dynamic Land_Invalid_Data(addbeneficiary_details obj)
        {

            try
            {
                return gs.Land_Invalid_Data_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("RoFrFamilyCard")]
        public dynamic familyCard(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_FamilyCard(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Beneficiary_Details")]
        public dynamic Beneficiary_Details(addbeneficiary_details obj)
        {

            try
            {
                return gs.Beneficiary_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Missing_Data")]
        public dynamic Missing_Data(addbeneficiary_details obj)
        {

            try
            {
                return gs.Missing_Data_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpPost]
        [Route("Benificiarywise_Land_Status")]
        public dynamic Benificiarywise_Land_Status(addbeneficiary_details obj)
        {

            try
            {
                return gs.Benificiarywise_Land_Status_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ROFR_RTGS_DATA")]
        public dynamic ROFR_RTGS_DATA(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string Status = gs.VerifyToken(headers);
            // string Status = "success";
            if (Status == "success")
            {
                try
                {
                    obj_data = gs.ROFR_RTGS_Valid(obj);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                obj_data.code = "101";
                obj_data.message = Status;



            }
            return obj_data;
        }


        [HttpPost]
        [Route("ROFR_RTGS_STATUSFLAG")]
        public dynamic ROFR_RTGS_STATUSFLAG(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string Status = gs.VerifyToken(headers);

            if (Status == "success")
            {
                try
                {
                    obj_data = gs.ROFR_RTGS_STATUSFLAG_valid(obj);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                obj_data.code = "101";
                obj_data.message = Status;
            }
            return obj_data;
        }


        [HttpPost]
        [Route("ROFR_YSR_JALAKALA")]
        public dynamic ROFR_YSR_JALAKALA(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string Status = gs.VerifyToken(headers);
            // string Status = "success";
            if (Status == "success")
            {
                try
                {
                    obj_data = gs.ROFR_YSR_JALAKALA_Valid(obj);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                obj_data.code = "101";
                obj_data.message = Status;



            }
            return obj_data;
        }


        [HttpPost]
        [Route("ROFR_YSR_JALAKALA_RES")]
        public dynamic ROFR_YSR_JALAKALA_RES(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string Status = gs.VerifyToken(headers);
            // string Status = "success";
            if (Status == "success")
            {
                try
                {
                    obj_data = gs.ROFR_JALAKALA_RES_valid(obj);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                obj_data.code = "101";
                obj_data.message = Status;



            }
            return obj_data;
        }


        [HttpPost]
        [Route("ROFR_NREGA")]
        public dynamic ROFR_NREGA(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string Status = gs.VerifyToken(headers);
            // string Status = "success";
            if (Status == "success")
            {
                try
                {
                    obj_data = gs.ROFR_NREGA_Valid(obj);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                obj_data.code = "101";
                obj_data.message = Status;



            }
            return obj_data;
        }


        [HttpPost]
        [Route("RYTHUBHAROSA_MAY_2021")]
        public dynamic RYTHUBHAROSA_MAY_2021(dynamic root)
        {

            string jsondata = JsonConvert.SerializeObject(root);
            try
            {


                return Ok(gs.RYTHUBHAROSA_MAY_2021(root));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }

        [HttpPost]
        [Route("pdfimagedataconversion")]
        public dynamic pdfimagedataconversion(dynamic root)
        {

            string jsondata = JsonConvert.SerializeObject(root);
            try
            {
                var json = JsonConvert.SerializeObject(root);
                dynamic objre = JsonConvert.DeserializeObject<ExpandoObject>(json);
                ProjectRofrBAL.GetMasterDetails Obj = new ProjectRofrBAL.GetMasterDetails();

                return Ok(Obj.Get_Land_Images_Report1(root));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }


        [HttpPost]
        [Route("JalakalReport")]
        public dynamic JalakalReport(addbeneficiary_details obj)
        {

            try
            {
                return gs.jalakalreport(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        //[HttpPost]
        //[Route("Update_FarmerImage")]
        //public dynamic Update_FarmerImage(addbeneficiary_details obj)
        //{
        //    Landsettlementpattas ls = new Landsettlementpattas();

        //    try
        //    {
        //        return gs.farUploadImage(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
        //    }

        //}


        [HttpPost]
        [Route("Update_FarmerImage")]
        public async Task<HttpResponseMessage> Update_FarmerImage()
        {
            // Check if the request contains multipart/form-data.  
            dynamic obj = new ExpandoObject();
            dynamic res = new ExpandoObject();
            string response;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            //access files  
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

            string ctype1 = file1.Headers.ContentType.ToString();
            string extension1 = System.IO.Path.GetExtension(thisFileName);
            int count1 = thisFileName.Split('.').Length - 1;

            string imagefloder = formData["itda"].ToString() + formData["distid"].ToString();
            string filename = String.Empty;

            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string DocsPath = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];
            string path = String.Empty;

            if ((count1 > 1))
            {
                res.Status = "102";
                res.Message = "Please enter valid Images format";


                res.Reason = "Filename contains double extensions";
                var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                return respons;
            }
            else if (file1.Headers.ContentLength > 4000000)
            {
                res.Status = "107";
                res.Message = "File size exceeds 4 MB";


                res.Reason = "File size exceeds 4 MB";
                var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                return respons;
            }
            else
            {

                if (formData["UpdateFarmerImage"] == "UpdateFarmerImage")
                {
                    if ((extension1 == ".jpg" || extension1 == ".jpeg" || extension1 == ".JPG" || extension1 == ".JPEG" || extension1 == ".png" || extension1 == ".PNG"))
                    {

                        if ((ctype1 == "image/png" || ctype1 == "image/jpeg" || ctype1 == "image/*"))
                        {
                            string sc = @"\";

                            string locpath = @"F:\tribal\BeneficairyImages\";

                            string benid = formData["benid"].ToString();

                            string location = (locpath + DateTime.Now.ToString("dd-MM-yyyy") + sc + imagefloder + sc + benid + sc);

                            if (!Directory.Exists(location))
                            {
                                Directory.CreateDirectory(location);
                            }
                            obj.Land_Filename = DateTime.Now.ToString("dd-MM-yyyy") + "_" + formData["benid"] + "_" + thisFileName; //file.FileName;
                            file.SaveAs(location + obj.Land_Filename);//file.FileName);
                            obj.Land_Image = location;
                            obj.username = formData["username"];
                            obj.benid = formData["benid"];
                            obj.Type = formData["Type"];
                            //obj.username = formData["username"];
                            obj.ip = formData["ip"];
                            obj.latitude = formData["latitude"];
                            obj.longitude = formData["longitude"];
                            res = gs.updateImage_Valid(obj);

                            var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                            return respons;
                        }
                        else
                        {
                            res.Status = "104";
                            res.Message = "Selected files are not Image. Please check and select Image to upload";
                            res.Reason = "Files are not in Image Format";

                            var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                            return respons;
                        }
                    }
                    else
                    {
                        res.Status = "103";
                        res.Message = "Only jpeg or png formats are allowed for images";


                        res.Reason = "Files are not in Valid Format";
                        //return res;
                        var respons = Request.CreateResponse(HttpStatusCode.OK, new { res });
                        return respons;
                    }
                }

            }
            //return Request.CreateResponse(HttpStatusCode.OK, new { res });
            return res;

        }



        [HttpPost]
        [Route("GetFarmerImage_Details")]
        public dynamic GetFarmerImage_Details(addbeneficiary_details obj)
        {
            Landsettlementpattas ls = new Landsettlementpattas();

            try
            {
                return gs.GetUploadImage(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("GetItdaListmaster")]
        public dynamic Get_Itda(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_Itdas(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("GetDistrictsmaster")]
        public dynamic Get_District(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_Districts(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetMandalsmaster")]
        public dynamic Get_Mandals(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_Mandals(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetVillagesmaster")]
        public dynamic Get_Villages(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_Villages(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetCategory")]
        public dynamic GetCategory(addbeneficiary_details obj)
        {

            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    return gs.Get_healthdata(obj);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }


        [HttpPost]
        [Route("GetcategoryMeasurements")]
        public dynamic GetcategoryMeasurements(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    return gs.Get_healthdata1(obj);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }

        [HttpPost]
        [Route("INSRBVORBKINDENT")]
        public dynamic INSRBVORBKINDENT(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("RBK_INDENT_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_healthdata2(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {

                string mappath = HttpContext.Current.Server.MapPath("RBK_INDENT_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("INSRBKSTOCKRECEIVED")]
        public dynamic INSRBKSTOCKRECEIVED(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_healthdata3(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        //base64 to path
        [HttpPost]
        [Route("INSSTOCKPAYMENTDETAILS")]
        public dynamic INSSTOCKPAYMENTDETAILS(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("PAYMENT_DETAILS_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_healthdata4(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("PAYMENT_DETAILS_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("INSDAILYSTOCKUPDATE")]
        public dynamic INSDAILYSTOCKUPDATE(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("DAILY_STOCK_UPDATE_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_healthdata5(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DAILY_STOCK_UPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("Checkversion")]
        public dynamic version(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    return gs.versioncheck(obj);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }
            }
            catch (Exception ex)
            {
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("Login_status")]
        public dynamic Login_status(addbeneficiary_details obj)
        {

            try
            {
                return gs.Login_status_data_valid(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("OfficerLogin")]
        public dynamic OfficerLogin(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.Get_Login(obj);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Headers Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("LOGIN_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("DOEdit")]
        public dynamic DO_APPROVALS(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("DO_APPROVALS_EDIT_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_DoApprovals(dlogdata);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Edit_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("DODATES")]
        public dynamic DODATES(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {


                    return gs.Get_Do_Dates(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Edit_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("DOApprovalDetails")]
        public dynamic DO_Approval_Details(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.Get_DOApprovals_Details(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Approval_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("SOEdit")]
        public dynamic SO_APPROVALS(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("SO_APPROVALS_EDIT_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_SO_Approvals(dlogdata);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("SO_APPROVALS_EDIT_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("SOApprovalDetails")]
        public dynamic SO_Approval_Details(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    return gs.Get_SOApprovals_Details(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Approval_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("CEOApprovalDetails")]
        public dynamic CEO_APPROVAls(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    return gs.Get_CEO_Approvals(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("CEO_Approved_list_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("CEOEdit")]
        public dynamic CEO_APPROVALS(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("CEO_APPROVALS_EDIT_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.Get_Ceo_Approval(dlogdata);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("CEO_APPROVALS_EDIT_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("Profile_PasswordUpdate")]
        public dynamic ProfileUpdate(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("Profile_PasswordUpdate_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));

                    return gs.ProfilesUpdate(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Profile_PasswordUpdate_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("INDENTRAISECHECK")]
        public dynamic INDENTRAISECHECK(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {


                    return gs.IndentRaise(obj);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("IndentRaise_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("Reports")]
        public dynamic Reports(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.Get_reports(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Reports_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("PaymentCountDetails")]
        public dynamic PaymentCountDetails(addbeneficiary_details obj)
        {
            try
            {

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.Payment_Count(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("DateWisePayment")]
        public dynamic DateWisePayment(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {
                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("DATE_WISE_PAYMENT_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.INSERT_DatePayment(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DATE_WISE_PAYMENT_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("Paymentstockupdationdetails")]
        public dynamic Paymentstockupdationdetails(addbeneficiary_details obj)
        {
            try
            {


                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.Payment_updation(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("INSEOSTOCKINSERT")]
        public dynamic INSEOSTOCKINSERT(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("STOCK_insert_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.INSTSTOCKREC(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }



        [HttpPost]
        [Route("DAMAGEDIMAGEINS")]
        public dynamic DAMAGEDIMAGEINS(addbeneficiary_details obj)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    string logdata = JsonConvert.SerializeObject(obj);
                    addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                    string mappath = HttpContext.Current.Server.MapPath("STOCK_insert_SuccessLogs");
                    Log sqlmngr = new Log();
                    Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                    return gs.INsertdamageinsert(dlogdata);
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }




        [HttpPost]
        [Route("GETEOSTOCKACK")]
        public dynamic GETEOSTOCKACK(addbeneficiary_details obj)
        {
            try
            {


                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.EOSTKACK(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        [HttpPost]
        [Route("STOCKDASHBOARD")]
        public dynamic STOCKDASHBOARD(addbeneficiary_details obj)
        {
            try
            {


                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string Status = sm.StockVerifyToken(headers);

                if (Status == "success")
                {

                    return gs.EOSTKACKDASHBOARD(obj);

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Authentication Failure";
                    return obj_data;

                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("ApTourismserviceGetData")]
        public dynamic ApTourismservice(addbeneficiary_details obj)
        {
            try
            {
                return gs.GetData_Ap_Tourism(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Ap_Tourism_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }

        [HttpPost]
        [Route("ApTourismserviceinsert")]
        public dynamic ApTourismserviceInsert(addbeneficiary_details obj)
        {
            try
            {
                return gs.Insert_Ap_Tourism(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Insert_Ap_Tourism_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
            }
        }


        private static readonly HttpClient _httpClient = new HttpClient();
        public static HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        [HttpPost]
        [Route("GetToken")]

        public async Task<string> GetToken()
        {

            var requestBody = new
            {
                userName = "ap_citizen_CT",
                password = "CT_Ap@(2024)"
            };
            var json = JsonConvert.SerializeObject(requestBody);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://raisetribes.ap.gov.in/Api_Raisetribes/V1/CitizenService/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                string token = JsonConvert.DeserializeObject<TokenResponse>(tokenResponse).Bearer;
                return token;
            }
            return "Failed to generate token";
        }

        // Newly adding 11-11-2024 Getdata based token



        [HttpPost]
        [Route("GetHouseholdData")]

        public async void GetHouseholdData(Inputdet obj)
        {


            string tokenResponse = await GetToken();

            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", tokenResponse);

            var content = new StringContent(obj.DistrictCode, Encoding.UTF8, "text/plain");

            var response = await _httpClient.PostAsync("http://raisetribes.ap.gov.in/Api_Raisetribes/V1/CitizenService/GetTribalSTData", new StringContent(obj.DistrictCode));

            if (response.IsSuccessStatusCode)
            {
                var householdResponse = await response.Content.ReadAsStringAsync();
                HouseholdResponse householdData = JsonConvert.DeserializeObject<HouseholdResponse>(householdResponse);
                Giribhumi_get gt = new Giribhumi_get();
                if (householdData.HHData.Count > 0)
                {
                    foreach (Household house in householdData.HHData)
                    {
                        Household householdD = new Household
                        {
                            DistrictCode = house.DistrictCode,
                            DistrictName = house.DistrictName,
                            CitizenNumber = house.CitizenNumber,
                            CitizenName = house.CitizenName
                        };
                        gt.insertData_sp(householdD);
                    }


                }


            }


        }


        [HttpPost]
        [Route("GetDistrictsforHouse")]
        public dynamic Get_districts(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_DisReport(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }




        //03-12-2024 RTGS Data

        [HttpPost]
        [Route("GetRofrDataforRtgs")]
        public dynamic Get_RtgsData(addbeneficiary_details obj)
        {

            try
            {


                return gs.GetRtgsdata(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        //28-01-2025
        [HttpPost]
        [Route("GetRofrTotalDataforRtgs")]
        public dynamic Get_Data(addbeneficiary_details obj)
        {

            try
            {
                return gs.Getdata(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        //26-03-2025
        [HttpPost]
        [Route("TotalBenplotsdatatoRTGS")]
        public dynamic Get_RofrDataForRtgs(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetRofrdata(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }



        [HttpPost]
        [Route("BenplotsdatatoRTGS")]
        public IHttpActionResult Get_RofrDataForRtgs1(addbeneficiary_details obj)
        {
            try
            {
                RofrResponse result = gs.GetRofrdata1(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("BenplotsdatatoRTGS1")]
        public async Task<RofrResponse> Get_RofrDataForRtgs2(addbeneficiary_details obj)
        {
            RofrResponse result = new RofrResponse();
            try
            {
                result = gs.GetRofrdata1(obj);
                return await Task.FromResult<RofrResponse>(((Func<RofrResponse>)(() =>
                {
                    return result;
                }))());

            }
            catch (Exception ex)
            {
                return await Task.FromResult<RofrResponse>(((Func<RofrResponse>)(() =>
                {
                    return result = new RofrResponse(); ;
                }))());

            }
        }


        //28-04-2025

        [HttpPost]
        [Route("BenplotsdataToAgriculture")]
        public dynamic Get_RofrDataForAGRI1(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetRofrdataForAGri(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("BenplotsdataToAgic")]
        public dynamic Get_RofrDataForAGRI2(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetRofrdataForAGri(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        //08-09-2025 Agriculture
        [HttpPost]
        [Route("TotalplotsPushToAgic")]
        public dynamic Get_RofrData(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetRofrPushAGri(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        //08-10-2025 Agriculture
        [HttpPost]
        [Route("TotalplotsPushToAgriculture")]
        public dynamic Get_RofrData1(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetRofrPushAGri1(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }




        //17-02-2026 Forest Land Details For Agriculture

        [HttpPost]
        [Route("ForestLandDetails")]
        public IHttpActionResult ForestLandAGri(addbeneficiary_details obj)
        {
            try
            {
                var result = gs.GetForestLandDetails(obj);

                return Ok(result);  // HTTP 200
            }
            catch (Exception ex)
            {
                if (ex.Message == "101")
                {
                    return Content(HttpStatusCode.BadRequest, new
                    {
                        Code = "101",
                        Message = "Invalid village code"
                    });
                }
                else if (ex.Message == "102")
                {
                    return Content(HttpStatusCode.NotFound, new
                    {
                        Code = "102",
                        Message = "No data found"
                    });
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, new
                    {
                        Code = "500",
                        Message = ex.ToString()
                    });
                }
            }
        }

        //15-09-2026 Add New Get_AllDropDowns Method
        [HttpPost]
        [Route("GetAllDropDownmaster")]
        public dynamic Get_AllDropDown(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_AllDropDowns(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetFarmerDetailsMaster")]
        public dynamic GetFarmerDetails(CropDetails cropDetails)
        {

            try
            {
                return gs.GetFarmerDetails(cropDetails);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetFarmerPlotdetalis")]
        public dynamic GetPlotdetalis(CropDetails cropDetails)
        {

            try
            {
                return gs.GetPlotdetalis(cropDetails);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetCropCategorydetalis")]
        public dynamic GetCropCategory(CropDetails cropDetails)
        {

            try
            {
                return gs.GetCropCategory(cropDetails);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpPost]
        [Route("GetCropdetalisMaster")]
        public dynamic GetCropdetalis(CropDetails cropDetails)
        {

            try
            {
                return gs.GetCropdetalis(cropDetails);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
    }


}
