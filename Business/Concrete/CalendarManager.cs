using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CalendarManager : ICalendarService
    {
        private readonly ICalendarDataAccess _calendarDataAccess;
        public CalendarManager(ICalendarDataAccess calendarDataAccess)
        {
            _calendarDataAccess = calendarDataAccess;
        }
        public Calendar ToBook(Calendar calendar)
        {
            if (GetAvailability(calendar.ProductId))
            {
                return _calendarDataAccess.Create(calendar);
            }
            throw new InvalidOperationException("Das Product ist nicht verfügbar!");
        }
        public bool GetAvailability(string productId)
        {
            var calendar = _calendarDataAccess.Get(x=>x.ProductId == productId);
            if (calendar == null)
                return true;

            //Überprüfen aktuelle Verfügbarkeit
            if (DateTime.Now < calendar.StartDate || calendar.EndDate < DateTime.Now)
                return true;

            return false;
        }
    }
}