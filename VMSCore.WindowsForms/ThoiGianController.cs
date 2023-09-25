using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SalesManager.Controller
{
    class ThoiGianController
    {
        public int Startdayofmonth( int month, int year)
        {
            int numday = 1;
            numday = DateTime.DaysInMonth(year, month);
            return 1;
        }
        public int Enddayofmonth(int month, int year)
        {
            int numday = 0;
            numday = (int)DateTime.DaysInMonth(year, month);
            return numday;
        }
        public int ReturnIndex(string day)
        {
            int trave = 0;
            switch (day)
            {
                case "Monday":
                    trave = 1;
                    break;
                case "Tuesday":
                    trave = 2;
                    break;
                case "Wednesday":
                    trave = 3;
                    break;
                case "Thursday":
                    trave = 4;
                    break;
                case "Friday":
                    trave = 5;
                    break;
                case "Saturday":
                    trave = 6;
                    break;
                case "Sunday":
                    trave = 7;
                    break;
                default:
                    trave = 0;
                    break;
            }
            return trave;
        }
        //public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        //{
        //    CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
        //    return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        //}
        public DateTime ReturnStartWeek(DateTime Date)
        {
            DateTime Trave = new DateTime();
            int Ngay =0;
            int tam = 0;
            int num = ReturnIndex(Date.DayOfWeek.ToString());
            if (num > 1)
                Ngay = (int)(Date.Day) - (num - 1);
            else
                Ngay = (Date.Day);
            if (Ngay == 0)
            {
                tam = Enddayofmonth(Date.Month - 1, Date.Year);
                Trave = DateTime.Parse(Date.Month - 1 + "/" + tam + "/" + Date.Year);
            }
            else if (Ngay < 0)
            {
                tam = Enddayofmonth(Date.Month - 1, Date.Year) + (int)(Date.Day) - (num - 1);
                Trave = DateTime.Parse(Date.Month - 1 + "/" + tam + "/" + Date.Year);
            }
            else
            {
                Trave = DateTime.Parse(Date.Month + "/" + Ngay + "/" + Date.Year);
            }
            return Trave;
        }
        public DateTime EndStartWeek(DateTime Date)
        {
            DateTime Trave = new DateTime();
            int num = ReturnIndex(Date.DayOfWeek.ToString());
            int Ngay = (int)(Date.Day) + 7 - num;
            if (Ngay > Enddayofmonth(Date.Month, Date.Year))
            {
                Trave = DateTime.Parse(Date.Month + 1 + "/" + (Ngay - Enddayofmonth(Date.Month, Date.Year)) + "/" + Date.Year);
            }
            else
                Trave = DateTime.Parse(Date.Month + "/" + Ngay + "/" + Date.Year);
            return Trave;
        }
        public int Qui_Num(int month)
        {
            int Qui = 1;
            if ((1 <= month) && (month <= 3))
            {
                Qui = 1;
            }
            else if ((4 <= month) && (month <= 6))
            {
                Qui = 2;
            }
            else if ((7 <= month) && (month <= 9))
            {
                Qui = 3;
            }
            else if ((10 <= month) && (month <= 12))
            {
                Qui = 4;
            }
            return Qui;
        }
        public DateTime StartDayofQui(int Qui, int year)
        {
            DateTime Ngay = new DateTime();
            if (Qui == 1)
            {
                Ngay = DateTime.Parse("01/01/" + year);
            }
            if (Qui == 2)
            {
                Ngay = DateTime.Parse("04/01/" + year);
            }
            if (Qui == 3)
            {
                Ngay = DateTime.Parse("07/01/" + year);
            }
            if (Qui == 4)
            {
                Ngay = DateTime.Parse("10/01/" + year);
            }
            return Ngay;
        }
        public DateTime EndDayofQui(int Qui, int year)
        {
            DateTime Ngay = new DateTime();
            if (Qui == 1)
            {
                Ngay = DateTime.Parse("03/"+Enddayofmonth(3,year)+ "/" + year);
            }
            if (Qui == 2)
            {
                Ngay = DateTime.Parse("06/"+Enddayofmonth(6,year)+"/" + year);
            }
            if (Qui == 3)
            {
                Ngay = DateTime.Parse("09/"+Enddayofmonth(9,year)+"/" + year);
            }
            if (Qui == 4)
            {
                Ngay = DateTime.Parse("12/"+Enddayofmonth(12, year) + "/" + year);
            }
            return Ngay;
        }
    }
}
