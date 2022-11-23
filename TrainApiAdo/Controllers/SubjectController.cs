using BLog.IServices;
using BLog.Services;
using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectService sbService;

        public SubjectController(ISubjectService sbService)
        {
            this.sbService = sbService;
        }

        [HttpGet("Get")]
        public string GetSubject()

        {
            try
            {
                DataTable subject = sbService.GetSubject();
                var serJson = JsonConvert.SerializeObject(subject);

                return serJson;
                //return Ok(serJson);

            }
            catch (Exception e)
            {

                return "err";//BadRequest(new { message = $"{e.StackTrace}" });
            }

        }
        //public DataTable GetSubject()
        //{
        //    DataTable subject = sbService.GetSubject();
        //    return subject;
        //}


    }
}
