using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalThermomterTTI7RInterface.Models
{
    public class UnitTask
    {
        // id for task
        public int Id { get; set; }
        // example - initiate self test , get data from serial buffer etc.,
        public string Name { get; set; }
        //Self Test , Beeper etc.,
        public UnitStatus StatusType { get; set; } = new UnitStatus();
        // tristate - ongoing , completed, not started 
        public TaskState TaskState { get; set; }
        // indicated if data has been recieved from the serial link
        public Boolean DataReceivedState { get; set; }
        // data recieved from serial link
        public string Data { get; set; }

        //constructor to initialise unit task defaults
        public UnitTask()
        {
            Id = 0;
            Name = string.Empty;
            StatusType = new UnitStatus() { Id = 0, Name = string.Empty, State = false, StateToggled = false };
            TaskState = TaskState.NotStarted;
            DataReceivedState = false;
            Data = string.Empty;
        }
    }
    //tristate enum to represent task state
    public enum TaskState : byte
    {
        NotStarted = 0,
        Ongoing = 1,
        Completed = 2
    }
}