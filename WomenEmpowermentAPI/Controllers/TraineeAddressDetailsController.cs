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
    public class TraineeAddressDetailsController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpPost]
        [Route("Add")]
        public IActionResult PostTraineeAddressDetails(TraineeAddressDetail addressDetails)
        {
            try
            {
                db.TraineeAddressDetails.Add(addressDetails);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while adding address details", errorMessage = e.Message });
            }

            return Ok(new { success = "Trainee Address Details Added Successfully", data = addressDetails });
        }


        [HttpGet]
        [Route("Get/{traineeId}")]
        public IActionResult GetTraineeAddressDetails(int traineeId)
        {
            var addressDetails = new TraineeAddressDetail();
            try
            {
                var data = db.TraineeAddressDetails.ToList();
                addressDetails = (from d in data where d.TraineeId == traineeId select d).FirstOrDefault();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(addressDetails);
        }
    }
}