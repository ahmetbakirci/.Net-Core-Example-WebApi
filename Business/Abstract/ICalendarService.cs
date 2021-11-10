using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICalendarService
    {
        public Calendar ToBook(Calendar calendar);
        public bool GetAvailability(string productId);
    }
}
