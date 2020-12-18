using SmartHotel.Registration.BusinessLogic;
using SmartHotel.Registration.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class Checkin : Page
    {
        private IBookingManager bookingManager;

        private int registrationId;

        public Checkin(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            var registrationProvided =
                int.TryParse(Request.QueryString["registration"], out int registrationId);

            if (registrationId == 0)
            {
                throw new System.ArgumentException("Parameter cannot be null");
            }

            if (!registrationProvided)
            {
                Response.Redirect("Default.aspx");
            }

            var checkin = this.bookingManager.FindBookings(registrationId);

            if (!string.IsNullOrWhiteSpace(checkin.CustomerId))
            {
                CustomerName.Value = checkin.CustomerName;
                Passport.Value = checkin.Passport;
                CustomerId.Value = checkin.CustomerId;
                Address.Value = checkin.Address;
                Amount.Value = checkin.Amount.ToString(CultureInfo.InvariantCulture);
            }
        }

        protected void UpdateDetails(object sender, EventArgs e)
        {
            this.registrationId = Convert.ToInt32(this.Request.QueryString["registration"]);

            var checkin = this.bookingManager.FindBookings(this.registrationId);

            if (!string.IsNullOrWhiteSpace(checkin.CustomerId))
            {
                checkin.CustomerName = CustomerName.Value;
                checkin.Passport = Passport.Value;
                checkin.Address = Address.Value;
                checkin.Amount = Convert.ToInt32(Amount.Value, CultureInfo.InvariantCulture);
            }

            var returnCode = this.bookingManager.UpdateBookingDetails(checkin);

            if (returnCode == 1)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}