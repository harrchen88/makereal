using SmartHotel.Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Registration.BusinessLogic.Interface
{
    public interface IBookingManager
    {
        List<Models.Registration> GetAllBookingsForToday();

        Booking FindBookings(int registrationId);

        int UpdateBookingDetails(Booking booking);

        List<Models.Registration> SearchGuestByFirstName(string firstName);

        int DeleteBookingDetails(Booking booking);
    }
}
