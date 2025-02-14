using System;
using System.Globalization;
using BBDTest.Models;
using BBDTest.Services;
using Reqnroll;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class SpecifyDatesStepDefinitions
    {
        // Some data required for our step definitions
        private readonly RoomSearchService _roomSearchService = new();
        private readonly SearchCriteria _searchCriteria = new();
        //private DateOnly _checkInDate;
        //private DateOnly _checkOutDate;
        private string _errorMessage = String.Empty;


        [Given("the user is on the hotel booking page")]
        public void GivenTheUserIsOnTheHotelBookingPage()
        {
            //Simulate navigating to search page
        }

        [When("the user specifies a checkIn date of {string}")]
        public void WhenTheUserSpecifiesACheckInDateOf(string checkInDate)
        {
            //_checkInDate = DateOnly.Parse(checkInDate, new CultureInfo("en-GB"));
            _searchCriteria.CheckInDate = DateOnly.Parse(checkInDate, new CultureInfo("en-GB"));
        
        }

        [When("the user specifies a checkOut date of {string}")]
        public void WhenTheUserSpecifiesACheckOutDateOf(string checkOutDate)
        {
            //_checkOutDate = DateOnly.Parse(checkOutDate, new CultureInfo("en-GB"));
            _searchCriteria.CheckOutDate = DateOnly.Parse(checkOutDate, new CultureInfo("en-GB"));

            if (_searchCriteria.CheckOutDate <= _searchCriteria.CheckInDate)
            {
                _roomSearchService.EnableSearch = false;
                _errorMessage = "Check-out date must be after check-in date.";
            }
            else
            {
                _roomSearchService.EnableSearch = true;
                _roomSearchService.Search(_searchCriteria);
            }
        }

     
        [Then("generate the error message {string}")]
        public void ThenGenerateTheErrorMessage(string expectedErrorMessage)
        {
            Assert.Equal(expectedErrorMessage, _errorMessage);
        }

        [Then("disable the search")]
        public void ThenDisenableTheSearch()
        {
            Assert.False(_roomSearchService.EnableSearch);
        }


        [Then("enable the search")]
        public void ThenEnableTheSearch()
        {
            Assert.True(_roomSearchService.EnableSearch);
        }

        [Then("the IsEnabled state search should be {string}")]
        public void ThenTheIsEnabledStateSearchShouldBe(string state)
        {
            Assert.Equal(Convert.ToBoolean(state), _roomSearchService.EnableSearch);
        }


    }
}
