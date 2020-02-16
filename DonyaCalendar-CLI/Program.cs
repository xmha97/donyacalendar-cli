using System;
using System.Globalization;

namespace donyacalendar_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                DrawCalendar(DateTime.Now, true, true);
            }
            else
            {
                string t = args[0];
                try
                {
                    int r = int.Parse(t);
                    for (int i = 0; i < 12; i++)
                    {
                        DrawCalendar(new PersianCalendar().ToDateTime(r, i + 1, 1, 1, 1, 1, 1), false, false);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        static void DrawCalendar(DateTime date, bool highlightDay, bool showYear)
        {
            string[] mn = { "Farvardin", "Ordibehesht", "Khordad", "Tir", "Mordad", "Shahrivar", "Mehr", "Aban", "Azar", "Dey", "Bahman", "Esfand" };
            PersianCalendar p = new PersianCalendar();
            string t = string.Empty;
            if (showYear == true)
            {
                t = mn[p.GetMonth(date) - 1] + " " + p.GetYear(date).ToString();
            }
            else
            {
                t = mn[p.GetMonth(date) - 1];
            }
            for (int i = 0; i < 10 - (t.Length / 2) - (t.Length % 2); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(t);
            Console.WriteLine("Sh Ye Do Se Ch Pa Jo");
            int days = p.GetDaysInMonth(p.GetYear(date), p.GetMonth(date));
            int currentDay = 1;
            int fas = (int)p.GetDayOfWeek(new DateTime(date.Year, date.Month, 1));
            for (int j = 0; j <= 5; j++)
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (currentDay > days + fas)
                        break;
                    currentDay++;
                    if (currentDay > fas + 1)
                    {
                        if ((currentDay - fas - 1 == p.GetDayOfMonth(date)) && (highlightDay == true))
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        string d = (currentDay - fas - 1).ToString();
                        if (d.Length > 1)
                        {
                            Console.Write((currentDay - fas - 1).ToString("00"));
                        }
                        else
                        {
                            Console.Write((currentDay - fas - 1).ToString(" 0"));
                        }
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}