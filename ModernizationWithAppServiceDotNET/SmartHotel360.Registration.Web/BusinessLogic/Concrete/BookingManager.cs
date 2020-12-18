namespace SmartHotel.Registration.BusinessLogic.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SmartHotel.Registration.BusinessLogic.Interface;
    using SmartHotel.Registration.Models;
    using SmartHotel.Registration.Repository;

    public class BookingManager: IBookingManager
    {
        private IBookingRepository bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public Booking FindBookings(int registrationId)
        {
            Booking checkin = this.bookingRepository.GetBookingByID(registrationId);
            return checkin;
        }

        public List<Models.Registration> GetAllBookingsForToday()
        {
            var checkins = this.bookingRepository.GetAllBookings().Where(b => b.Date == DateTime.Today).OrderBy(r => r.Date).ToList();
            return checkins;
        }

        public int UpdateBookingDetails(Booking booking)
        {
            return this.bookingRepository.UpdateBooking(booking);
        }

        public List<Models.Registration> SearchGuestByFirstName(string firstName)
        {
            // Below code will call booking repository layer method GetBookingsByCustomerFirstName.
            var checkins = this.bookingRepository.GetBookingsByCustomerFirstName(firstName);

            return checkins;
        }

        public int DeleteBookingDetails(Booking booking)
        {
            var isBookingDeleted = this.bookingRepository.DeleteBooking(booking.Id);
            return isBookingDeleted;
        }
    }
}
