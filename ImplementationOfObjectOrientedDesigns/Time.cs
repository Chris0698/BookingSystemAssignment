///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Utilities
{
    public class Time : ICloneable
    {
        private int hour;
        private int minute;

        public Time(int hour, int minute)
        {
            SetTime(hour, minute);
        }

        public int GetHour()
        {
            return hour;
        }

        public int GetMinute()
        {
            return minute;
        }

        public void SetHour(int hour)
        {
            if (hour > 23 || hour < 0)
            {
                throw new ArgumentException("Hour must be between 0 and 23");
            }
            else
            {
                this.hour = hour;
            }
        }

        public void SetMinute(int minute)
        {
            if(minute > 59 || minute < 0)
            {
                throw new ArgumentException("Minute must be between 0 and 59");
            }
            else
            {
                this.minute = minute;
            }
        }

        public void SetTime(int hour, int minute)
        {
            SetHour(hour);
            SetMinute(minute);
        }

        public string GetFormatted()
        {
            string formattedHour = hour.ToString();
            string formattedMinute = minute.ToString();

            if(formattedHour.Length == 1)
            {
                formattedHour = '0' + formattedHour;
            }

            if(formattedMinute.Length == 1)
            {
                formattedMinute = '0' + formattedMinute;
            }

            return formattedHour + ':' + formattedMinute;
        }

        public Time Clone()
        {
            return (Time)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
