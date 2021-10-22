using System;
using System.ComponentModel;

namespace ToDoAppMVVM.Models
{
    public class TaskTime
    {
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }

        public TaskTime()
        {
            DateTime now = DateTime.Now;

            Day = now.Day.ToString();
            Hour = now.Hour.ToString();
            Minute = now.Minute.ToString();
        }

        public TimeSpan GetDateTime()
        {
            DateTime now = DateTime.Now;

            TimeSpan timeSpan = new DateTime(now.Year, now.Month, int.Parse(Day), int.Parse(Hour), int.Parse(Minute), 0) - now;

            if (timeSpan.TotalSeconds <= 0) { return new TimeSpan(); }

            return timeSpan;
        }
    }
}