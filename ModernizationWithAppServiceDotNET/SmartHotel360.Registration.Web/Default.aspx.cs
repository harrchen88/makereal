namespace SmartHotel.Registration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Serilog;
    using Serilog.Core;
    using SmartHotel.Registration.BusinessLogic.Interface;
    using SmartHotel.Registration.Enums;
    using SmartHotel.Registration.Logger;

    public partial class _Default : Page
    {
        private IBookingManager bookingManager;

        private ILogger logger;

        private string searchText;

        private readonly string moduleName;

        //public _Default(IBookingManager bookingManager)
        //{
        //    this.bookingManager = bookingManager;
        //    this.moduleName = "Default.aspx.cs";
        //}

        public _Default(IBookingManager bookingManager, ILogger logger)
        {
            this.bookingManager = bookingManager;
            this.logger = logger;
            this.moduleName = "Default.aspx.cs";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.logger.Information(LogMessages.StartedPageLoadInformation, ModuleName.UI, Convert.ToInt32(EventId.StartPageLoad), Guid.NewGuid());

            if (IsPostBack)
                return;

            if (!String.IsNullOrWhiteSpace(Request.QueryString["srch"]))
            {
                NoBookingsLabel.Visible = false;
                RegistrationGrid.Visible = true;
                searchText = Request.QueryString["srch"].Trim();

                var bookingsfromDBBasedOnSearch = this.bookingManager.SearchGuestByFirstName(searchText);
                if (bookingsfromDBBasedOnSearch != null && bookingsfromDBBasedOnSearch.Count > 0)
                {
                    this.RegistrationGrid.DataSource = bookingsfromDBBasedOnSearch;
                    this.RegistrationGrid.DataBind();
                }
                else
                {
                    NoBookingsLabel.Visible = true;
                    RegistrationGrid.Visible = false;
                }
            }
            else
            {
                List<Models.Registration> registrations;

                // Create custom properties to be logged along with metrics for timed operation
                List<object> customProperties = new List<object>();
                customProperties.Add(Convert.ToInt32(EventId.LatencyBetweenAppDatabase, CultureInfo.InvariantCulture));
                customProperties.Add(Guid.NewGuid());


                using (logger.BeginTimedOperation(LogMessages.GetAllBookingsTimerDescription,
               identifier: LogMessages.GetAllBookingsTimerOperation, beginningMessage: LogMessages.BeginningOperationMessage, completedMessage: LogMessages.CompletedOperationMessage, propertyValues: customProperties.ToArray()))
                {
                    registrations = this.bookingManager.GetAllBookingsForToday();
                }

                this.RegistrationGrid.DataSource = registrations;
                this.RegistrationGrid.DataBind();
            }

            this.logger.Information(LogMessages.EndedPageLoadInformation, ModuleName.UI, Convert.ToInt32(EventId.EndPageLoad), Guid.NewGuid());
        }

        protected void RegistrationGrid_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow row = RegistrationGrid.SelectedRow;

            var registrationId = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Id"];
            var registrationType = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Type"].ToString();

            if (registrationType == "CheckIn")
            {
                Response.Redirect($"Checkin.aspx?registration={registrationId}");
            }

            if (registrationType == "CheckOut")
            {
                Response.Redirect($"Checkout.aspx?registration={registrationId}");
            }
        }

        protected void RegistrationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.RegistrationGrid, "Select$" + e.Row.RowIndex);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchInputText = this.Server.UrlEncode(this.txtSearchMaster.Text); // URL encode in case of special characters
            Response.Redirect("~/Default.aspx?srch=" + searchInputText);
        }
    }
}
