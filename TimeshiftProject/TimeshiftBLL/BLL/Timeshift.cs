using System;
using System.Runtime.InteropServices;
using TimeshiftBLL.Models;

namespace TimeshiftBLL.BLL
{
    public class Timeshift
    {
        private SYSTEMTIME st = new SYSTEMTIME();

        [DllImport("kernel32.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("kernel32.dll")]
        public extern static bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

        public bool ChangeDateTime(DateTime expDate)
        {
            bool flage = false;
            GetSystemTime(ref st);

            st.year = (ushort)expDate.Year;
            st.month = (ushort)expDate.Month;
            st.dayOfWeek = (ushort)expDate.DayOfWeek;
            st.day = (ushort)expDate.Day;
            st.minute = (ushort)expDate.Minute;
            st.second = (ushort)expDate.Second;

            if (SetSystemTime(ref st))
                flage = true;
            return flage;
        }

        public string GetCurrentDateTime()
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            return currentDateTime;
        }
    }
}
