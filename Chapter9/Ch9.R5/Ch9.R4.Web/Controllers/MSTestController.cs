using Ch9.R4.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch9.R4.Web.Controllers
{
    public class MSTestController : Controller
    {

        DateTime m_date;
        public MSTestController(DateTime date)
        {
            m_date = date;
        }
        public MSTestController(): this(DateTime.Now){}
        //
        // GET: /MSTest/

        public ActionResult Index()
        {

            if (m_date.Month == 2 && m_date.Day == 29)
            {
                throw new ApplicationException("Leap day is not supported");
            }

            DayModel model = new DayModel();
            model.DateDisplay = m_date.ToLongDateString();
            bool isWinter = IsWinter(m_date.Month);
            bool isNight = IsNight(isWinter, m_date.Hour);
            model.isDayTime = !isNight;
            if (isNight && isWinter)
            {
                model.SceneName = "Night";
                model.SoundEffect = "WinterStorm";
            }
            if ((!isNight) && isWinter)
            {
                model.SceneName = "WinterDay";
                model.SoundEffect = "WinterStorm";
            }
            if ((!isNight) && (!isWinter))
            {
                model.SceneName = "SummerDay";
                model.SoundEffect = "SummerDay";
            }
            if (isNight && (!isWinter))
            {
                model.SceneName = "Night";
                model.SoundEffect = "Night";
            }



            return View("Index", model);
        }

        private bool IsWinter(int month)
        {
            if (month < 4 || month > 10)
                return true;
            else
                return false;
        }

        private bool IsNight(bool isWinter, int hour)
        {
            if (isWinter)
            {
                if ((hour > 7) && (hour < 17))
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                if ((hour > 5) && (hour < 20))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
