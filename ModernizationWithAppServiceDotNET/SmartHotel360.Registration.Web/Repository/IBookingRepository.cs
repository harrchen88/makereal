namespace SmartHotel.Registration.Repository
{
    using System;
    using System.Collections.Generic;
    using SmartHotel.Registration.Models;

    public interface IBookingRepository: IDisposable
    {
        List<Models.Registration> GetAllBookings();

        Booking GetBookingByID(int registrationId);

        void InsertBooking(Booking booking);

        int DeleteBooking(int bookingId);

        int UpdateBooking(Booking booking);

        void SaveBooking();

        List<Models.Registration> GetBookingsByCustomerFirstName(string firstName);
    }
}
