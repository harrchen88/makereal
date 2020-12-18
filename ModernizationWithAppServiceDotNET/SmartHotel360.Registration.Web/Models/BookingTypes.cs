namespace SmartHotel.Registration.Models
{
    /// <summary>
    /// Booking Types- checkin/ checkout.
    /// </summary>
    public static class BookingTypes
    {
        public static Models.Registration BookingToCheckin(Booking booking)
        {
            return new Models.Registration
            {
                Id = booking.Id,
                Type = "CheckIn",
                Date = booking.From,
                CustomerId = booking.CustomerId,
                CustomerName = booking.CustomerName,
                Passport = booking.Passport,
                Address = booking.Address,
                Amount = booking.Amount,
                Total = booking.Total
            };
        }

        public static Models.Registration BookingToCheckout(Booking booking)
        {
            return new Models.Registration
            {
                Id = booking.Id,
                Type = "CheckOut",
                Date = booking.To,
                CustomerId = booking.CustomerId,
                CustomerName = booking.CustomerName,
                Passport = booking.Passport,
                Address = booking.Address,
                Amount = booking.Amount,
                Total = booking.Total
            };
        }
    }
}