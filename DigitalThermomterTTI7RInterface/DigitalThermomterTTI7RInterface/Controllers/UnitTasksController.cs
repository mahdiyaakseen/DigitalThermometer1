using DigitalThermomterTTI7RInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalThermomterTTI7RInterface.Controllers
{
    public class UnitTasksController : Controller
    {

        public UnitTask unitTask;

        // GET: UnitTasks
        [Route("UnitTasks/GetTaskStatus/{StatusName}/{TaskName}")]
        public ActionResult GetTaskStatus(string statusName, String taskName)
        {
            unitTask = TaskSwitch(taskName);
            return View(unitTask);
        }

        private UnitTask TaskSwitch(string taskName)
        {
            //switch (switch_on)
            //{
            //    default:
            //}
            return unitTask;
        }
    }
}