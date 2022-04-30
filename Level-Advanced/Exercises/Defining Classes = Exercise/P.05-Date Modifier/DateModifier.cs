using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace P._05_Date_Modifier
{
    public class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            this.SecondDate = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        }
        private DateTime firstDate;
        private DateTime secondDate;

        public DateTime FirstDate
        {
            get { return this.firstDate; }  
            set { this.firstDate = value; }
        }
        public DateTime SecondDate
        {
            get { return this.secondDate; }
            set { this.secondDate = value; }
        }
        public int CalculateDifferenceBetweenDays(string firstDate, string secondDate)
        {
            return Math.Abs((this.FirstDate.Date - this.SecondDate.Date).Days);
            //.Days определя в какво да се смята разликата м/у две дати ; може .Minutes/Seconds и др.
        }
    }
}
