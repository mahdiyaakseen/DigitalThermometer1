using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalThermomterTTI7RInterface.Models
{
    public class UnitStatus
    {
        //id for status
        public int Id { get; set; }
        //Status name - Self Test , Beeper etc.,
        public String Name { get; set; }
        //State of status obtained from serial link true/false
        public Boolean State { get; set; }
        //if the unit status state has been toggle
        public Boolean StateToggled { get; set; }

        //constructor
        public UnitStatus()
        {
            Id = 0;
            Name = "None";
            State = false;
            StateToggled = false;
        }
    }
}