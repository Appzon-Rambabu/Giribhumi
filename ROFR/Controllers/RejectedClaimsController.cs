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
    [RoutePrefix("API")]
    public class RejectedClaimsController : ApiController
    {
        ClaimsSupport cs = new ClaimsSupport();
        [HttpGet]
        [Route("Login/{username}/{password}")]
        public IHttpActionResult Login(string username,string password)
        {

          
            return Ok(cs.Loginhelper(username,password));
       

        }
        [HttpGet]
        [Route("RejectedClaims")]
        public IHttpActionResult RejectedClaims()
        {
            return Ok(cs.Rejectedclaims());

        }

        [HttpGet]
        [Route("RejectedClaimsItdawise/{Itdaname}")]
        public IHttpActionResult RejectedClaimsItdawise(string Itdaname)
        {
            return Ok(cs.RejectedClaimsItdawise(Itdaname));

        }

        [HttpGet]
        [Route("RejectedClaimMandals/{Itdaname}")]
        public IHttpActionResult RejectedClaimMandals(string Itdaname)
        {
            return Ok(cs.RejectedClaimsMandals(Itdaname));

        }

        [HttpGet]
        [Route("RejectedClaimsMandalwise/{Itdaname}/{Mandal}")]
        public IHttpActionResult RejectedClaimsMandalwise(string Itdaname, string Mandal)
        {
            return Ok(cs.RejectedClaimsMandalwise(Itdaname,Mandal));

        }
        [HttpGet]
        [Route("RejectedClaimsClaimidwise/{Itdaname}/{Mandal}/{Claimid}")]
        public IHttpActionResult RejectedClaimsClaimidwise(string Itdaname, string Mandal,string Claimid)
        {
            return Ok(cs.RejectedClaimsClaimidwise(Itdaname,Mandal,Claimid));

        }

        [HttpPost]
        [Route("UpdateClaims")]
        public IHttpActionResult UpdateClaims(rejected_claims rcobj)
        {
            return Ok(cs.UpdateClaims(rcobj));

        }
        [HttpPost]
        [Route("InsertClaims")]
        public IHttpActionResult InsertClaims(rejected_claims rcobj)
        {
            return Ok(cs.InsertClaims(rcobj));

        }

        [HttpGet]
        [Route("RejectedClaimsVillages/{Itdaname}/{District}/{Mandal}")]
        public IHttpActionResult RejectedClaimsVillages(string Itdaname,string district,string mandal)
        {
            return Ok(cs.RejectedClaimsVillages(Itdaname,district,mandal));

        }

    }
}
