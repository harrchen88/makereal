namespace SmartHotel.Registration.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SmartHotel.Registration.DataAccessLayer;
    using SmartHotel.Registration.Models;

    public class BookingRepository : IBookingRepository
    {
        private bool disposed;

        private BookingsDbContext bookingsDbContext;

        public BookingRepository()
        {
            this.bookingsDbContext = new BookingsDbContext();
        }

        ~BookingRepository()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                ((IDisposable)this.bookingsDbContext).Dispose();
            }

            this.disposed = true;
        }

        public List<Models.Registration> GetAllBookings()
        {
            var checkins = this.bookingsDbContext.Bookings
            .Select(BookingTypes.BookingToCheckin);

            var checkouts = this.bookingsDbContext.Bookings
                .Select(BookingTypes.BookingToCheckout);

            var registrations = checkins.Concat(checkouts).ToList();
            return registrations;
        }


        public Booking GetBookingByID(int registrationId)
        {
            if (registrationId == 0)
            {
                throw new ArgumentNullException(nameof(registrationId));
            }

            var booking = this.bookingsDbContext.Bookings.Find(registrationId);
            return booking;
        }

        public void InsertBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public int DeleteBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public int UpdateBooking(Booking booking)
        {
            if (booking == null || booking.Id == 0)
            {
                throw new ArgumentNullException(nameof(booking));
            }

            var bookingToUpdate = this.bookingsDbContext.Bookings.Find(booking.Id);
            bookingToUpdate.CustomerName = booking.CustomerName;
            bookingToUpdate.Address = booking.Address;
            bookingToUpdate.Amount = booking.Amount;
            bookingToUpdate.Passport = booking.Passport;
            var returnCode = this.bookingsDbContext.SaveChanges();
            return returnCode;
        }

        public void SaveBooking()
        {
            throw new NotImplementedException();
        }

        public List<Registration> GetBookingsByCustomerFirstName(string firstName)
        {
            // Below code will fetch bookings based on customer first name from database.

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            var booking = from b in this.bookingsDbContext.Bookings
                          where b.CustomerName.StartsWith(firstName.Trim())
                          select b;
            var checkins = booking
           .Select(BookingTypes.BookingToCheckin);

            var registrations = checkins.ToList();
            return registrations;
        }
    }
}
