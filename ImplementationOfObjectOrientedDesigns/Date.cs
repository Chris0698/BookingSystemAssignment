 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Utilities
{
    public class Date : ICloneable
    {
        private int day;
        private int month;
        private int year;

        public Date(int day, int month, int year)
        {
            SetDate(day, month, year);
        }

        public int GetDay()
        {
            return day;
        }

        public int GetMonth()
        {
            return month;
        }

        public int GetYear()
        {
            return year;
        }

        public void SetDay(int newDay)
        {
            if(newDay > 31 || newDay < 1)
            {
                throw new ArgumentException("Day must be between 1 and 31");
            }
            else
            {
                day = newDay;
            }
        }

        public void SetMonth(int newMonth)
        {
            if (newMonth > 12 || newMonth < 1)
            {
                throw new ArgumentException("Month must be between 1 and 12");
            }
            else
            {
                month = newMonth;
            }
        }

        public void SetYear(int newYear)
        {
            if(newYear.ToString().Length != 4)
            {
                throw new ArgumentException("Year should be 4 digits long");
            }
            else
            {
                year = newYear;
            }
        }

        public void SetDate(int day, int month, int year)
        {
            SetDay(day);
            SetMonth(month);
            SetYear(year);
        }

        public string GetFormatted()
        {
            string formattedDay = day.ToString();
            string formattedMonth = month.ToString();

            if (day < 10)
            {
                formattedDay = "0" + day;
            }

            if (month < 10)
            {
                formattedMonth = "0" + month;
            }

            return formattedDay + "/" + formattedMonth + "/" + year.ToString().Substring(2,2);
        }

        public string GetDatabaseFormat()
        {
            string formattedDay = day.ToString();
            string formattedMonth = month.ToString();

            if (day < 10)
            {
                formattedDay = "0" + day;
            }

            if (month < 10)
            {
                formattedMonth = "0" + month;
            }

            return year.ToString() + "-" + formattedMonth + "-" + formattedDay;
        }

        public Date Clone()
        {
            return (Date)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
