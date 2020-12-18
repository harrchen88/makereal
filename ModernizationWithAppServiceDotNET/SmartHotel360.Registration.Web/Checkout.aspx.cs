namespace SmartHotel.Registration
{
    using System;
    using System.Globalization;
    using SmartHotel.Registration.BusinessLogic.Interface;
    using SmartHotel.Registration.Models;

    public partial class Checkout : System.Web.UI.Page
    {
        private IBookingManager bookingManager;

        public Checkout(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var registrationProvided =
                int.TryParse(Request.QueryString["registration"], out int registrationId);
            if (!registrationProvided)
                Response.Redirect("Default.aspx");

            Booking checkin = this.bookingManager.FindBookings(registrationId);
            this.CustomerName.Value = checkin.CustomerName;
            this.Passport.Value = checkin.Passport;
            this.CustomerId.Value = checkin.CustomerId;
            this.Address.Value = checkin.Address;
            this.Amount.Value = checkin.Amount.ToString(CultureInfo.InvariantCulture);
        }
    }
}
