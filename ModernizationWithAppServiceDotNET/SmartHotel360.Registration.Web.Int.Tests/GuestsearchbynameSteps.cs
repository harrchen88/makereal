using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHotel.Registration.BusinessLogic.Concrete;
using SmartHotel.Registration.BusinessLogic.Interface;
using SmartHotel.Registration.Repository;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SmartHotel360.Registration.Web.Integration.Tests
{
    // Integration Test using Specflow
    [Binding]
    public class GuestsearchbynameSteps
    {
        IBookingManager bookingManager = new BookingManager(new BookingRepository());
        private List<SmartHotel.Registration.Models.Registration> firstNameSearchResult;

        [Given(@"a search bar is at the bookings app home page")]
        public void GivenASearchBarIsAtTheBookingsAppHomePage()
        {
            Console.WriteLine("Skip this!");
        }

        [When(@"the user enters ""(.*)"" as the first name into the search bar")]
        public void WhenTheUserEntersAsTheFirstNameIntoTheSearchBar(string firstName)
        {
            firstNameSearchResult = bookingManager.SearchGuestByFirstName(firstName);
        }

        [Then(@"guest names starting with ""(.*)"" are shown on the home page")]
        public void ThenGuestNamesStartingWithAreShownOnTheHomePage(string expectedFirstNameResult)
        {
            Assert.IsNotNull(firstNameSearchResult);
            Assert.AreEqual(2, firstNameSearchResult.Count);
            foreach (var result in firstNameSearchResult)
            {
                Assert.IsTrue(result.CustomerName.ToLowerInvariant().StartsWith(expectedFirstNameResult));
            }
        }
    }
}
