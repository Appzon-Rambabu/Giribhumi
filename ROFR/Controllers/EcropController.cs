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
namespace ROFR.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Ecrop")]
    public class EcropController : ApiController
    {
      EcropSupport es = new EcropSupport();

        /// <summary>
        /// Created by Bhagya on 21-06-2020 for Ecrop data retrieving..Db Vasavi
        /// type:1 return datatable
        /// </summary>
        /// <param name="obj">
        /// Idtaname
        /// District
        /// Mandal
        /// Village
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Get_Ecrop")]
        public IHttpActionResult Get_Ecrop(addbeneficiary_details obj)
        {

            try
            {
                return Ok(es.Get_Ecrop_valid(obj));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        /// <summary>
        /// Created by Bhagya on 21-06-2020 for Ecrop data updating crop ..Db Vasavi
        /// type:2 return datatable
        /// </summary>
        /// <param name="obj">
        /// Idtaname
        /// District
        /// Mandal
        /// Village
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateEcrop")]
        public IHttpActionResult UpdateEcrop(addbeneficiary_details obj)
        {

            try
            {
                return Ok(es.UpdateEcrop_valid(obj));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
    }
}
