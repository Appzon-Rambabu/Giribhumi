using ROFR.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ROFR.Controllers
{
    public class GodwansController : ApiController
    {
        ProjectRofrBAL.GetMasterDetails latlonhelper = new ProjectRofrBAL.GetMasterDetails();
        [HttpPost]
        [Route("api/Godwans/Latlongslist")]
        public dynamic Districtslatlongsdata(dynamic root)
        {

            string jsondata = JsonConvert.SerializeObject(root);
            try
            {


                return Ok(latlonhelper.Get_latlonglist(root));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }


        }
    }
}