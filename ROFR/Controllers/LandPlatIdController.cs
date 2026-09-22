using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ROFR.helper;
using ROFR.NewHelper;
namespace ROFR.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("Giribhumi")]
    public class LandPlatIdController : ApiController
    {
        GiribhumiSupport gs = new GiribhumiSupport();
        Profile.Security ps = new Profile.Security();

        dynamic obj_data = new ExpandoObject();

        SQLManager sm = new SQLManager();
        private string assignedStatePrefix = "AP";

        [HttpPost]
        [Route("GetUniquId")]
        public  string GenerateLandParcelId()
        {
            return assignedStatePrefix + Verhoeff.getFarmLandUniqueIdWithChecksum();
        }

        [HttpPost]
        [Route("GetandUpdateuniqueID")]
        public dynamic GetUpdatedata(ROFRData obj)
        {

            try
            {
                return  gs.ROFR_GetUpdate(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        
    }

    
}
