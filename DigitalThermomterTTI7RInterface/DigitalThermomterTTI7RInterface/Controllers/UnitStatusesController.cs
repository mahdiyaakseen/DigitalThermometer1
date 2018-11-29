using DigitalThermomterTTI7RInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalThermomterTTI7RInterface.Controllers
{
  
    public class UnitStatusesController : Controller
    {

        public UnitStatus unitStatus;

        // GET: UnitStatuses/GetStatus
        [Route("UnitStatuses/GetStatus/{StatusName}")]
        public ActionResult GetStatus(string StatusName)
        {
            //set status to true or false
            unitStatus = StatusTypeSwitch(StatusName);
            return View(unitStatus);
        }


        private UnitStatus StatusTypeSwitch(string unitStatusName)
        {
            var unitStatus = new UnitStatus();
            switch (unitStatusName)
            {
                case "Self Test":
                    unitStatus.Name = "Self Test";
                    //call method to get selftest status
                    unitStatus.State = true;
                    unitStatus.StateToggled = true;
                    break;
                case "Beeper":
                    unitStatus.Name = "Beeper";
                    //call method to get selftest status
                    break;
                case "Back Light":
                    unitStatus.Name = "Back Light";
                    //call method to get selftest status
                    break;
                case "Time And Date Logging":
                    unitStatus.Name = "Time And Date Logging";
                    //call method to get selftest status
                    break;
                default:
                    //do nothing
                    break;
            }
            return unitStatus;
        }
    }
}