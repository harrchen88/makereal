using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Globalization;
using SmartHotel.Registration.BusinessLogic.Concrete;
using SmartHotel.Registration.Repository;
using SmartHotel360.Registration.Web.Tests.BusinessLogicUnitTestHelper;
using SmartHotel.Registration.BusinessLogic.Interface;
using System;

namespace SmartHotel.Registration.Web.Tests.BusinessLogicUnitTests
{
    [TestClass]    
    public class BookingsManagerTest
    {
        private readonly Mock<IBookingRepository> bookingRepositoryMoq;

        private readonly IBookingManager bookingManager;

        public BookingsManagerTest()
        {
            bookingRepositoryMoq = new Mock<IBookingRepository>();
            this.bookingManager = new BookingManager(bookingRepositoryMoq.Object);
        }

        #region Find Bookings Test Cases

        /// <summary>
        /// Tests that the booking exists using valid data
        /// </summary>
        [TestMethod]
        public void FindValidBookingsTest()
        {
            //Arrange
            bookingRepositoryMoq.Setup(m => m.GetBookingByID(1)).Returns(BookingManagerTestHelper.GetValidBooking());

            //Act
            var actualBooking = bookingManager.FindBookings(1);

            //Assert
            bookingRepositoryMoq.Verify(m => m.GetBookingByID(1), Times.Once());
        }

        /// <summary>
        /// Tests that the booking does not exists when passed invalid booking data.
        /// </summary>
        [TestMethod]
        public void FindInvalidBookingsTest()
        {
            //Arrange
            bookingRepositoryMoq.Setup(m => m.GetBookingByID(1)).Returns(BookingManagerTestHelper.GetInvalidBooking());

            //Act
            var actualBooking = bookingManager.FindBookings(2);

            //Assert
            Assert.IsNull(actualBooking);
        }

        #endregion

        #region Get All Bookings for Today Test Cases
        /// <summary>
        /// Tests the get all bookings for today using valid data is not null
        /// </summary>
        [TestMethod]
        public void GetAllBookingsForTodayNotNullTest()
        {
            //Arrange
            this.bookingRepositoryMoq
                .Setup(x => x.GetAllBookings())
                .Returns(BookingManagerTestHelper.GetValidBookingList());

            //Act            
            var response = bookingManager.GetAllBookingsForToday();

            //Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Tests the get all bookings for today using valid data
        /// </summary>
        [TestMethod]
        public void GetAllBookingsForTodayPositiveTest()
        {
            var bookingList = BookingManagerTestHelper.GetValidBookingList();

            //Arrange
            this.bookingRepositoryMoq
                .Setup(x => x.GetAllBookings())
                .Returns(bookingList);

            //Act            
            var response = bookingManager.GetAllBookingsForToday();

            //Assert
            Assert.AreEqual(bookingList.Count, response.Count);
            Assert.AreEqual("1", response[0].CustomerId, true, CultureInfo.InvariantCulture);
            Assert.AreEqual("2", response[1].CustomerId, true, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Tests the get all bookings for today using invalid data returns zero responses
        /// </summary>
        [TestMethod]
        public void GetAllBookingsForTodayNegativeTest()
        {
            var bookingList = BookingManagerTestHelper.GetInvalidBookingList();

            //Arrange
            this.bookingRepositoryMoq
                .Setup(x => x.GetAllBookings())
                .Returns(bookingList);

            //Act            
            var response = bookingManager.GetAllBookingsForToday();

            //Assert
            Assert.AreEqual(0, response.Count);
        }

        #endregion

        #region Update Booking Details Test Cases

        /// <summary>
        /// Tests the update bookings details in checkin page using valid booking that exists.
        /// </summary>
        [TestMethod]
        public void UpdateValidBookingTest()
        {
            var booking = BookingManagerTestHelper.GetValidBooking();

            //Arrange
            this.bookingRepositoryMoq
                .Setup(x => x.UpdateBooking(booking))
                .Returns(1);

            //Act 
            var response = bookingManager.UpdateBookingDetails(booking);

            //Assert
            Assert.AreEqual(1, response);
        }

        /// <summary>
        /// Tests the update bookings details in checkin page using invalid booking that does not exists.
        /// </summary>
        [TestMethod]
        public void UpdateInvalidBookingTest()
        {
            var booking = BookingManagerTestHelper.GetValidBooking();

            //Arrange
            this.bookingRepositoryMoq
                .Setup(x => x.UpdateBooking(booking))
                .Returns(0);

            //Act 
            var response = bookingManager.UpdateBookingDetails(BookingManagerTestHelper.GetInvalidBooking());

            //Assert
            Assert.AreEqual(0, response);
        }

        #endregion
    }
}