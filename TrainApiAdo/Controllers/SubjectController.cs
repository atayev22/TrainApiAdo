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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectService sbService;

        public SubjectController(ISubjectService sbService)
        {
            this.sbService = sbService;
        }

        [HttpGet]
        public IActionResult GetSubject()

        {
            try
            {
                DataTable subject = sbService.GetSubject();
                var serJson = JsonConvert.SerializeObject(subject);

                return Ok(serJson);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"{e.StackTrace}" });
            }

        }

        [HttpGet]
        public IActionResult GetSubjectById(int id)

        {
            try
            {
                DataTable subject = sbService.GetSubjectById(id);
                var serJson = JsonConvert.SerializeObject(subject);

                return Ok(serJson);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"{e.StackTrace}" });
            }

        }



    }
}
