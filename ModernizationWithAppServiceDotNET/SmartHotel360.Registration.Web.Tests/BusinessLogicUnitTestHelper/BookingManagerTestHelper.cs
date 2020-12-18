using SmartHotel.Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel360.Registration.Web.Tests.BusinessLogicUnitTestHelper
{
    /// <summary>
    /// Booking Manager Test Helper
    /// </summary>
    public class BookingManagerTestHelper
    {
        /// <summary>
        /// Gets the valid booking.
        /// </summary>
        /// <returns>Booking object</returns>
        public static Booking GetValidBooking()
        {
            return new Booking
            {
                Id = 1,
                CustomerId = "1",
                CustomerName = "Alex",
                From = DateTime.Today.AddHours(2)
            };
        }

        public static Booking GetBooking()
        {
            return new Booking
            {
                Id = 3,
                CustomerId = "3",
                CustomerName = "Maria",
                From = DateTime.Today.AddHours(2)
            };
        }

        public static Booking GetInvalidBooking()
        {
            return new Booking
            {
                Id = 2,
                CustomerId = "2",
                CustomerName = "Susan",
                From = DateTime.Today.AddHours(2)
            };
        }

        public static Booking GetUpdatedBooking()
        {
            return new Booking
            {
                Id = 1,
                CustomerId = "1",
                CustomerName = "Alex P",
                From = DateTime.Today.AddHours(2)
            };
        }

        public static List<SmartHotel.Registration.Models.Registration> GetValidCheckinBookingList()
        {
            var bookingCheckin = new List<Booking>
            {
                new Booking { CustomerId = "1", CustomerName = "Alex" , From = DateTime.Today}
            }.Select(BookingTypes.BookingToCheckin);

            return bookingCheckin.ToList();
        }

        public static List<SmartHotel.Registration.Models.Registration> GetValidCheckOutBookingList()
        {
            var bookingListCheckOuts = new List<Booking>
            {
                new Booking { CustomerId = "2", CustomerName = "Ivan", To = DateTime.Today}
            }.Select(BookingTypes.BookingToCheckout);

            return bookingListCheckOuts.ToList();
        }

        public static List<SmartHotel.Registration.Models.Registration> GetInvalidCheckinBookingList()
        {
            var bookingCheckin = new List<Booking>
            {
                new Booking { CustomerId = "3", CustomerName = "Susan" , From = DateTime.Today.AddHours(2)}
            }.Select(BookingTypes.BookingToCheckin);

            return bookingCheckin.ToList();
        }

        public static List<SmartHotel.Registration.Models.Registration> GetInvalidCheckOutBookingList()
        {
            var bookingListCheckOuts = new List<Booking>
            {
                new Booking { CustomerId = "4", CustomerName = "Anna", To = DateTime.Today.AddHours(2)}
            }.Select(BookingTypes.BookingToCheckout);

            return bookingListCheckOuts.ToList();
        }

        public static List<SmartHotel.Registration.Models.Registration> GetValidBookingList()
        {
            return GetValidCheckinBookingList().Concat(GetValidCheckOutBookingList()).ToList();
        }

        public static List<SmartHotel.Registration.Models.Registration> GetInvalidBookingList()
        {
            return GetInvalidCheckinBookingList().Concat(GetInvalidCheckOutBookingList()).ToList();
        }
    }
}