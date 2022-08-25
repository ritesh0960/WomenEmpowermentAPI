using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WomenEmpowermentAPI.models;

namespace WomenEmpowerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeFamilyDetailsController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpPost]
        [Route("Add")]
        public IActionResult PostTraineeFamilyDetails(TraineeFamilyDetail familyDetails)
        {
            try
            {
                db.TraineeFamilyDetails.Add(familyDetails);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(new { error = "Something went wrong while adding personal details", errorMessage = e.Message });
            }

            return Ok(new { success = "Trainee Family Details Added Successfully", data = familyDetails });
        }

        [HttpGet]
        [Route("Get/{traineeId}")]
        public IActionResult GetTraineeFamilyDetails(int traineeId)
        {
            var familyDetails = new TraineeFamilyDetail();
            try
            {
                var data = db.TraineeFamilyDetails.ToList();
                familyDetails = (from d in data where d.TraineeId == traineeId select d).FirstOrDefault();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(familyDetails);
        }
    }
}